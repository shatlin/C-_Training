##################################################################################
# Section 1: et the julian date from bmmifsv.pvglobal 
##################################################################################
use win32::ODBC;

$juliandt = 0;
    if (!($O = new Win32::ODBC("DSN=cs3;UID=bmmi;PWD=secret"))){
	print "Failure. \n\n";
	$Failed{'Test 3a'} = "new(): " . Win32::ODBC::Error();
	PresentErrors();
	exit();
    }else{
	print "Success (connection #", $O->Connection(), ")\n\n";
    }
    $sql_string = "select julian_dt from bmmifsv.pvglobal";
    if (! $O->Sql($sql_string)){
	while($O->FetchRow()){
	    undef %Data;
	    %Data = $O->DataHash();
	    print $Data{'JULIAN_DT'};
	    $juliandt = $Data{'JULIAN_DT'};
	}
    }else{
	$Failed{'Test 10'} = "Sql(): " . $O->Error();
    }

##############################################################################
# Section 2: Read the directory and get the files 
##############################################################################
$indir="d:\\pvdata\\asn\\pya\\ASNintm\\"; 
$logfile="d:\\pvdata\\asn\\pya\\asnsave\\ASNLOG.".$juliandt;
print $logfile;
open(LOG, "> ".$logfile) or die "open $logfile : $!";

# open the directory and read the contents(810 file names)
opendir DIR, $indir or die "Can't open directory $indir: $!\n";

#but that includes the . files, so it is best to ensure they aren't included: 
@files=grep !/^\./, readdir(DIR);
print LOG "Total files ",scalar(@files),"\n";

$fcount = 0;

#print the files in the array
foreach $files (@files) {
	$infile  = $indir.$files;
	open(IN, "< $infile") or die "open $infile : $!";
	print LOG "processing ".$infile;
	&process_file;
	close(IN);
	print LOG "Successfull \n";
}

&destroy;
exit;
#######################################################################################################
# End of main Section
#######################################################################################################

#######################################################################################################
# Section process_file: read HDR once per file and DTL 4 times for each product 
#######################################################################################################
sub process_file {
	chomp ($kk=<IN>);
	&process_header($kk);
	while (<IN>) {
		chomp ($kk1=$_);
		chomp ($kk2=<IN>);
		chomp ($kk3=<IN>);
		chomp ($kk4=<IN>);
		&process_details($kk1,$kk2,$kk3,$kk4);
	}
}
#######################################################################################################
# Section process_header: Collect fields from the first line of the file
#######################################################################################################
sub process_header{
$hdr = @_[0];
$asn_no         = substr($hdr,5,20);
$asn_date       = substr($hdr,26,8);
$cntr_no        = substr($hdr,35,20);
$cntr_type      = substr($hdr,56,3);
$seal_no        = substr($hdr,60,20);
$vessel         = substr($hdr,81,25);
$port_disp      = substr($hdr,107,20);
$sail_date      = substr($hdr,128,8);
$eta            = substr($hdr,137,8);
$tot_pallets    = substr($hdr,146,3);
$tot_cases      = substr($hdr,150,5);
$inv_no         = substr($hdr,156,20);
$inv_date       = substr($hdr,177,8);
$freight        = substr($hdr,186,8);
$tot_lines      = substr($hdr,195,4);

$headins="'".$asn_no."',to_date('".$asn_date."','YYYYMMDD'),'".$cntr_no."','".$cntr_type."','".$seal_no."','".
	 $vessel."','".$port_disp."','',to_date('".$sail_date."','YYYYMMDD'),to_date('".$sail_date."','YYYYMMDD'),".
	 $tot_pallets.",'".$inv_no."',to_date('".$inv_date."','YYYYMMDD'),".$freight.",'','',".$tot_cases.",0,null";
#print $headins;
    $sql_string = "insert into pvasnhead values (".$headins.")";
    $t1=$O->sql($sql_string);
    if (! $t1) {
print LOG " Header Success ASN # ".$asn_no," Total Items ".$tot_lines."\n";
    }else{
print LOG " head failure ".$O->Error();

	$Failed{'Test 10'} = "Sql(): " . $O->Error();
    }
}

#######################################################################################################
# Section process_details: Collect fields from the DTL1,DTL2,DTL3,DTL4 lines
#######################################################################################################
sub process_details{
$kk1 = @_[0]; $kk2 = @_[1]; $kk3 = @_[2]; $kk4 = @_[3];
$po_number      = substr($kk1,5,20);   $po_number =~ s/ //g;
$vp_no          = substr($kk1,29,20);
$nsn            = substr($kk1,50,13);   $nsn =~ s/ //g;

$desc           = substr($kk2,5,80);

$qty_ordered    = substr($kk3,5,8);
$qty_shipped    = substr($kk3,14,8);
$vendor_cost    = substr($kk3,23,8);
$freight        = substr($kk3,32,8);
$candf          = substr($kk3,41,8);
$bmmi_price     = substr($kk3,50,8);
$napa_discount  = substr($kk3,59,8);
$net_price      = substr($kk3,68,8); 
$brand          = substr($kk3,88,10);  
$mfgid          = substr($kk3,129,15);
$pkg            = substr($kk3,145,14);
$purch_unit     = substr($kk3,186,2);

$len            = substr($kk4,5,8);
$wth            = substr($kk4,14,8);
$hgt            = substr($kk4,23,8);
$cube           = substr($kk4,32,10);
$ti             = substr($kk4,43,3);
$hi             = substr($kk4,47,3);
$wt             = substr($kk4,51,8);
$twt            = substr($kk4,60,8);
$pack_date      = substr($kk4,69,8);
$expiry_date    = substr($kk4,78,8);

$prd = substr($nsn,0,4).substr($nsn,9,4);

###### Getting warehouse,product from Catalog  
    $sql_string = "select warehouse,product from pvcatvw where stock_number = '".$nsn."'";
#    $sql_string = "select warehouse,product from podetm where 
#                 trim(order_no) = '".$po_number."' and product like '".$prd."'";
    $t1=$O->Sql($sql_string);
    if (! $t1) {
	    $O->FetchRow();
	    undef %Data;
	    %Data      = $O->DataHash();
	    $warehouse = $Data{'WAREHOUSE'};
	    $product   = $Data{'PRODUCT'};
    }else{
	print LOG "Detail failure : ASN ->".$asn." NSN ->".$nsn." File ->".$infile."\n";
	$Failed{'Test 10'} = "Sql(): " . $O->Error();
    }

###### End of Getting warehouse,product from Catalog  
$detlins="'".$asn_no."','".$po_number."',0,'".$nsn."','".$product."','',".$qty_ordered.",".$qty_shipped.",".$vendor_cost.",
	 ".$bmmi_price.",".$napa_discount.",'".$brand."',to_date('".$pack_date."','YYYYMMDD'),
	  to_date('".$expiry_date."','YYYYMMDD'),'',0,0,' ',' ','',0,0,0,0,0,".$cube.",0,".$ti.",".$hi.",".$wt.",0,0,
	  '".$warehouse."','','','',0,0,null";
    $sql_string = "insert into pvasndetl values (".$detlins.")";
    $t1=$O->sql($sql_string);
    if (! $t1) {
#       print " Detl Success "
    }else{
	print " Detl failure ".$O->Error();
	$Failed{'Test 10'} = "Sql(): " . $O->Error();
    }
}
#######################################################################################################
# Section Destroy all DB connections, close files etc..
#######################################################################################################
sub destroy {

    $sql_commit="commit";
    $t2=$O->sql($sql_commit);
    if (! $t2) {
	print LOG "Commit Success \n";
    }else{
	$Failed{'Test 10'} = "Sql(): " . $O->Error();
    }
print "\t\t...", (($O->Close())? "Successfully closed.":"Failure."), "\n";
close(LOG);
}


