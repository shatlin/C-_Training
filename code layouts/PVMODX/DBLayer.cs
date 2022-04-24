using System;
using System.Data.OleDb;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;



namespace PVMODX
{
	
	/// <summary>
	/// DBLayer contains functions related to database transactions. 
	/// </summary>
	/// <remarks>
	/// All Common database functions are defined in DBLayer.It also
	/// Contains module specific functions that donot require to open
	/// a database connection and transaction
	/// </remarks>

	public class DBLayer: db
	{
		//string connStr;
		private string result = null;


		public class DBLayerException : Exception
		{
			public DBLayerException(string message) : base(message){}
			public DBLayerException(string message, Exception innerException) : base(message,innerException){}
		}

		/// <summary>
		/// Defines the Database Connection String
		/// </summary>
		
		public DBLayer()
		{
			
			//connStr = "Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
		}
		


		public DataSet ASNRPT_DS(string asnno)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter("select * from pvasnhead a, pvasndetl b where a.asn_no=b.asn_no and a.asn_no='"+asnno+"'", dbConnection);
				dbAdapter.Fill(dbDataSet, "pvasn");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;
		}



		public DataSet getASNDetails_DS(string asnNo)
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_getASNDetails";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_asnNo",OleDbType.Char, 15);
			param1.Value = asnNo.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "pvASNDetl");
				OleDbCommandBuilder objBldr = new OleDbCommandBuilder(dbAdapter);
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			return dbDataSet;

		}



		//returns all the Remark Types in a combo box.

		public void  getRemarksType(MetaBuilders.WebControls.ComboBox theComboBox)
		{
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			string strSql = "select remtype, remname from pvremhead order by remtype";
			
			OleDbCommand dbCommand = new OleDbCommand(strSql,dbConnection);
			OleDbDataReader dbDataReader;

			try
			{
				dbConnection.Open();
				dbDataReader = dbCommand.ExecuteReader();
				theComboBox.Items.Clear();
				while (dbDataReader.Read())
				{
					string remType = (string) dbDataReader["remtype"].ToString();
					string remName = (string) dbDataReader["remname"].ToString();
					theComboBox.Items.Add(new ListItem(remName.Trim(), remType.Trim()));
					// theComboBox.Items.Add(dbReader.GetString(0));
				}	
				dbDataReader.Close ();	

			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			finally
			{
				dbConnection.Close();
			}
		}



		//returns all the Remarks in a combo box.
		public void  getremarksDesc(MetaBuilders.WebControls.ComboBox theComboBox, string remType)
		{
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			string strSql = "Select remid, remarks from pvremdesc where remtype ="+remType.Trim();
			
			OleDbCommand dbCommand = new OleDbCommand(strSql,dbConnection);
			OleDbDataReader dbDataReader;

			try
			{
				dbConnection.Open();
				dbDataReader = dbCommand.ExecuteReader();
				theComboBox.Items.Clear();
				while (dbDataReader.Read())
				{
					string remID = (string) dbDataReader["remID"].ToString();
					string remarks = (string) dbDataReader["remarks"].ToString();
					theComboBox.Items.Add(new ListItem(remarks.Trim(), remID.Trim()));
				}	
				dbDataReader.Close ();	

			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			finally
			{
				dbConnection.Close();
			}
		}



		// returns all the remarks in a DataSet based on remark type
		public DataSet remarksDesc_DS(string remType)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql ="Select remid, remarks from pvremdesc where remtype ="+remType.Trim();
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "remarks");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			return dbDataSet;
		}



		//returns all the supplier by type in a DataSet
		public DataSet supplier_DS(string suppType)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql = "Select * from bmmi.pvsupmast where vendor_Type='"+ suppType + "' order by vendor_id";
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvsupmast");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			return dbDataSet;
		}


		//returns all the catalog difference list  in a DataSet
		public DataSet getCatalogList_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql = "Select * from bmmi.PVCatalogView_PVMODX order by warehouse, product";
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvcatalog");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			return dbDataSet;
		}
		//returns all the warehouse in a DataSet
		public DataSet warehouse_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter("select * from bmmi.pvwhmast where status ='C' and territory='V' order by warehouse", dbConnection);
				dbAdapter.Fill(dbDataSet, "pvwhmast");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			return dbDataSet;
		}
		

		//returns all the supplier list from cs3 in a DataSet
		public DataSet getCS3Supplier_DS(string warehouse)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_getSupplierByWarehouse";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbAdapter.Fill(dbDataSet, "pvcs3mast");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			return dbDataSet;
		}




		// Function to take a backup before do modification
		public string stockmBackup()
		{
			string strError = "";
			string warehouse = Utilities.Warehouse();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_StockmBackup";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;  

 			OleDbParameter param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);
			
			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				strError = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return strError;
		}


		public string catCurrRecreate()
		{
			string strError = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_reCreateCatCurr";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				strError = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return strError;
		}

		//returns all the warehouse in a DataSet
		public DataSet getMismatchCount_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter("select distinct productCode from PVCATMISMATCH", dbConnection);
				dbAdapter.Fill(dbDataSet, "pvCatalogAnalyse");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			return dbDataSet;
		}

		public DataSet catalogAnalyse_DS()
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_getcatalogview";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			//OleDbParameter param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			//param1.Value = warehouse.Trim();
			//param1.Direction = ParameterDirection.Input;
			//dbCommand.Parameters.Add(param1);
			
			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				//dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "pvCatalogAnalyse");
				OleDbCommandBuilder objBldr = new OleDbCommandBuilder(dbAdapter);
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				//dbConnection.Close();
			}
			
			return dbDataSet;
		}


		public string updateCatalogMismatch(string warehouse)
		{
			// DataSet dbDataSet = new DataSet();
			string errMessage="";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_updateCatalogMismatch";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);
			
			try
			{
				//OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				//dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
				//dbAdapter.Fill(dbDataSet, "pvCatalogAnalyse");
				//OleDbCommandBuilder objBldr = new OleDbCommandBuilder(dbAdapter);
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			
			return errMessage;
		}

		// Function will do catalog updation
		public string ProcessCatalogUpdation(DataGrid dgResults)
		{
			string retVal="", warehouse, product;

			// Take a backup before do any modification.
			try
			{
				retVal = stockmBackup();
				if (retVal.Length > 0)
				{
					retVal = "Backup failed due to : " + retVal;
					this.result = retVal;
					throw new DBLayerException(this.result);
				}
				
				foreach(DataGridItem dgItem in dgResults.Items)
				{
					warehouse = dgItem.Cells[0].Text.ToString();
					product = dgItem.Cells[1].Text.ToString();
					CheckBox SendThis=(CheckBox) dgItem.FindControl("SendThis");
					// if check box is checked call force update procedure directly
					if(SendThis.Checked)
					{
						// Call direct Insert
						retVal = catalogForce2Insert(warehouse, product);
						if(retVal.Length > 0)
						{
							retVal = "Process terminated due to : " + retVal + " for the following product : " + warehouse + "-" + product;
							string errRolebackMsg = catalogRollback();
							if (errRolebackMsg.Length > 0) retVal = retVal + ", " + errRolebackMsg;
							this.result = retVal;
							throw new DBLayerException(this.result);
						}
					} 
					else
					{
						// call routing procedure..
						retVal = catalogUpdate(warehouse, product);
						if(retVal.Length > 0)
						{
							retVal = "Process terminated due to : " + retVal + " for the following product : " + warehouse + "-" + product;
							string errRolebackMsg = catalogRollback();
							if (errRolebackMsg.Length > 0) retVal = retVal + ", " + errRolebackMsg;
							this.result = retVal;
							throw new DBLayerException(this.result);
						}
					}
				}
				// call catalog recreation procedure.
				retVal = catCurrRecreate();

				if(retVal.Length > 0)
				{
					retVal = "Catalog recreation error due to : " + retVal;
					string errRolebackMsg = catalogRollback();
					if (errRolebackMsg.Length > 0) retVal = retVal + ", " + errRolebackMsg;
					this.result = retVal;
					throw new DBLayerException(this.result);
				}

				// call catAnalysis truncate function to truncate catalog Analysis from the bubble table.
				retVal = catAnalysisTruncate();

				if(retVal.Length > 0)
				{
					retVal = "Catalog Analysis truncate error due to : " + retVal;
					string errRolebackMsg = catalogRollback();
					if (errRolebackMsg.Length > 0) retVal = retVal + ", " + errRolebackMsg;
					this.result = retVal;
					throw new DBLayerException(this.result);
				}
			}
			catch (Exception ex)
			{
				retVal = ex.Message;
			}
			
			return retVal;
		}


		// Function inserts catalog by warehouse and product
		public string catalogForce2Insert(string warehouse, string product)
		{
			string strError = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_insertPVCatalog";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_product", OleDbType.Char, 20);
			param2 = new OleDbParameter("i_product", OleDbType.Char, 20);
			param2.Value = product.Trim();
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);

			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
				
			}
			catch (Exception ex)
			{
				strError = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			return strError;

		}

		
		// Function updates catalog with values from cs3, by warehouse and product
		// Procudure to validate 832 fields.  
		// If changes found it start insert a new record in PV, the latest record from cs3. 
		// If not it start updates
		public string catalogUpdate(string warehouse, string product)
		{
			string strError = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_updateCatalog";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_product", OleDbType.Char, 20);
			param2 = new OleDbParameter("i_product", OleDbType.Char, 20);
			param2.Value = product.Trim();
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);

			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
				
			}
			catch (Exception ex)
			{
				strError = ex.Message;

			}
			finally
			{
				dbConnection.Close();
			}
			return strError;

		}


		public string catalogRollback()
		{
			string strError="";
			string warehouse = Utilities.Warehouse();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_catalogRollback";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;  

			OleDbParameter param1 = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);
			
			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				strError = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return strError;
			
		}

		private string catAnalysisTruncate()
		{
			string strError="";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_catalogAnalyseTruncate";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;  

			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				strError = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return strError;
			
		}

		public string updateRemarks(string remType, string remName, string remId, string remarks)
		{
			string strError = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_RemarksUpdate";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_remtype",OleDbType.Decimal, 57);
			param1.IsNullable = true;
			if (remType.Trim().Length > 0)
			{
				param1.Value = remType.Trim();
			}
			else
			{
				param1.Value = System.DBNull.Value;
			}
			//param1.Value = remType.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_remName",OleDbType.Char, 40);
			param2.IsNullable = true;
			if (remName.Trim().Length > 0)
			{
				param2.Value = remName.Trim();
			}
			else
			{
				param2.Value = System.DBNull.Value;
			}
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2); 			
			

			OleDbParameter param3 = new OleDbParameter("i_remID",OleDbType.Decimal, 57);
			param3.IsNullable = true;
			if (remId.Trim().Length > 0)
			{
				param3.Value = remId.Trim();
			}
			else
			{
				param3.Value = System.DBNull.Value;
			}			
			//param3.Value = remId.Trim();
			param3.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param3);


			OleDbParameter param4 = new OleDbParameter("i_remarks",OleDbType.Char, 40);
			param4.IsNullable = true;
			if (remarks.Trim().Length > 0)
			{
				param4.Value = remarks.Trim();
			}
			else
			{
				param4.Value = System.DBNull.Value;
			}			
			//param4.Value = remarks.Trim();
			param4.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param4);

			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
				
			}
			catch (Exception ex)
			{
				strError = ex.Message;

			}
			finally
			{
				dbConnection.Close();
			}
			return strError;

		}



		// Returns all the products filtered by Date
		public DataSet getProductListByDate_DS(string warehouse)
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_getProductListByDate";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param.Value = warehouse.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);


			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblProducts");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();	
			}
			return dbDataSet;
		}



		// returns all FTP Transaction list in a DataSet
		public DataSet getFTPTransaction_DS(string txnType, string flag)
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_getFTPList";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_txn", OleDbType.Char, 5);
			param.Value = txnType.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);

			OleDbParameter param1 = new OleDbParameter("i_flag", OleDbType.Double, 57);
			param1.Value = flag.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "FTPList");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			return dbDataSet;
		}



		// returns all ASN ETA list in a DataSet
		public DataSet getASNETA_DS()
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_getASNETA";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;
			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "pvasneta");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			return dbDataSet;
		}



		// updates changed ETA.
		public string updateASNETA(string asnNo, string etaDate)
		{
			string errMessage = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_ASNETAUpdate";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_asnNo",OleDbType.Char, 20);
			param.Value = asnNo.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);

			OleDbParameter param1 = new OleDbParameter("i_etaDate",OleDbType.Date, 20);
			param1.Value = etaDate.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			return errMessage;		
		}


		
		// returns all substitutions in a DataSet by order#
		public DataSet getNISSubReport_DS(string order_no)
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmifsv.pv_usp_NISListRpt";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_orderNo",OleDbType.Char, 10);
			param1.Value = order_no.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "pvnisdetl");
				OleDbCommandBuilder objBldr = new OleDbCommandBuilder(dbAdapter);
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			return dbDataSet;
		}
		
		
		
		// Add a New Supplier.
		public int addSupplier(string vendorCode, string vendorType, string vendorName, string vendorDispName, string leadTime, string leadTimeVar, string spAccuracy, string etaAccuracy, string vendRemarks, string vendContact, string vendContactFax)
		{
			int retErr = 0;
			OleDbConnection dbConn=new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction supplierTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = supplierTrans;
			
			try
			{
				string strSql = "INSERT INTO bmmi.pvsupmast (VENDOR_ID, VENDOR_CODE, VENDOR_TYPE,VENDOR_NAME, VENDOR_DISPNAME, LEAD_TIME,LEAD_TIME_VAR, SHP_PLAN_ACCURACY, ETA_ACCURACY, STATUS, REMARKS, VENDOR_CONTACT,VENDOR_FAX) " +
					"select MAX(vendor_id) + 1,'" + vendorCode + "','" + vendorType + "','" +  vendorName + "','" + vendorDispName + "'," + leadTime + "," + leadTimeVar + "," + spAccuracy + "," + etaAccuracy + ",'" + "O" + "','" + vendRemarks + "','" + vendContact + "','" + vendContactFax + "' from bmmi.pvsupmast where vendor_code <>'" + vendorCode + "'";

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery(); 
				supplierTrans.Commit();
			}
			catch (Exception ex)
			{
				supplierTrans.Rollback();
				string errMessage = ex.Message;
				
			}	
			finally
			{
				dbConn.Close();
			}

			return retErr;
		}

		
		
		//allows you to update a selected Supplier.
		public int updateSupplier(string vendID, string vendDispName, string vendLeadTime, string vendLeadTimeVar, string vendSPAccuracy, string vendETAAccuracy, string vendStatus, string vendRemarks, string contact, string contactFax)
		{
			int retErr = 0;
			OleDbConnection dbConn = new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction supplierTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = supplierTrans;

			try
			{
				string strSql = "Update bmmi.pvsupmast  Set Vendor_DispName='" + vendDispName + "', " +  
					"Lead_Time=" + vendLeadTime + ",  Lead_Time_Var=" + vendLeadTimeVar + ", " + 
					"Shp_Plan_Accuracy=" + vendSPAccuracy + ",  ETA_Accuracy=" + vendETAAccuracy + ", " + 
					"Status='" + vendStatus + "', Remarks='" + vendRemarks + "', " + 
					"Vendor_Contact='" + contact + "', Vendor_Fax='" + contactFax + "' " + 
					"Where Vendor_Id =" + vendID;

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				supplierTrans.Commit();
			}
			catch (Exception ex)
			{
				supplierTrans.Rollback();
				string errorMsg = ex.Message;
				
			}

			finally
			{
				dbConn.Close();
			}

			return retErr;
		}

		
		
		//returns all the order details in a DataSet based on the criteria
		public DataSet getOrderDetail_DS(string orderNo, string warehouse, string product, string backOrder)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "pv_usp_orderDetail";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_orderNo",OleDbType.Char, 10);
			param1.Value = orderNo.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

				
			OleDbParameter parm2 =new OleDbParameter("i_warehouse",OleDbType.Char, 2) ; 
			parm2.IsNullable = true;
			if (warehouse.Trim().Length > 0)
			{
				parm2.Value = warehouse.Trim();
			}
			else
			{
				parm2.Value = System.DBNull.Value;
			}
			parm2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(parm2); 



			OleDbParameter parm3 =new OleDbParameter("i_product",OleDbType.Char, 20) ; 
			parm3.IsNullable = true;
			if (product.Trim().Length > 0)
			{
				parm3.Value = product.Trim();
			}
			else
			{
				parm3.Value = System.DBNull.Value;
			}
			parm3.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(parm3); 


			OleDbParameter parm4 =new OleDbParameter("i_backorder",OleDbType.Char) ; 
			parm4.IsNullable = true;
			if (backOrder.Trim().Length > 0)
			{
				parm4.Value = backOrder.Trim();
			}
			else
			{
				parm4.Value = System.DBNull.Value;
			}
			parm4.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(parm4); 


			try
			{

				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblOrderDetail");


			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				
			}

			finally
			{
				dbConnection.Close();
			}

			return dbDataSet;
		}

		
		
		// returns all the supplier list and supplier cost by product and supplier id in a DataSet
		public DataSet getSupplierCost_DS(string warehouse, string product, string vendorID)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "pv_usp_getSupplierCost";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			
			OleDbParameter parm1 =new OleDbParameter("i_warehouse",OleDbType.Char, 2) ; 
			parm1.IsNullable = true;
			if (warehouse.Trim().Length > 0)
			{
				parm1.Value = warehouse.Trim();
			}
			else
			{
				parm1.Value = System.DBNull.Value;
			}
			parm1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(parm1); 



			OleDbParameter parm2 =new OleDbParameter("i_product",OleDbType.Char, 20) ; 
			parm2.IsNullable = true;
			if (product.Trim().Length > 0)
			{
				parm2.Value = product.Trim();
			}
			else
			{
				parm2.Value = System.DBNull.Value;
			}
			parm2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(parm2); 


			OleDbParameter parm3 =new OleDbParameter("i_VendorID",OleDbType.Char) ; 
			parm3.IsNullable = true;
			if (vendorID.Trim().Length > 0)
			{
				parm3.Value = vendorID.Trim();
			}
			else
			{
				parm3.Value = System.DBNull.Value;
			}
			parm3.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(parm3); 


			try
			{

				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblSupplierCost");


			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				
			}

			finally
			{
				dbConnection.Close();
			}

			return dbDataSet;
		}

		
		
		//returns all the product details in a DataSet based on the order criteria
		public DataSet getLPODetail_DS(string orderNo)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "pv_usp_LPODetail";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_orderNo",OleDbType.Char, 10);
			param1.Value = orderNo.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblLPODetail");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return dbDataSet;
		}
		
		
		
		//returns all the supplier in a DataSet based on the order criteria
		public DataSet getLPOSupplier_DS(string orderNo)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "pv_usp_getLPOSupplier";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_orderNo",OleDbType.Char, 10);
			param1.Value = orderNo.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblLPOSupplier");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return dbDataSet;
		}

		
		
		//returns generated LPO based on the order # and supplier criteria
		public DataSet getLPOGen_DS(string orderNo, string vendorID)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_LPOGeneration";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_orderNo",OleDbType.Char, 10);
			param1.Value = orderNo.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_vendorID",OleDbType.VarChar, 25);
			param2.Value = vendorID.Trim();
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);

			try
			{
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
				dbAdapter.SelectCommand = dbCommand;
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblLPOGen");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return dbDataSet;
		}

		
		
		// This funciton updates the FTP status. 
		public string updateFTPStatus(string status, string inFile,string trxn, string flag)
		{
			string errMessage = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand= new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_updateFTPStatus";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_status", OleDbType.Char, 20);
			param.Value = status.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);

			OleDbParameter param1 = new OleDbParameter("i_infile", OleDbType.Char, 20);
			param1.Value = inFile.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_infile", OleDbType.Char, 5);
			param2.Value = trxn.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);


			OleDbParameter param3 = new OleDbParameter("i_flag", OleDbType.Double, 57);
			param3.Value = flag.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param3);


			
			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
				this.result = ex.Message;
				throw new DBLayerException(this.result);
			}
			finally
			{
				dbConnection.Close();
			}

			return errMessage;
		}

		
		
		// This funciton updates printcount against vendor
		public string updatePrintCount(string orderNo, string vendorList)
		{
			string errMessage = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand= new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_updateLPOPrint";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_orderNo", OleDbType.Char, 20);
			param.Value = orderNo.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);

			OleDbParameter param1 = new OleDbParameter("i_vendorID", OleDbType.Double, 57);
			param1.Value = vendorList.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);
			
			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return errMessage;
		}

		
		
		// updates the supplier.
		public string updateSupplierCost(string orderNo, string warehouse, string product, string strCost, string strSuggQty, string vendorID)
		{
			string errMessage ="";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmi.pv_usp_updateSupplierCost";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_orderNo",OleDbType.Char, 20);
			param.Value = orderNo.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);

			OleDbParameter param1 = new OleDbParameter("i_warehouse",OleDbType.Char, 2);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_product",OleDbType.Char, 20);
			param2.Value = product.Trim();
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);

			OleDbParameter param3 = new OleDbParameter("i_bmmiCost",OleDbType.Double, 57);
			param3.Value = strCost.Trim();
			param3.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param3);

			OleDbParameter param4 = new OleDbParameter("i_suggQty",OleDbType.Char, 2);
			param4.Value = strSuggQty.Trim();
			param4.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param4);

			OleDbParameter param5 = new OleDbParameter("i_vendorID",OleDbType.Double, 57);
			param5.Value = vendorID.Trim();
			param5.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param5);

			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}

			return errMessage;
		}

		
		
		//returns all the order list in a DataSet based on the order no.
		public DataSet orderList_DS(string orderNo)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "pv_usp_orderList";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_orderNo",OleDbType.Char, 10);
			param1.Value = orderNo.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
			dbAdapter.SelectCommand = dbCommand;
			try
			{
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblOrder");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				
			}
			finally
			{
				dbConnection.Close();
			}

				
			return dbDataSet;

		}

		
		
		//returns all the products in a DataSet
		public DataSet Products_DS(string orderNo)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql = "Select warehouse || product as ProdName from bmmifsv.opdetm where order_no='"+orderNo.Trim() + "'" + "order by warehouse asc, product asc";
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "tblProducts");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		// returns all order list in a DataSet based on the warehouse and product
		public DataSet getOrderDetail_DS(string warehouse, string product)
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "pv_usp_orderDetail_Status";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param1 = new OleDbParameter("i_warehouse",OleDbType.Char, 2);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_product",OleDbType.Char, 20);
			param2.Value = product.Trim();
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);

			OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
			dbAdapter.SelectCommand = dbCommand;
			try
			{
				dbConnection.Open();
				dbAdapter.Fill(dbDataSet, "tblOrderDetail");

			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				
			}
			finally
			{
				dbConnection.Close();
			}
			return dbDataSet;
		}

		
		
		// returns all substitutions list in a dataset
		public DataSet getSubstitution_DS(string orderNo, string warehouse, string product)
		{
			DataSet dbDataSet = new DataSet();

			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmifsv.pv_usp_NISSub"; // pv_usp_NISSubstitutions";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_orderNo",OleDbType.Char, 20);
			param.Value = orderNo.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);

			OleDbParameter param1 = new OleDbParameter("i_warehouse",OleDbType.Char, 2);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_product",OleDbType.Char, 20);
			param2.Value = product.Trim();
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);

			OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
			dbAdapter.SelectCommand = dbCommand;
			try
			{
				dbConnection.Open();

				dbAdapter.Fill(dbDataSet, "tblNISSub");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
						
			}
			finally
			{
				dbConnection.Close();
			}

			return dbDataSet;
	
		}

		
		
		// returns offered qty updated status in a string. 
		public string updateSubstitution(string orderNo, string warehouse, string product, string offeredQty, string mainWH, string mainProduct)
		{
			string errMessage = "";
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbCommand dbCommand = new OleDbCommand();
			dbCommand.CommandText = "bmmifsv.pv_usp_NISSubUpdate";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConnection;

			OleDbParameter param = new OleDbParameter("i_orderNo",OleDbType.Char, 20);
			param.Value = orderNo.Trim();
			param.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param);

			OleDbParameter param1 = new OleDbParameter("i_warehouse",OleDbType.Char, 2);
			param1.Value = warehouse.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			OleDbParameter param2 = new OleDbParameter("i_product",OleDbType.Char, 20);
			param2.Value = product.Trim();
			param2.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param2);

			OleDbParameter param3 = new OleDbParameter("i_offer_qty",OleDbType.Double, 57);
			param3.Value = offeredQty.Trim();
			param3.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param3);

			OleDbParameter param4 = new OleDbParameter("i_Main_wh",OleDbType.Char, 2);
			param4.Value = mainWH.Trim();
			param4.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param4);

			OleDbParameter param5 = new OleDbParameter("i_Main_Prod",OleDbType.Char, 20);
			param5.Value = mainProduct.Trim();
			param5.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param5);


			try
			{
				dbConnection.Open();
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
			}
			finally
			{
				dbConnection.Close();
			}
			return errMessage;		
		}

		
		
		// returns product details in a DataSet
		public DataSet getProductList_DS()
		{
			DataSet dbDataSet = new DataSet();
			string connStr = "Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql = "Select warehouse || product as products, dscp_desc from bmmi.pvcatcurr order by dscp_desc";
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql,dbConnection);
				dbAdapter.Fill(dbDataSet, "tblProductList");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			return dbDataSet;
		}

		
		
		// returns product details in a DataSet based on the warehouse and product
		public DataSet getProductList_DS(string warehouse, string product)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql = "Select * from bmmi.pvcatcurr where warehouse='"+warehouse+"' and product='"+ product + "'";
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql,dbConnection);
				dbAdapter.Fill(dbDataSet, "tblProductList");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				
			}
			return dbDataSet;
		}

		
		
		public DataSet getPVPAnalysis_DS(string warehouseList, string supplierList, string conditionType, string strNSN)
		{
			DataSet dbDataSet = new DataSet();	

			string strSql = "select distinct a.product, a.dscp_desc,a.stock_number, a.purchase_unit, a.warehouse from pvcatcurr a, pvsupcscurr b where ";
			bool opApplied=false;
			
			//opApplied=true;
			//strSql+="  (a.warehouse not like '%Z') ";

			if(strNSN.Length>0)
			{
				if(opApplied)
					strSql+=" "+conditionType;


				opApplied=true;
				strSql+=" (a.stock_number='"+strNSN+"') ";
			}
			

			if(opApplied)
			{
				strSql+=" "+conditionType;
			}
			opApplied=true;
			strSql+=" (a.warehouse not like '%Z') ";


			if(warehouseList.Length>0)
			{
				if(opApplied)
					strSql+=" "+conditionType;


				opApplied=true;
				strSql+=" (a.warehouse in ("+warehouseList+")) ";
			}
			
			if(opApplied)
			{
				strSql+=" "+conditionType;
			}
			opApplied=true;
			strSql+=" (a.stock_number=b.nsn) ";

			if(supplierList.Length>0)
			{
				if(opApplied)
					strSql+=" "+conditionType;


				opApplied=true;
				strSql+=" (B.vendor_id in ("+supplierList+")) ";
			}


			//if(opApplied)
			//	strSql+=" "+conditionType;

			strSql+=" order by 5,3";
			
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql,dbConnection);
				dbAdapter.Fill(dbDataSet, "tblPVAnalysis");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;

		}

		
		
		// returns list of P-A selected stocknumber in a DataSet
		public DataSet getPVPAnalysis_DS(string strNSN, string strSupplier, string strSuppName)
		{
			DataSet dbDataSet = new DataSet();
			//strNSN = "asd";

			//strSupplier = "asdf";

			string strSql = "SELECT distinct a.product, A.NSN, c.DSCP_desc, c.purchase_unit, ";

			string [] supplierList=strSupplier.Replace("'", "").Replace(",", "±").Split('±');
			string [] supplierName=strSuppName.Replace("'", "").Replace(",", "±").Split('±');
			//bool flag=false;
			int i = 0;

			foreach(string supplier in supplierList)
			{
				strSql+=" nvl((SELECT B.BMMI_DIST_FEE FROM PVSUPCSCURR B WHERE VENDOR_ID="+supplier+" AND B.NSN=A.NSN),0) "+supplierName[i++] + ",";
			}
			// sqlStm+=") ";
			strSql = strSql.Remove(strSql.Length-1, 1).ToString();	
			strSql+=" FROM PVSUPCSCURR A, pvcatcurr c WHERE a.nsn IN ("+strNSN+") AND a.VENDOR_ID IN ("+strSupplier+") AND A.NSN = c.Stock_Number";

			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql,dbConnection);
				dbAdapter.Fill(dbDataSet, "tblPVAnalysis");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}

			return dbDataSet;
		}


		/// <summary>
		///	Return the dataset to populate the product grid
		///	If "all products" are selected return the dataset with all products.
		/// if "warehouse" selected return the dataset with all products in Selected warehouse.
		/// if "supplier" selected return the dataset with all products the selected supplier provides.																					 
		/// </summary>
		/// <param name="warehouse"></param>
		/// <param name="supplier"></param>
		/// <returns>Dataset containing products according to criteria</returns>
		
		public DataSet PAbindproducts_DS(string warehouse,string supplier)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();

				if(warehouse.Length ==0 && supplier.Length ==0)
				{
					sbConn.Append(" select A.PRODUCT,A.DSCP_DESC,A.STOCK_NUMBER,A.PURCHASE_UNIT, " );
					sbConn.Append(" A.WAREHOUSE from PVCATCURR A  WHERE A.WAREHOUSE NOT LIKE '%Z'  " );
					sbConn.Append(" order by 5,3 " );
				}

				if(warehouse.Length >0 && supplier.Length ==0)
				{
					sbConn.Append(" select A.PRODUCT,A.DSCP_DESC,A.STOCK_NUMBER,A.PURCHASE_UNIT, " );
					sbConn.Append(" A.WAREHOUSE from PVCATCURR A where trim(A.WAREHOUSE)=trim('"+warehouse+"')" );
					sbConn.Append(" order by 5,3 " );
				}
				if( supplier.Length >0 && warehouse.Length ==0 )
				{
					sbConn.Append(" select A.PRODUCT,A.DSCP_DESC,A.STOCK_NUMBER,A.PURCHASE_UNIT, " );
					sbConn.Append(" A.WAREHOUSE from PVCATCURR A,PVSUPCSCURR B where A.STOCK_NUMBER=B.NSN " );
					sbConn.Append(" AND trim(B.vendor_id)=trim('"+supplier+"') AND A.WAREHOUSE NOT LIKE '%Z' order by 5,3" );
				}

				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "products");
			}
			catch 
			{
						
			}
			return dbDataSet;
		}
		


		/// <summary>
		///	 When User enters from and to date of an ASN upload,
		///	 all ASN header details in that date range are displayed
		///  in a grid.A link is provided with each record clicking which
		///  displays the particular asn details in crystal reports
		/// </summary>
		/// <param name="fromdate"></param>
		/// <param name="todate"></param>
		/// <returns>the dataset to populate the ASN datagrid.</returns>
		public DataSet viewasn_DS(string fromdate,string todate)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql= " select to_char(A.ASN_DATE,'dd-mon-rr') ASN_DATE,B.TCN_NO,A.CNTR_NO,A.CNTR_TYPE,A.VESSEL,A.PORT_DISP,A.PORT_ARRV,"+
					" to_char(A.SAIL_DATE,'dd-mon-rr') as SAIL_DATE,to_char(A.ETA,'dd-mon-rr') as ETA,A.INV_NO,to_char(A.INV_DATE,'dd-mon-rr') as INV_DATE,A.ASN_NO " +
					" from pvasnhead A,PVASNSTAT B where A.ASN_DATE between '"+fromdate+"' and '"+ todate+"'" +
					" AND A.ASN_NO=B.ASN_NO ORDER BY ASN_DATE ";
			
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvasn");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;
		}



		/// <summary>
		/// Returns the dataset to populate the cost datagrid.
		/// When User enters from and to date of a cost upload, 
		/// all vendorname,vendorcode,and uploaded date in that date range are displayed 
		/// in a grid.A link provided with each record displays
		/// that particular cost details in crystal reports.
		/// </summary>
		public DataSet viewCost_DS(string fromdate,string todate)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				string strSql= " select distinct B.vendor_id,B.vendor_code,B.vendor_name, to_char(A.update_date,'dd-Mon-rrrr') as update_date from pvsupcost A,pvsupmast B " +
					" where a.vendor_id=b.vendor_id and a.update_date between '"+fromdate+"' and '"+ todate+"'";
			
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvcost");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;
		}


		public DataSet viewShplan_DS(string fromdate,string todate)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
		
				string strSql= " select A.VENDOR_ID,B.VENDOR_DISPNAME,A.SHPLANNO,to_char(A.SHPLANDATE,'dd-mon-rrrr') as SHPLANDATE "+
					" from PVSHPLANHEAD A,PVSUPMAST B where A.VENDOR_ID=B.VENDOR_ID AND A.SHPLANDATE between '"+fromdate+"' and '"+ todate+"'"; 
			
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "Shplan");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;
		}

		public DataSet viewPA(string fromdate,string todate)
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
		
				string strSql= " select POPLANNO,to_char(POPLANDATE,'dd-Mon-rrrr') as POPLANDATE,VENDORS_ANALYSED,ANALYSISBY"+
					" from PVPAHEAD where POPLANDATE between '"+fromdate+"' and '"+ todate+"'"; 
			
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "PA");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;
		}


		/// <summary>
		/// Used to poplulate the crystal report for viewing 
		/// and deleting cost records for a particular   
		/// supplier and for a particular updatedate
		/// </summary>
		public DataSet getcostDetails_DS(string vendorid,string updatedate)
		{
			DataSet dbDataSet = new DataSet();

			string strSql=" select b.stock_number,A.purch_unit,C.vendor_name,A.mfg_cost,A.napa,A.vendor_dist_fee,A.bmmi_cost,B.dscp_desc" + 
				" from pvsupcost A,pvcatcurr B,pvsupmast C where  A.nsn=B.stock_number and  A.vendor_id="+vendorid+
				" and a.vendor_id=C.vendor_id and trunc(A.update_date)=to_date('"+updatedate+"','dd-Mon-rrrr')";// and B.WAREHOUSE NOT LIKE '%Z'";

			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "cost");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;
		}



		
		public DataSet getShplanDetails_DS(string shplanno)
		{
			DataSet dbDataSet = new DataSet();

			string strSql=	" select SHPLANNO,to_char(PLANDATE,'dd-mon-rrrr') as PLANDATE,PO_NO,NSN,WAREHOUSE,PRODUCT,PURCH_UNIT,PLAN_QTY "+
				" from PVSHPLANDETL where SHPLANNO='"+shplanno+"' ";
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "shplan");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;

			}
			return dbDataSet;
		}


		/// <summary>
		/// Returns a dataset populated with all warehouses.
		/// </summary>
		public DataSet PAwarehouse_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				
				string conn=" SELECT DISTINCT WAREHOUSE FROM PVCATCURR WHERE WAREHOUSE NOT LIKE '%Z' ORDER BY WAREHOUSE ";
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "tblwareHouse");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}



		/// <summary>
		///Returns a dataset populated with all suppliers of type A.
		///The supplier code and displaynames are returned together
		///to be displayed in a combo box 
		/// </summary>
		public DataSet PAsupplier_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				string conn=" SELECT DISTINCT vendor_id,vendor_code||'-'||vendor_dispname as vendor  FROM pvsupmast WHERE VENDOR_TYPE='A' ";
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "tblSupplier");
			}
			catch
			{
			}
			return dbDataSet;
		}


		
		/// <summary>
		/// Returns a dataset populated with all suppliers of type A.
		/// Used to display the supplier names in a table 
		/// </summary>
		public DataSet PAsuppliergrid_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				string conn=" SELECT DISTINCT vendor_id,vendor_dispname as vendor  FROM pvsupmast WHERE VENDOR_TYPE='A' ";
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "tblSuppliergrid");
			}
			catch
			{
			}
			return dbDataSet;
		}


		/// <summary>
		/// returns all records from PALETCNTR table
		/// </summary>
		/// <returns>returns all records from PALETCNTR table</returns>
		public DataSet pallette_DS()
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbDataAdapter dbAdapter = new OleDbDataAdapter("select * from bmmi.pvpaletcntr", dbConnection);
			dbAdapter.Fill(dbDataSet, "pvpaletcntr");
			return dbDataSet;
		}


		
		/// <summary>
		/// Adds a New Pallette in PVPALETCNTR table.
		/// </summary>
		/// <param name="PalletteType"></param>
		/// <param name="DodaacSpl"></param>
		/// <param name="CntrSize"></param>
		/// <param name="CntrType"></param>
		/// <param name="MaxPallettes"></param>
		/// <param name="status"></param>
		/// <returns>The error number</returns>
		public int addpallette(string PalletteType, string DodaacSpl, int CntrSize, string CntrType, int MaxPallettes, string status)
		{
			int retErr = 0;
			string strSql ="";
			OleDbConnection dbConn=new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction palletteTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = palletteTrans;

			try
			{
				strSql ="INSERT INTO bmmi.PVPALETCNTR (PALCNTR_ID,PALLET_TYPE, DODAAC_SPECIAL,"+
					" CNTR_SIZE,CNTR_TYPE, MAX_PALLETS,STATUS) " +
					"select MAX(palcntr_id)+ 1 " + ",'" + PalletteType + "','" + DodaacSpl + "'," + 
					CntrSize + ",'" + CntrType + "'," + MaxPallettes + ",'" + status + "'"+
					" from bmmi.PVPALETCNTR";

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery(); 
				palletteTrans.Commit();
			}
			catch (Exception ex)
			{
				string error=ex.Message ;
				palletteTrans.Rollback();				
			}	
			finally
			{
				dbConn.Close();
			}

			return retErr;
		}

		
		/// <summary>
		/// used  to update a selected Pallette from PVPALETCNTR.
		/// </summary>
		/// <param name="palcntrid"></param>
		/// <param name="PalletteType"></param>
		/// <param name="DodaacSpl"></param>
		/// <param name="CntrSize"></param>
		/// <param name="CntrType"></param>
		/// <param name="MaxPallettes"></param>
		/// <param name="status"></param>
		/// <returns>The error number</returns>
		public int updatePallette(int palcntrid,string PalletteType, string DodaacSpl, string CntrSize, string CntrType, string MaxPallettes, string status)
		{
			int retErr = 0;
			OleDbConnection dbConn = new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction PalletteTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = PalletteTrans;
	
			try
			{
				string strSql = " Update bmmi.PVPALETCNTR " +
					" Set PALLET_TYPE ='" + PalletteType + "'," +  
					" DODAAC_SPECIAL  ='"  + DodaacSpl    + "'," + 
					" CNTR_SIZE ="  + CntrSize   + ","  + 
					" CNTR_TYPE ='"+ CntrType   + "',"  + 
					" MAX_PALLETS =" + MaxPallettes + ","  + 
					" STATUS ='"+ status   + "' "  +
					" Where  palcntr_id ="  + palcntrid;
				
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				PalletteTrans.Commit();
			}
			catch (Exception ex)
			{
				PalletteTrans.Rollback();
				string errorMsg = ex.Message;
			}

			finally
			{
				dbConn.Close();
			}

			return retErr;
		}

		
		
		/// <summary>
		///  returns all records from CASEPALET table
		/// </summary>
		/// <returns>Dataset containing all records from CASEPALET table</returns>
		public DataSet case_DS()
		{
			DataSet dbDataSet = new DataSet();
			OleDbConnection dbConnection = new OleDbConnection(connStr);
			OleDbDataAdapter dbAdapter = new OleDbDataAdapter("select * from bmmi.pvcasepalet", dbConnection);
			dbAdapter.Fill(dbDataSet, "pvcasepalet");
			return dbDataSet;
		}



		
		/// <summary>
		/// Adds a New Case to PVCASEPALET table.
		/// </summary>
		/// <param name="PalletteType"></param>
		/// <param name="DodaacSpl"></param>
		/// <param name="CntrSize"></param>
		/// <param name="CntrType"></param>
		/// <param name="PalLength"></param>
		/// <param name="PalWidth"></param>
		/// <param name="PalHeight"></param>
		/// <param name="MaxCases"></param>
		/// <param name="status"></param>
		/// <returns>The error number</returns>
		public int addcase(string PalletteType, string DodaacSpl,int CntrSize,string CntrType,int PalLength,int PalWidth,int PalHeight,int MaxCases, string status)
		{
			int retErr = 0;
			string strSql ="";
			OleDbConnection dbConn=new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction CaseTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = CaseTrans;

			try
			{
			
				strSql ="INSERT INTO bmmi.PVCASEPALET (CASPAL_ID,PALLET_TYPE, DODAAC_SPECIAL,"+
					" CNTR_SIZE,CNTR_TYPE,PALLET_LENGTH,PALLET_WIDTH,PALLET_HEIGHT,MAX_CASES,STATUS) " +
					" select NVL(MAX(CASPAL_ID)+1,1) " + ",'" + PalletteType + "','" + DodaacSpl + "'," + 
					CntrSize + ",'" + CntrType + "'," + PalLength+ ","+PalWidth+ ","+
					PalHeight+ ","+MaxCases + ",'" + status + "'"+
					" from bmmi.PVCASEPALET";

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery(); 
				CaseTrans.Commit();
			}
			catch (Exception ex)
			{
				string error=ex.Message ;
				CaseTrans.Rollback();				
			}	
			finally
			{
				dbConn.Close();
			}

			return retErr;
		}

	
		/// <summary>
		/// is used to update a selected case from PVCASEPALET.
		/// </summary>
		/// <param name="caspalid"></param>
		/// <param name="PalletteType"></param>
		/// <param name="DodaacSpl"></param>
		/// <param name="CntrSize"></param>
		/// <param name="CntrType"></param>
		/// <param name="palLength"></param>
		/// <param name="palWidth"></param>
		/// <param name="palHeight"></param>
		/// <param name="MaxCases"></param>
		/// <param name="status"></param>
		/// <returns>The error number </returns>
		public int updateCase(int caspalid,string PalletteType, string DodaacSpl,string CntrSize,string CntrType,string palLength,string palWidth,string palHeight, string MaxCases, string status)
		{
			int retErr = 0;
			OleDbConnection dbConn = new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction CaseTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = CaseTrans;
	
			try
			{
				string strSql = " Update bmmi.PVCASEPALET " +
					" Set PALLET_TYPE ='" + PalletteType + "'," +  
					" DODAAC_SPECIAL  ='"  + DodaacSpl    + "'," + 
					" CNTR_SIZE ="  + CntrSize   + ","  + 
					" CNTR_TYPE ='"+ CntrType   + "',"  + 
					" PALLET_LENGTH ="  +palLength + ","  + 
					" PALLET_WIDTH ="   +palWidth  + ","  + 
					" PALLET_HEIGHT ="  +palHeight + ","  + 
					" MAX_CASES =" + MaxCases + ","  + 
					" STATUS ='"+ status   + "' "  +
					" Where  caspal_id ="  + caspalid;
				
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				CaseTrans.Commit();
			}
			catch (Exception ex)
			{
				CaseTrans.Rollback();
				string errorMsg = ex.Message;
			}

			finally
			{
				dbConn.Close();
			}

			return retErr;
		}


		/// <summary>
		/// is used to return all records from PVPALETDODAC table 
		/// </summary>
		/// <returns>dbDataSet : Dataset Containing all records from PVPALETDODAC</returns>
	
		public DataSet Dodaac_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter("select * from PVPALETDODAC", dbConnection);
				dbAdapter.Fill(dbDataSet, "PVPALETDODAC");
			}
			catch (Exception ex)
			{
				
				string error=ex.Message ;
			}
			return dbDataSet;
		}


		/// <summary>
		/// used to Add a New Dodaac Pallette to PVPALETDODAC.
		/// </summary>
		/// <param name="DodaacName"></param>
		/// <param name="DodaacSpl"></param>
		/// <param name="DodaacDispName"></param>
		/// <param name="Status"></param>
		/// <returns></returns>
		public int addDodaacPallette(string DodaacName, string DodaacSpl, string DodaacDispName, string Status)
		{
			int retErr = 0;
			string strSql ="";
			OleDbConnection dbConn=new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction DodaacPallette = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = DodaacPallette;

			try 
			{
				strSql = " INSERT INTO bmmi.PVPALETDODAC (PALETDODAC_ID,DODAAC,DODAAC_SPECIAL, DISP_NAME,STATUS)"+
					" select NVL(MAX(PALETDODAC_ID)+1,1) " + ",'" + DodaacName + "','" + DodaacSpl + "'," + 
					" '" + DodaacDispName + "','" + Status + "'"+
					" from bmmi.PVPALETDODAC";

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery(); 
				DodaacPallette.Commit();
			}
			catch (Exception ex)
			{
				string error=ex.Message ;
				DodaacPallette.Rollback();				
			}	
			finally
			{
				dbConn.Close();
			}

			return retErr;
		}



		/// <summary>
		/// allows you to update a selected Dodaac Pallette from PVPALETDODAC. 
		/// </summary>
		/// <param name="paletdodacid"></param>
		/// <param name="DodaacName"></param>
		/// <param name="DodaacSpl"></param>
		/// <param name="DodaacDispName"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public int updatePalletteDodaac(int paletdodacid,string DodaacName, string DodaacSpl,string DodaacDispName,string status)
		{
			int retErr = 0;
			OleDbConnection dbConn = new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction PalletteDodaacTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = PalletteDodaacTrans;
	
			try
			{
				string strSql = " Update bmmi.PVPALETDODAC " +
					" Set DODAAC ='" + DodaacName + "'," +  
					" DODAAC_SPECIAL  ='"  + DodaacSpl    + "'," + 
					" DISP_NAME ='"  + DodaacDispName    + "'," + 
					" STATUS ='"+ status   + "' "  +
					" Where  PALETDODAC_ID ="  + paletdodacid;
				
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				PalletteDodaacTrans.Commit();
			}
			catch (Exception ex)
			{
				PalletteDodaacTrans.Rollback();
				string errorMsg = ex.Message;
			}

			finally
			{
				dbConn.Close();
			}

			return retErr;
		}

		
		
	}



	

	public class userDBLayer:db
	{

		public userDBLayer()
		{
		}

		public DataSet getWarehouse()
		{
			DataSet dbDataSet = new DataSet();

			dbCommand.CommandText = "bmmi.pv_usp_getwarehouse";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConn;

			//OleDbParameter param1 = new OleDbParameter("i_userID",OleDbType.Char, 10);
			//param1.Value = userID.Trim();
			//param1.Direction = ParameterDirection.Input;
			//dbCommand.Parameters.Add(param1);

			try
			{
				dbAdapter.SelectCommand = dbCommand;
				// dbConn.Open();
				dbAdapter.Fill(dbDataSet, "pvuserWarehouse");
				// OleDbCommandBuilder objBldr = new OleDbCommandBuilder(dbAdapter);
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				return null;
			}
			finally
			{
				closedBConnection();
			}
			
			
			return dbDataSet;
		}


		public DataSet getGroupList()
		{
			DataSet dbDataSet = new DataSet();
		
			dbCommand.CommandText = "bmmi.pv_usp_getGroupList";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConn;

			try
			{
				dbAdapter.SelectCommand = dbCommand;
				dbAdapter.Fill(dbDataSet, "pvUserGroup");
			}	
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				return null;
			}
			finally
			{
				closedBConnection();
			}
			return dbDataSet;
		}


		public DataSet getWarehouseByUser(string userID)
		{
			DataSet dbDataSet = new DataSet();

			dbCommand.CommandText = "bmmi.pv_usp_getwarehouseByUser";
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.Connection = dbConn;

			OleDbParameter param1 = new OleDbParameter("i_userID",OleDbType.Char, 10);
			param1.Value = userID.Trim();
			param1.Direction = ParameterDirection.Input;
			dbCommand.Parameters.Add(param1);

			try
			{
				dbAdapter.SelectCommand = dbCommand;
				dbAdapter.Fill(dbDataSet, "pvuserWarehouse");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				return null;
			}
			finally
			{
				closedBConnection();
			}
			
			
			return dbDataSet;
		}

		//This function Checks for user login in the database
		public int CheckLogin(string userID, string password)
		{
			int loginStatus=0;
			/*
			 * 0 succeded
			 * 1 incorrect username
			 * 2 incorrect password
			 * 3 account has been disabled
			*/ 


			dbCommand.CommandText="pv_usp_CheckLogin";
			dbCommand.CommandType=CommandType.StoredProcedure;
			dbCommand.Connection=dbConn;

			dbCommand.Parameters.Add("i_userID", userID);

			try
			{
				dataReader = dbCommand.ExecuteReader();

				if(dataReader.Read())
				{
					if(!dataReader["Password"].ToString().Trim().Equals(Utilities.hashPassword(password)))
						loginStatus=2;
					else if(!Convert.ToBoolean(dataReader["Status"]))
						loginStatus=3;
				}

				else
				{
					loginStatus=1;
				}
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
			}
			finally
			{
				closedBConnection();
			}

			return loginStatus;
		}


		//This function allows you to change user's Password
		public string ChangeUserPassword(string userID, string newPwd)
		{
			string errMessage="";
			dbCommand.CommandText="pv_usp_ChangePassword";
			dbCommand.CommandType=CommandType.StoredProcedure;
			dbCommand.Connection=dbConn;
			
			try
			{
				OleDbParameter param1 = new OleDbParameter("i_userID",OleDbType.Char, 10);
				param1.Value = userID.Trim();
				param1.Direction = ParameterDirection.Input;
				dbCommand.Parameters.Add(param1);

				//dbCommand.Parameters.Add("i_userID", userID);
				OleDbParameter param2 = new OleDbParameter("i_userID",OleDbType.Char, 50);
				param2.Value = Utilities.hashPassword(newPwd);
				param2.Direction = ParameterDirection.Input;
				dbCommand.Parameters.Add(param2);

				// dbCommand.Parameters.Add("i_password", Utilities.hashPassword(newPwd));
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
			}
			finally
			{
				closedBConnection();
			}

			return errMessage;
		}


		//This function allows the user to change his/her password
		public int ChangePassword(string oldPwd, string newPwd)
		{
			int changeStatus=0;
			/*
			 * 0 succeded
			 * 1 old password is not correct
			*/ 
			dbCommand.CommandText="pv_usp_CheckLogin";
			dbCommand.CommandType=CommandType.StoredProcedure;
			dbCommand.Connection=dbConn;
			dbCommand.Parameters.Add("i_userID", Utilities.UserName());
			try
			{
				dataReader=dbCommand.ExecuteReader();
			
				dataReader.Read();

				if(dataReader["Password"].ToString().Trim().Equals(Utilities.hashPassword(oldPwd)))
				{
					dataReader.Close();
					closedBConnection();
					dbCommand=new OleDbCommand();
					dbCommand.CommandText="pv_usp_ChangePassword";
					dbCommand.CommandType=CommandType.StoredProcedure;
					dbCommand.Connection=dbConn;

					dbCommand.Parameters.Add("i_userID", Utilities.UserName());
					dbCommand.Parameters.Add("i_password", Utilities.hashPassword(newPwd));
					dbConn.Open();
					dbCommand.ExecuteNonQuery();
				}
				else
				{
					changeStatus=1;
				}

			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				changeStatus = 1;
			}
			finally
			{
				closedBConnection();	
			}

			return changeStatus;
		}


		public string AddNewUser(string userID, string userName, string userPassword, string warehouse, ArrayList pages, bool chkStatus, string email, string groupID)
		{
			string errMessage="", isAdmin="0";
			
			dbCommand.CommandText="pv_usp_AddNewUser";
			dbCommand.CommandType=CommandType.StoredProcedure;
			dbCommand.Connection=dbConn;

			dbCommand.Parameters.Add("i_userID", userID);
			dbCommand.Parameters.Add("i_userName", userName);
			dbCommand.Parameters.Add("i_password", Utilities.hashPassword(userPassword));
			dbCommand.Parameters.Add("i_warehouse", warehouse);
			if (chkStatus) isAdmin = "1";
			dbCommand.Parameters.Add("i_isadmin", isAdmin);
			dbCommand.Parameters.Add("i_email", email);
			dbCommand.Parameters.Add("i_groupID", groupID);
			try
			{
				dbCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
				Trans.Rollback();
			}

			finally
			{
				Trans.Commit();
				closedBConnection();
			}

			return errMessage;
		}

		



	}  // End of userDBLayer




	/// <summary>
	/// all common XL file processing methods defined in xlLayer class.
	/// This class opens an excel connection,checks if a particular sheet exists,
	/// checks for unique values,validate cells in the sheets for correctness.
	/// Functions specific to sheets are defined in inherited classes
	/// </summary>

	public class xlLayer
	{
		
		
		string XLConnStr;
		OleDbCommand XLCommand;
		OleDbConnection XLConn;
		OleDbDataReader XLdataReader;


		
		/// <summary>
		/// connection is made to the file "filepath" when object is created 
		/// </summary>
		/// <param name="filepath"></param>
		public xlLayer(string filepath)
		{
			XLConnStr ="Provider=Microsoft.Jet.OLEDB.4.0;" +
				"Data Source="+filepath+"; Jet OLEDB:Engine Type=5;"+
				"Extended Properties=Excel 8.0;";
			
			XLConn=new OleDbConnection(XLConnStr);
			XLConn.Open(); 
			XLCommand = new OleDbCommand();
			XLCommand.Connection = XLConn;
			
		}



		
		/// <summary>
		/// Check if a sheet by name "sheetname" called by a function exists in the selected file 
		/// </summary>
		/// <param name="sheetname"></param>
		/// <param name="range"></param>
		/// <returns>Error details in a string</returns>
		public string checksheet(string sheetname,string range)
		{
			//Try to select the whole sheet
			try
			{
				XLCommand.CommandText = "SELECT * FROM ["+sheetname+"$"+range+"]";
				XLdataReader = XLCommand.ExecuteReader(CommandBehavior.Default);
					
			}
				// if exception is thrown=>the sheet doesnot exist
			catch(Exception ex)
			{
				string error=ex.Message ;	
				return "Error.The excel file doesnot contain the required [ "+sheetname+" ] sheet ";
					
			}
			finally
			{
				XLCommand.Cancel ();
				
			}
			////
			/// if the sheet is in correct name, then the statement
			/// XLdataReader = XLCommand.ExecuteReader(CommandBehavior.Default);
			/// will succeed.Otherwise it will fail.if succeeded we close the datareader
			////
			if (!XLdataReader.IsClosed)
				XLdataReader.Close ();
			return "";
		}



		/// <summary>
		/// checks if a particular column contain unique values.
		/// </summary>
		/// <param name="sheetname"></param>
		/// <param name="column">column name A,B etc of excel sheet  </param>
		/// <param name="index">the cell number from which checking starts downwards</param>
		/// <returns>Error details in a string</returns>
		public string chkUnique(string sheetname,string column,int index)
		{
			ArrayList chkfiledArray = new ArrayList();
			string errorDetl="";
			// get the first value from the column and store it in "uniqueField" variable
			// To get the value of cell c3,the range is c2:c3 since a header cell is required
			string uniqueField=getExcelValue(sheetname,column+(index-1)+":"+column+(index));
			chkfiledArray.Add (uniqueField);
			
			//loop till a blank cell is encountered in the column being scanned
			while(uniqueField!="")
			{
				index++;
				uniqueField=getExcelValue(sheetname,column+(index-1)+":"+column+(index));
				//if the current value already exists in the ArrayList collect errors and break
				if(chkfiledArray.IndexOf(uniqueField)!=-1)
				{
					errorDetl=sheetname +" cell "+column+(index)+ " value must be unique !";
					break;
				}
					//if the current value doesnot exist in the ArrayList,add it to the ArrayList
				else
				{
					chkfiledArray.Add (uniqueField);
				}
			}
			return errorDetl;
		}

		/// <summary>
		/// checks header records for data inconsistency in an excel file
		/// </summary>
		/// <param name="sheetname"></param>
		/// <param name="headerfields">
		/// All header fields and the nature of errorcheck
		/// is added to the headerfields two dimensional array
		///  </param>
		/// <returns>Error details in a string</returns>
		public string chkxlheaderFields(string sheetname,string[,] headerfields)
		{
			Utilities utl=new Utilities();
			string errorDetl="";
			string fieldname="";
			string range="";
			string validationtype="";
			string cell="";
			string specificvalues="";
			int fieldmaxlength=0;
			
			for(int i=0;i<=headerfields.GetUpperBound(0);i++)
			{
				
				fieldname=headerfields[i,0];
				range=headerfields[i,1];
				cell=range.Substring(range.IndexOf (":")+1);
				validationtype=headerfields[i,2];
				
				if (validationtype.Trim ()=="S")
				{
					specificvalues=headerfields[i,3];
				}
				else
				{
					fieldmaxlength=Convert.ToInt32 (headerfields[i,3]);
				}
				
				switch(validationtype)
				{
					case "L": //validation type L maximum length in a cell
						errorDetl+=utl.checkMaxLength(sheetname,getExcelValue(sheetname,range),fieldname,fieldmaxlength,cell);	
						break;
					case "D"://validation type D checks if the cell value is in date format
						errorDetl+=utl.ValidateDate(getExcelValue(sheetname,range),fieldname,cell);			
						break;
					case "N"://validation type N checks for number format
						errorDetl+=utl.ValidateExcelNumber(sheetname,getExcelValue(sheetname,range),fieldname,cell);	
						break;
					case "S": //validation type S looks for some specific values in a cell
						errorDetl+=utl.ValidateSpecific(getExcelValue(sheetname,range),fieldname,specificvalues,cell);	
						break;
				}

			}
			return errorDetl;
		}

		
		
		
		/// <summary>
		/// checks detail records for data inconsistency in an excel file 
		/// All header fields and the nature of errorcheck 
		/// is added to the headerfields two dimensional array 
		/// </summary>
		/// <param name="sheetname"></param>
		/// <param name="detailfields">All the detail field columns,columnnames and validations are stored</param>
		/// <param name="startindex">the row number from which the details records are entered in the sheet "sheetname"</param>
		/// <param name="emptychkfieldindex"> 
		/// The column which is checked for empty in the detailfields array.
		/// Eg. if NSN is the first element of detailfields array and emptychkfieldindex=0 then
		/// then detail rows are incremented until a blank cell is found in NSN column
		/// </param>
		/// <returns>Error details in a string</returns>
		public string chkxldetailFields(string sheetname,string[,] detailfields,int startindex,int emptychkfieldindex)
		{
		
			Utilities utl=new Utilities();
			string errorDetl="";
			string fieldname="";
			string row="";
			string range="";
			string validationtype="";
			string cell="";
			int fieldmaxlength=0;
			int index=startindex;
			
			
				
			while(getExcelValue(sheetname,detailfields[emptychkfieldindex,1]+(index-1)+":"+detailfields[emptychkfieldindex,1]+(index))!="")
			{
				for(int i=0;i<=detailfields.GetUpperBound(0);i++)
				{
					fieldname=detailfields[i,0];
					row=detailfields[i,1];
					cell=row+index;
					range=row+(index-1)+":"+row+(index);
					validationtype=detailfields[i,2];
					
					if (validationtype.Trim ()!="S")
						fieldmaxlength=Convert.ToInt32 (detailfields[i,3]);
				
					switch(validationtype)
					{
						case "L"://validation type L maximum length in a cell
							errorDetl+=utl.checkMaxLength(sheetname,getExcelValue(sheetname,range),fieldname,fieldmaxlength,cell);	
							break;
						case "D"://validation type D checks if the cell value is in date format
							errorDetl+=utl.ValidateDate(getExcelValue(sheetname,range),fieldname,cell);
							break;
						case "N"://validation type N checks for number format
							errorDetl+=utl.ValidateExcelNumber(sheetname,getExcelValue(sheetname,range),fieldname,cell);	
							break;

					}//end of switch

				}//end of for
				index++;
			}//end of while
			return errorDetl;
		}

		
		
		/// <summary>
		/// gets a paricular cell value from excel sheet ( to get from A2 give A1:A2 as range)
		/// because A1 is considered as header row for A2
		/// </summary>
		/// <param name="sheetname"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		public string getExcelValue(string sheetname,string range)
		{
			string excelvalue="";
			
						
			XLCommand.CommandText = "SELECT * FROM ["+sheetname+"$"+range+"]";
			XLdataReader = XLCommand.ExecuteReader(CommandBehavior.Default);
			
			while (XLdataReader.Read())
			{
				excelvalue = XLdataReader[0].ToString();
			}
			XLdataReader.Close ();
			XLCommand.Cancel();

			return excelvalue.Trim();
		}

		
		
		
		/// <summary>
		/// this close function is used only if there is a datareader opened with an excel connection 
		/// </summary>
		public void closeXLconnection()
		{
			if (!XLdataReader.IsClosed)
				XLdataReader.Close ();
	
			if(Convert.ToString (XLConn.State )!="Closed")
				XLConn.Close();
		
		}

		
		/// <summary>
		/// this close function is used if there is no datareader opened with an excel connection 
		/// </summary>
		public void closeXL()
		{
			if(Convert.ToString (XLConn.State )!="Closed")
				XLConn.Close();
		}

	
	}




	
   
	
	/// <summary>
	/// all common Oracle DB methods stored in db class
	/// A connection is opened when object is created
	/// Transaction committing and rolling back defined.
	/// Module specific classes that uses database functions
	/// inherit from this class
	/// </summary>
	public class db
	{
		protected StringBuilder sbConn;  
		protected OleDbCommand dbCommand;	
		protected OleDbConnection dbConn;
		protected OleDbTransaction Trans;
		protected OleDbDataReader dataReader;
		protected OleDbDataAdapter dbAdapter;
		protected OleDbParameter param1;
		protected OleDbParameter param2;
		protected int retErr;
		protected string connStr;
		public string strSql;

		
		/// <summary>
		/// connection is made when object is created
		/// </summary>
		public db()
		{
			connStr				  = "Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
			dbConn			      = new OleDbConnection(connStr);
			dbConn.Open();
			Trans				  = dbConn.BeginTransaction();
			dbCommand		      = dbConn.CreateCommand();
			dbCommand.Connection  = dbConn;
			dbCommand.Transaction = Trans;
			dbAdapter			  = new OleDbDataAdapter();
			sbConn				  = new StringBuilder();
			param1				  = new OleDbParameter("i_warehouse", OleDbType.Char, 5);
			param2				  = new OleDbParameter("i_product", OleDbType.Char, 20);
			retErr				  = 0;
			strSql				  =	"";
		}

		/// <summary>
		/// generating our own exception if any conditon fails.
		/// </summary>
		public class DBException : Exception
		{
			public DBException(string message) : base(message){}
			public DBException(string message, Exception innerException) : base(message,innerException){}
		}


		/// <summary>
		/// Closes the connection if there is an open db connection
		/// </summary>
		public void closedBConnection()
		{
			if(Convert.ToString (dbConn.State )!="Closed")
				dbConn.Close();
		}


		/// <summary>
		/// commits a database transaction.
		/// If a db object is created a transaction is started.
		/// Only when the user calls this commitTrans function,
		/// The Database Operations are committed
		/// else they are discarded
		/// </summary>
		public void commitTrans()
		{
			Trans.Commit();
		}


		/// <summary>
		/// performs a Rollback database operation.
		/// If a db object is created a transaction is started.
		/// if there is any error in database operation
		/// The user can rollback all database transactions
		/// using rollbackTrans function
		/// </summary>
		public void rollbackTrans()
		{
			Trans.Rollback();
		}

		
		/// <summary>
		/// when a file is uploaded the file details are stored in a table PVUPLDFSTAT 
		/// </summary>
		/// <param name="fileClientpath">The full path of the file in client machine</param>
		/// <param name="uploadtype">indicates if the upload is cost ,asn etc</param>
		/// <returns>Error Details, if any</returns>
		public string insertfilestatus(string fileClientpath,string uploadtype)
		{
			try
			{

				strSql =" insert into PVUPLDFSTAT(FTYPE,USER_ID,UPLD_DATE,UPLD_FILENAME, "+
					" UPLD_STATUS,PROC_DATE,PROC_STATUS,status)"+
					" values ('"+uploadtype+"','TEST',sysdate,'" +fileClientpath + "', " +
					" '1',sysdate,'O','C' )";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();

			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Error";

			}
			return "";
		}	

		
		/// <summary>
		/// when there is a change in uploaded file the status is updated
		/// </summary>
		/// <param name="fileClientpath">The full path of the file in client machine</param>
		/// <returns></returns>
		public string updatefilestatus(string fileClientpath)
		{
			
			try
			{
				strSql = " update PVUPLDFSTAT set PROC_DATE =SYSDATE,PROC_STATUS='C' " +
					" where PROC_STATUS='O' and TRIM(UPLD_FILENAME)='"+fileClientpath+"'";
				
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Error";

			}
			return "";

		}

		
		/// <summary>
		/// To generate a number from current date that works as autonumber
		/// to uniquely identify records
		/// </summary>
		/// <param name="fieldname">specifies the database field name to be updated in PVMODCNTL table</param>
		/// <returns>Autogenerated number,or an empty string if there is an error</returns>
		public string generateAutoNo(string fieldname)
		{
			Utilities utl=new Utilities (); 
			long autono=Convert.ToInt64 (utl.generateAutoNumber ());
			try
			{
				string strSql =	"SELECT "+ fieldname+" from PVMODCNTL WHERE "+fieldname+" > " +autono+ " ";
			
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();

				if (dataReader.HasRows) 
				{
			
					autono=Convert.ToInt64(dataReader[0].ToString().Trim ())+1;
				}
				else
				{
					autono++;
				}

				dataReader.Close(); 
			}
			catch(Exception ex)
			{
				string error=ex.Message;
				return "";
			}
						
			return Convert.ToString (autono);

		}




		/// <summary>
		/// When data is inserted with a new autonumber,
		/// the field in PVMODCNTL is updated with autonumber's current value
		/// so that for the next record a new number is created
		/// </summary>
		/// <param name="autono">The autogenerated number</param>
		/// <param name="fieldname">The field whose value is set to autono in PVMODCNTL </param>
		public void updateAutoNo(string autono,string fieldname)
		{
			try
			{
				strSql = "update PVMODCNTL SET "+fieldname+ "= '"+autono+"'";

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string error=ex.Message;
			}

		}
	

		
		/// <summary>
		/// Returns the vendorid for a given vendor code 
		/// </summary>
		/// <param name="vendorcode"></param>
		/// <returns>Vendorid</returns>
		public string getVendorid(string vendorcode) 
		{
			string vendorid="";	
			strSql = "select vendor_id from pvsupmast where trim(vendor_code)= trim('"+vendorcode+"')";
				

			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					vendorid = dataReader[0].ToString().Trim ();
											
				}
				else
				{
					vendorid="";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				vendorid = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return vendorid;
		}



	}



	
	/* All functions required for uploading and saving ASN records
	 * is defined in dbAsnUplLayer class.
	 * functions for Saving Excel ASNs and Text ASNs are defined in this class
	 * Viewing and deleting uploaded ASNs are also done in this class
	 */
	public class dbAsnUplLayer :db
	{

		private string result = null;
		public class DBASNLayerException : Exception
		{
			public DBASNLayerException(string message) : base(message){}
			public DBASNLayerException(string message, Exception innerException) : base(message,innerException){}
		}
		
		//Saves the header record of the ASN text file
		public string saveasnTxtHeader(string asn_no,string asn_date,string cntr_no,
			string cntr_type,string seal_no,string vessel,
			string port_disp,string sail_date,string eta,
			string tot_pallets,string inv_no,string inv_date,
			string freight,string tot_cases,string filename)

		{
			//Check if container type is correctly entered in excel file
			if("FRZCHLDRYfrzchldry".IndexOf(cntr_type)==-1)
			{
				return "Container Type " + cntr_type+ " is not in correct format[FRZ,CHL or DRY]";
			}

			try
			{
				strSql= "insert into pvasnhead values ('"+asn_no+"',to_date('"+asn_date+"','YYYYMMDD'),'"+
					cntr_no+"','"+cntr_type+"','"+seal_no+"','"+vessel+"','"+port_disp+
					"','',to_date('"+sail_date+"','YYYYMMDD'),to_date('"+eta+"','YYYYMMDD'),"+
					tot_pallets+",'"+inv_no+"',to_date('"+inv_date+"','YYYYMMDD'),"+
					freight+",'','',"+tot_cases+",0,null)";
				
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
			}
			catch
			{
				return filename+"=> Error saving header fields into the database";
			}

			return "";
		}


		/*
		 * Saving detail record of ASN text file.
		 * 
		 */ 
		public string saveasnTxtDetail(string asn_no,string po_number,
			string nsn,string warehouse, string product,
			string qty_ordered,string qty_shipped,string vendor_cost,
			string bmmi_price,string napa_discount, 
			string brand,string pack_date,string expiry_date,string cube,
			string ti,string hi,string wt,int recordno,string filename)
		{


			try
			{

				strSql ="insert into pvasndetl values ('"+asn_no+"','"+po_number+
					"',0,'"+nsn+"','"+product+"','',"+
					qty_ordered+","+
					qty_shipped+","+
					vendor_cost+","+
					bmmi_price+","+
					napa_discount+",'"+brand+"',to_date('"+pack_date+
					"','YYYYMMDD'),to_date('"+expiry_date+"','YYYYMMDD'),'',0,0,' ',' ','',0,0,0,0,0,"+
					cube+",0,"+ ti+","+
					hi+","+wt+",0,0,'"+warehouse+"','','','',0,0,null)";

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return filename+" =>Error in record "+recordno +" Lines from "+(recordno*4-2)+" To "+(recordno*4+1) ;
			}

			return "";
		}



		//get the ordered quantity for a product with ordernumber po_number.
		public string getPoQty(string po_number,string warehouse,string product) 
		{
			string qty_ordered;
			

			strSql = "select qty_ordered from podetm where order_no = '"+
				po_number+"' and product = '"+product+"' and warehouse='"+warehouse+"'";

			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					qty_ordered = dataReader[0].ToString().Trim ();
											
				}
				else
				{
					qty_ordered = "";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				qty_ordered = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return qty_ordered;
		}



		//returns the warehouse and product combined in a string
		public string getwhproduct(string nsn) 
		{
			string whproduct = "";
			strSql = "select warehouse,product from pvcatcurr where stock_number = '"+nsn+"'";
			try 
			{	
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					whproduct =dataReader[0].ToString().Trim()+dataReader[1].ToString().Trim(); 				
				}
				else 
					whproduct ="";
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				whproduct = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return whproduct;
		}



		//delete all asnrecords with asn_no as asnno
		public string delasn(string asnno)
		{
			try
			{


				strSql = "delete pvasnhead where asn_no='"+asnno+"'";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();

				
				strSql = "delete pvasndetl where asn_no='"+asnno+"'";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				
				strSql = "delete pvasnstat where asn_no='"+asnno+"'";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();

			}
			catch
			{
				
				return "Unable to delete the selected ASN record with asn number "+ asnno;
			}

			return "";
		}



		// saves an excel ASN record into database
		public string saveasnXl(string sheetname,string filepath)
		{
			xlLayer xl=new xlLayer(filepath);
		
			Utilities utl=new Utilities ();
			int startindex=14;
			string errorMsg="";
			//header fields
			string tcnno	   =	"";
			string cntrno	   =	"";
			string cntrtype	   =	"";
			string invoiceno   =	"";
			string invoicedt   =	"";
			string portdisp	   =	"";
			string portarrv	   =	"";
			string eta		   =	"";
			string saildate	   =	"";
			string vslname	   =	"";
			//detail fields
			string nsn		   =	"";
			string pono		   =	"";
			string desc		   =	"";
			string pu	 	   =	"";
			string brand	   =	"";
			string qty		   =	"";
			string mfgcost	   =	"";
			string napa		   =	"";
			string vdist	   =	"";
			string bmcost	   =	"";
			
			string asnno	   =	"";
			string ponum	   =	"";
			string warehouse   =	"";
			string product	   =	"";
			string whproduct   =    "";
			string qty_ordered =	"";

			// an auto generated asn number
			asnno			   =	 generateAutoNo("ASNNO"); 	
			
			// collect header values B8:B9 gets the value in cell B9 because cell B8 is 
			// considered as header cell for cell B9.
			tcnno			   =	xl.getExcelValue(sheetname,"B8:B9");
			cntrno			   =	xl.getExcelValue(sheetname,"B9:B10");
			cntrtype		   =	xl.getExcelValue(sheetname,"B10:B11");
			invoiceno	       =	xl.getExcelValue(sheetname,"L2:L3");
			invoicedt		   =	xl.getExcelValue(sheetname,"L3:L4");
			portdisp		   =	xl.getExcelValue(sheetname,"L4:L5");
			portarrv		   =	xl.getExcelValue(sheetname,"L5:L6");
			eta				   =	xl.getExcelValue(sheetname,"L6:L7");
			saildate		   =	xl.getExcelValue(sheetname,"L7:L8");
			vslname			   =	xl.getExcelValue(sheetname,"L8:L9");
			
			// getdatepart function gets only the datepart from the excel sheet
			// in which dates are stored in datetime format.
			invoicedt		=	utl.getdatepart(invoicedt);
			eta				=	utl.getdatepart(eta);
			saildate		=	utl.getdatepart(saildate);

			invoicedt=invoicedt.Replace ("-","/");
			eta=eta.Replace ("-","/");
			saildate=saildate.Replace ("-","/");
		
		
			try
			{  

				// check if the file is uploaded or not based on the tcn_number and invoice no.
 			
				strSql = "select count(*) iCount from pvasnhead  a, pvasnstat b where a.asn_no = b.asn_no and " +
						" b.tcn_no ='" +  tcnno + "' and a.inv_no ='" + invoiceno + "'";
				
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader();
				if(dataReader.Read())
				{
					if(Convert.ToInt64(dataReader["iCount"].ToString()) > 0)
					{
						this.result = "Duplicate TCN # : " + tcnno + " - INVOICE # : " + invoiceno;
						dataReader.Close();
						throw new DBASNLayerException(this.result);
					}
					dataReader.Close();

				}
			

				strSql=	" insert into pvasnhead(ASN_NO,ASN_DATE,CNTR_NO,CNTR_TYPE,VESSEL,PORT_DISP,PORT_ARRV,"+
					" SAIL_DATE,ETA,INV_NO,INV_DATE)"+
					" values(trim('"+asnno+"'),sysdate,trim('"+cntrno+"'),trim('"+cntrtype+"'),trim('"+vslname+"'),"+
					" trim('"+portdisp+"'),'"+portarrv+"',"+
					" to_date('"+saildate+"','MM/DD/RRRR'),to_date('"+eta+"','MM/DD/RRRR'),"+
					" '"+invoiceno+"', to_date('"+invoicedt+"','MM/DD/RRRR'))";
				
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				int getponocnt=0;
				// loop while the NSN cell is non empty and insert ASN detail records
				// startindex indicate the row number from which  detail record fields begin 
				
				while(xl.getExcelValue(sheetname,"A"+((startindex-1))+":A"+startindex)!="")
				{
					nsn			=	xl.getExcelValue(sheetname,"A"+(startindex-1)+":A"+startindex);
					pono		=	xl.getExcelValue(sheetname,"B"+(startindex-1)+":B"+startindex);
					desc		=	xl.getExcelValue(sheetname,"C"+(startindex-1)+":C"+startindex);
					pu			=	xl.getExcelValue(sheetname,"F"+(startindex-1)+":F"+startindex);
					brand		=	xl.getExcelValue(sheetname,"G"+(startindex-1)+":G"+startindex);
					qty			=	xl.getExcelValue(sheetname,"H"+(startindex-1)+":H"+startindex);
					mfgcost		=	xl.getExcelValue(sheetname,"I"+(startindex-1)+":I"+startindex);
					napa		=	xl.getExcelValue(sheetname,"J"+(startindex-1)+":J"+startindex);
					vdist		=	xl.getExcelValue(sheetname,"K"+(startindex-1)+":K"+startindex);
					bmcost		=	xl.getExcelValue(sheetname,"L"+(startindex-1)+":L"+startindex);
					

					whproduct = getwhproduct(nsn);
					// if no product found for the NSN then ASN record in 
					// excel file is wrong.Return an error Message
					if (whproduct == "") 
					{ 
						return " =>Error - NSN "+nsn+ " not found !";
						
					}
					warehouse = whproduct.Substring (0,2);
					product   = whproduct.Substring (2,whproduct.Length -2);

					qty_ordered =getPoQty(pono,warehouse,product);
					
					
					
					if (getponocnt==0 && pono.Length >0)
					{
						ponum=pono;
					}
					else
					{
							
						ponum=pono;
					}
					getponocnt=getponocnt+1;
				
					startindex++;

					if (qty_ordered == "") 
					{
						errorMsg+= " NSN "+nsn+" Not found in PO Number "+pono+ " Or PO Number "+pono+" Not found  ! ";
					}
					else
					{

						strSql=	" insert into pvasndetl(ASN_NO,PO_NUMBER,NSN,PRODUCT,QTY_ORDERED,QTY_SHIPPED,VENDOR_COST,"+
							" BMMI_PRICE,NAPA_DISCOUNT,BRAND,PACKAGING_CODE,TOTAL_WT, "+
							" PACKAGE_UOM, LOCATION_CODE) "+
							" values(trim('"+asnno+"'),trim('"+pono+"'),trim('"+nsn+"'),"+
							" trim('"+product+"'),"+qty_ordered+",trim("+qty+"),"+
							" trim("+mfgcost+"),trim("+bmcost+"),trim("+napa+"),"+
							" trim('"+brand+"'),trim('"+pu+"'),trim("+vdist+"),'0',"+
							" trim('"+warehouse+"'))";
								
						dbCommand.CommandText = strSql;
						retErr	= dbCommand.ExecuteNonQuery();
					}
					
				}
				if(errorMsg.Trim().Length==0)
				{
					// save tcnnumber and status for a particular asn
					errorMsg=saveasnstat(asnno,tcnno,ponum);
					// Update the ASNNO field in PVMODCNTL with the asnno created
					updateAutoNo(asnno,"ASNNO");
				}

			}
			catch(Exception ex)
			{
				string ss=ex.Message;
				errorMsg="Error saving ASN records !" + ss;
				return errorMsg;
			}
			finally
			{
				xl.closeXLconnection();
			}
			
			return errorMsg;

		}



		// saves tcnnumber,status values into  PVASNSTAT table
		public string saveasnstat(string asnno,string tcnno,string ponum)
		{
			string errorMsg="";
			try
			{
				strSql=	" select vendor_id "+
						" from pvpohead A where trim(po_no)=trim('"+ponum+"') ";
				dbCommand.CommandText =strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (!dataReader.HasRows) 
				{
					errorMsg="Error.PO Number "+ponum+" Not found in Purchase Order. !Refresh PO Extraction and try again !";
				}
				dataReader.Close ();
				if(errorMsg.Length ==0)
				{

					strSql=	" insert into PVASNSTAT(ASN_NO,VENDOR_ID,TCN_NO,STATUS) " +
						" select trim('"+asnno+"'),vendor_id,trim('"+tcnno+"'),'O' "+
						" from pvpohead A where trim(po_no)=trim('"+ponum+"') ";

					dbCommand.CommandText = strSql;

					retErr = dbCommand.ExecuteNonQuery();
				}
				
			}
			catch(Exception ex)
			{
				string error=ex.Message;
			}
			return errorMsg;
		}

		

		
	}
	



	/// <summary>
	///  functions related with uploading and saving cost records
	///  are defined in dbcostUplLayer class.
	///  Viewing and deleting uploaded cost are also defined in this class
	///  Re Creation of pvsupcscurr table procedure is called from this class
	/// </summary>
	public class dbcostUplLayer :db
	{
	
		
		//delete all costrecords updated on updatedate with particular vendorid
		public string delCost(string vendorid,string updatedate)
		{

			try
			{
				strSql = "delete pvsupcost where vendor_id='"+vendorid+"' and update_date=to_date('"+updatedate+"','dd-Mon-rrrr')";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Unable to delete the cost records";
			}

			return "";
		}





		//returns the warehouse and product combined in a string
		public string getwhproduct(string nsn) 
		{
			string whproduct = "";
			strSql = "select warehouse,product from pvcatcurr where trim(stock_number) = trim('"+nsn+"')";
			try 
			{	
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					whproduct =dataReader[0].ToString().Trim()+dataReader[1].ToString().Trim(); 				
				}
				else 
					whproduct ="";
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				whproduct = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return whproduct;
		}



		// saves a excel cost record into database
		public string savecostXl(string sheetname,string filepath)
		{
			xlLayer xl=new xlLayer(filepath);
		
			Utilities utl=new Utilities ();
			int startindex=8;
			
			//header fields
			string vendorcode   =	"";
			string vendorid		=	"";
			string upddate		=	"";
		
			//detail fields
			string nsn		    =	"";
			string purch_unit	=	"";	
			string bmcost		=	"0";

			string warehouse	=	"";
			string product		=	"";
			string whproduct    =   "";
			string mfgcost		=	"0";
			string napa			=	"0";
			string vdist		=	"0";
			string bmmiprice	=	"0";
	
			vendorcode		    =	xl.getExcelValue(sheetname,"B2:B3");
			vendorid		    =	getVendorid(vendorcode);
			
			if(vendorid.Trim ().Length ==0)
			{
				xl.closeXLconnection ();
				return "Error.The vendor code in "+filepath+ " is invalid !";
			}

			upddate		=	xl.getExcelValue (sheetname,"B4:B5");
			upddate		=	utl.getdatepart (upddate);
			
			if (utl.ValidateDate (upddate,"LOCAL COST UPDATE DATE","B5").Length>0)
			{
				xl.closeXLconnection ();
				return "Error.Update date"+upddate+ " is invalid !";
			}

			
			try
			{
	
				while(xl.getExcelValue(sheetname,"A"+((startindex-1))+":A"+startindex)!="")
				{
					nsn			=	xl.getExcelValue(sheetname,"A"+(startindex-1)+":A"+startindex);
					purch_unit	=	xl.getExcelValue(sheetname,"E"+(startindex-1)+":E"+startindex);
					mfgcost		=	xl.getExcelValue(sheetname,"F"+(startindex-1)+":F"+startindex);
					napa		=	xl.getExcelValue(sheetname,"G"+(startindex-1)+":G"+startindex);
					vdist		=	xl.getExcelValue(sheetname,"H"+(startindex-1)+":H"+startindex);
					bmcost		=	xl.getExcelValue(sheetname,"I"+(startindex-1)+":I"+startindex);
					
					if(napa=="")    napa="0";
					if(mfgcost=="") mfgcost="0";
					if(vdist=="")	vdist="0";

					if(bmcost=="") 
					{
						xl.closeXLconnection ();
						return " =>Error - Bmmi Cost entry is empty !";
					}

					whproduct = getwhproduct(nsn);
					if (whproduct == "") 
					{ 
						xl.closeXLconnection ();
						return " =>Error - NSN "+nsn+ " not found !";
						
					}
					warehouse = whproduct.Substring (0,2);
					product   = whproduct.Substring (2,whproduct.Length -2);

					startindex++;


					strSql		=	" SELECT VENDOR_PRICE FROM PVCATCURR  "+
						" WHERE TRIM(STOCK_NUMBER)='"+nsn+"' and WAREHOUSE NOT LIKE '%Z' ";	
					try 
					{	
							
						dbCommand.CommandText = strSql;
						dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
						dataReader.Read();
						if (dataReader.HasRows) 
						{
							bmmiprice =dataReader[0].ToString().Trim(); 				
						}
							 
					}
					catch(Exception ex)
					{
						string error=ex.Message ;
						bmmiprice = "0";
					}
					finally 
					{
						dataReader.Close(); 
				
					}
			 
					strSql=	" delete bmmi.PVSUPCOST where VENDOR_ID= "+vendorid + 
						" and update_date=to_date('"+upddate+"','mm/dd/rrrr')" + 
						" and trim(nsn)=trim('"+nsn+"')";
							
					dbCommand.CommandText = strSql;
					retErr = dbCommand.ExecuteNonQuery();
				
					strSql=	" insert into PVSUPCOST(VENDOR_ID,UPDATE_DATE,WAREHOUSE,PRODUCT, "+
						" NSN,PURCH_UNIT,MFG_COST,VENDOR_DIST_FEE,NAPA,BMMI_COST,BMMI_CURR_PRICE)"+
						" values("+vendorid+",to_date('"+upddate+"','mm/dd/rrrr'),'"+
						warehouse+"','"+product+"','"+nsn+"','"+purch_unit+"',"+mfgcost+","+
						vdist+","+napa+","+bmcost+","+bmmiprice+") " ; 
							
					dbCommand.CommandText = strSql;
					retErr = dbCommand.ExecuteNonQuery();

		
				}
				
			

			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Error while inserting data into database !";
			}
			finally
			{
				xl.closeXLconnection();
			}
			
			return "";

		}



		//Executes database procedure pvsupcscurr_pop.
		//Procedure pvsupcscurr_pop truncates pvsupcscurr table and
		//populates it with latest costs from pvsupmast.
		public string recreatesupcscurr()
		{
			try
			{
				
				dbCommand.CommandText = "bmmi.pvsupcscurr_pop";
				dbCommand.CommandType = CommandType.StoredProcedure;
				dbCommand.ExecuteNonQuery ();
			}
			catch
			{
				return "Error while inserting data into database !";
			}
			return "";
		}




	}
	



	/* functions related with uploading and saving shipping plan records
	 * are defined in dbshipUplLayer class.
	 */
	public class dbshipUplLayer:db
	{
		
		//delete all costrecords updated on updatedate with particular vendorid
		public string delShplan(string shplanno)
		{

			try
			{
				strSql=" delete pvshplanhead where shplanno='"+shplanno+"'";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				strSql=" delete pvshplandetl where shplanno='"+shplanno+"'";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Unable to delete the cost records";
			}

			return "";
		}

		//Saving the Uploaded Shipping Plan file
		public string saveshipXl(string sheetname,string filepath)
		{
			xlLayer xl=new xlLayer(filepath);
		
			Utilities utl=new Utilities ();
			int startindex=8;
			
			string shplanno		=	"";

			//header fields
			string vendorcode   =	"";
			string vendorid		=	"";
			string plansentdate	=	"";
			
		
			//detail fields
			string pono			=	"";
			string planneddate	=	"";
			string nsn		    =	"";
			string purch_unit	=	"";	
			string planqty		=	"0";
			string whproduct	=	"";
			string warehouse	=	"";
			string product		=	"";

			vendorcode		    =	xl.getExcelValue(sheetname,"B2:B3");
			vendorid		    =	getVendorid(vendorcode);

			//Vendor id check

			if(vendorid.Trim().Length ==0)
			{
				xl.closeXLconnection ();
				return "Error.The vendor code in "+filepath+ " is invalid";
			}

			plansentdate		=	xl.getExcelValue (sheetname,"B4:B5");
			plansentdate		=	utl.getdatepart (plansentdate);
			


			shplanno=generateAutoNo("SHPLANNO");

			
			try
			{
				strSql=	" insert into PVSHPLANHEAD(SHPLANNO,SHPLANDATE,VENDOR_ID,VENDOR_CODE,STATUS) "+
					" values("+shplanno+",to_date('"+plansentdate+"','mm/dd/rr'),"+vendorid+",'"+vendorcode+"','0') ";
			
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				while(xl.getExcelValue(sheetname,"C"+((startindex-1))+":C"+startindex)!="")
				{
					planneddate	=	xl.getExcelValue(sheetname,"A"+(startindex-1)+":A"+startindex);
					pono		=	xl.getExcelValue(sheetname,"B"+(startindex-1)+":B"+startindex);
					nsn			=	xl.getExcelValue(sheetname,"C"+(startindex-1)+":C"+startindex);
					purch_unit	=	xl.getExcelValue(sheetname,"F"+(startindex-1)+":F"+startindex);
					planqty		=	xl.getExcelValue(sheetname,"G"+(startindex-1)+":G"+startindex);
					
					planneddate		=	utl.getdatepart (planneddate);
					whproduct = getwhproduct(nsn);
					if (whproduct == "") 
					{ 
						xl.closeXLconnection ();
						return " =>Error - NSN "+nsn+ " not found ";
						
					}
					warehouse = whproduct.Substring (0,2);
					product   = whproduct.Substring (2,whproduct.Length -2);

					startindex++;

					strSql=	" insert into PVSHPLANDETL(SHPLANNO,PO_NO,PLANDATE,WAREHOUSE,PRODUCT,"+
						" NSN,PURCH_UNIT,PLAN_QTY,STATUS) "+
						" values("+shplanno+",'"+pono+"',TO_DATE('"+planneddate+"','mm/dd/rr'),'"+warehouse+"',"+
						" trim('"+product+"'),trim('"+nsn+"'),trim('"+purch_unit+"'),"+planqty+",'0') ";
							
					dbCommand.CommandText = strSql;
					retErr = dbCommand.ExecuteNonQuery();
					updateAutoNo(shplanno,"SHPLANNO");
		
				}
				
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Error while inserting shipping plan data into database";
			}
			finally
			{
				xl.closeXLconnection();
			}
			
			return "";

		}


		public string getwhproduct(string nsn) 
		{
			string whproduct = "";
			strSql = "select warehouse,product from pvcatcurr where trim(stock_number) = trim('"+nsn+"')";
			try 
			{	
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					whproduct =dataReader[0].ToString().Trim()+dataReader[1].ToString().Trim(); 				
				}
				else 
					whproduct ="";
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				whproduct = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return whproduct;
		}

	}




	/* functions related with Closing ASN records when GRN is received
	 * are defined in closeAsnLayer class.
	 */
	public class closeAsnLayer:db
	{


		/*
		 * Collects All open ASNs and the relative GRNs into dataset
		 * to present it in a grid to user , so that he can compare
		 * it with GRNs and close
		 */
		public DataSet closeasn_DS()
		{
			
			DataSet dbDataSet = new DataSet();
			
			try
			{
				/*
					* Select all records where container numbers are available for both ASN and GRN
					* and
					* Select all records where the container numbers are available for ASN but not GRN
					* and
					* Select all records where the container numbers are available for GRN but not for ASN
					*/ 
				strSql =" SELECT A.ASN_NO as asnno, to_char(A.ASN_DATE,'dd-Mon-rrrr') as asndate, A.CNTR_NO as asncntrno,"+
					" A.CNTR_TYPE as cntrtype,to_char(A.ETA,'dd-Mon-rrrr') as eta,to_char(D.GRN_DATE,'dd-Mon-rrrr') as grndate,"+
					" C.VENDOR_DISPNAME,D.GRN_NO as grnno,D.CNTR_NO as grncntrno FROM PVASNHEAD A,PVASNSTAT B,PVSUPMAST C,pvgrnhead D "+
					" where A.ASN_NO=B.ASN_NO and B.STATUS !='C' AND B.VENDOR_ID=C.VENDOR_ID "+
					" and a.cntr_no=d.cntr_no " 
										  
					+" union " +
								
					" SELECT A.ASN_NO as asnno, to_char(A.ASN_DATE,'dd-Mon-rrrr') as asndate, A.CNTR_NO as asncntrno,"+
					" A.CNTR_TYPE as cntrtype,to_char(A.ETA,'dd-Mon-rrrr') as eta,to_char(to_date(''),'dd-Mon-rrrr') as grndate, " +
					" C.VENDOR_DISPNAME,'nil' as grnno,'nil'as grncntrno FROM PVASNHEAD A,PVASNSTAT B,PVSUPMAST C " +
					" where A.ASN_NO=B.ASN_NO and B.STATUS !='C' AND B.VENDOR_ID=C.VENDOR_ID " +
					" and trim(a.cntr_no) not in (select trim(d.cntr_no) from PVGRNHEAD D where status != 'C' " +
					" and b.vendor_id=d.vendor_id) "+
 										
					" union " +
								
					" SELECT 'nil' as asnno,to_char(to_date(''),'dd-Mon-rrrr') as asndate,'nil' as asncntrno,"+
					" 'nil' as cntrtype,to_char(to_date(''),'dd-Mon-rrrr') as eta,to_char(D.GRN_DATE,'dd-Mon-rrrr') as grndate,"+
					" C.VENDOR_DISPNAME,D.GRN_NO as grnno,D.CNTR_NO as grncntrno FROM PVSUPMAST C, PVGRNHEAD D "+
					" where D.STATUS !='C' AND D.VENDOR_ID=C.VENDOR_ID"+
					" and trim(D.cntr_no) not in (select trim(A.cntr_no) from PVasnhead A, "+
					" PVASNSTAT B where B.status != 'C' "+
					" and A.asn_no = B.asn_no)";

				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "closeasn");

			}
			catch
			{
				return null;
			}
			return dbDataSet;
		}



		/*
		* Sets  selected ASNs' status  to C
		*/
		public string closeasn(string asnno)
		{
	
			try
			{


				strSql	= " update PVASNSTAT SET STATUS ='C' WHERE TRIM(ASN_NO)='"+asnno+"' ";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();

				
				strSql= " update PVGRNHEAD SET STATUS ='C' WHERE "+
					" CNTR_NO=(SELECT CNTR_NO FROM PVASNHEAD WHERE ASN_NO='"+asnno+"')";

				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
				

			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Unable to Close the selected ASN record with asn number "+ asnno;
			}

			return "";
		}

	}



	public class closeShplanLayer:db
	{


		/*
		 * Collects All open ASNs and the relative GRNs into dataset
		 * to present it in a grid to user , so that he can compare
		 * it with GRNs and close
		 */
		public DataSet closeShplan_DS()
		{
			
			DataSet dbDataSet = new DataSet();
			
			try
			{
				/*
					* Select all records where container numbers are available for both ASN and GRN
					* and
					* Select all records where the container numbers are available for ASN but not GRN
					* and
					* Select all records where the container numbers are available for GRN but not for ASN
					*/ 
				strSql =" SELECT A.SHPLANNO, to_char(A.SHPLANDATE,'dd-Mon-rrrr') as shplandate,"+
					" B.VENDOR_ID,B.VENDOR_DISPNAME FROM PVSHPLANHEAD A,PVSUPMAST B "+
					" where A.VENDOR_ID=B.VENDOR_ID and A.STATUS != 'C' order by A.SHPLANDATE,B.VENDOR_ID "+
					" ";
						

				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "closeShplan");

			}
			catch(Exception ex)
			{
				string error=ex.Message;
				return null;
			}
			return dbDataSet;
		}



		public DataSet closeShplanASN_DS()
		{
			
			DataSet dbDataSet = new DataSet();
			
			try
			{
			
				strSql =" SELECT A.ASN_NO, to_char(A.ASN_DATE,'dd-Mon-rrrr') as asndate, A.CNTR_NO,"+
					" to_char(A.ETA,'dd-Mon-rrrr') as eta,c.VENDOR_ID,"+
					" C.VENDOR_DISPNAME FROM PVASNHEAD A,PVASNSTAT B,PVSUPMAST C "+
					" where A.ASN_NO=B.ASN_NO AND B.VENDOR_ID=C.VENDOR_ID "+
					" and A.asn_date > (select max(SHPLANDATE) from pvshplanhead where pvshplanhead.status!='C')"+
					" order by A.ASN_DATE,C.VENDOR_ID ";
					
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(strSql, dbConnection);
				dbAdapter.Fill(dbDataSet, "closeShplanASN");

			}
			catch(Exception ex)
			{
				string error=ex.Message;
				return null;
			}
			return dbDataSet;
		}



		/*
		* Sets  selected  shipping planno' status  to C
		*/
		public string closeShplan(string planno)
		{
	
			try
			{

				strSql	= " update PVSHPLANHEAD SET STATUS ='C' WHERE TRIM(SHPLANNO)='"+planno+"' ";
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();

				
				dbCommand.CommandText = strSql;
				retErr = dbCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Unable to Close  record with Plan number "+ planno;
			}

			return "";
		}

	}

	
	public class dbRefresh:db
	{
		public string Refresh(string procedurename)
		{


			try
			{

				dbCommand.CommandText = procedurename;
				dbCommand.CommandType = CommandType.StoredProcedure;
				dbCommand.ExecuteNonQuery ();
	
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "Unable to Refresh the PO Extraction";
			}

			return "";
		}

	}

	/// <summary>
	/// Pallette Calculation 
	/// </summary>

	public class dbPalletteCalc:db
	{

		/// <summary>
		/// Checks if the selected order number exists in the opheadm table
		/// </summary>
		/// <param name="order_no"></param>
		/// <returns></returns>
		public string checkOrderNo(string order_no) 
		{
			
			

			strSql = "select order_no from bmmifsv.opheadm where trim(order_no) =trim( '"+order_no+"')";

			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					return "";
				}
				else
				{
					return " Order Number " + order_no+ "  doesnot Exist" ;
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				
			}
			finally 
			{
				dataReader.Close(); 

			}
			return "";
		}



		/// <summary>
		/// Collects the total weight of all products and divides it with order quantity to collect
		/// the cases required for that order
		/// </summary>
		/// <param name="orderNo"></param>
		/// <returns></returns>
		public string getTotalCases(string orderNo)
		{
			
			//			string errorDetl   =	"";
			string pricing_unit=	"";
			string order_qty   =	"";
			string net_weight  =	"";
			Utilities utl=new Utilities();
			int totalcases=0;
			try 
			{	
				strSql = " select a.pricing_unit,a.order_qty,b.net_weight from bmmifsv.opdetm A,bmmi.pvcatcurr B where a.product=b.product and a.order_no = '"+orderNo+"'";
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				//dataReader.Read();
				while(dataReader.Read()) 
				{
					
					pricing_unit=	dataReader[0].ToString().Trim();
					order_qty   =	dataReader[1].ToString().Trim();
					net_weight  =	dataReader[2].ToString().Trim();
					 
					if(utl.IsNumber   (net_weight) && utl.IsNumber (order_qty))
					{
						if (pricing_unit=="CS")
						{
							totalcases+=Convert.ToInt32 (order_qty);
						}
						if(pricing_unit=="LB" && net_weight!="0")
						{
							totalcases+=Convert.ToInt32 (order_qty)/Convert.ToInt32 (net_weight);
						}
					}
					
				}
				
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				
			}
			finally 
			{
				dataReader.Close(); 
				
				
			}
			return totalcases.ToString();
		}



	}



	

	/// <summary>
	///All database functions related to Order Tracking module
	///are defined in dbOrdTrackingLayer class 
	/// </summary>
	public class dbOrdTrackingLayer
	{
		public string connStr;
			
		public dbOrdTrackingLayer()
		{
			
			connStr				  = "Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
			
		}
		


		
		/// <summary>
		/// fills up the dataset with PO numbers and vendor names (Order Tracking by PO )
		/// </summary>
		/// <returns></returns>
		public DataSet OTOrder_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append(" SELECT A.PO_NO||'-'||A.VENDOR_CODE||'-'||B.VENDOR_NAME AS ord,A.PO_NO " );
				sbConn.Append(" FROM BMMI.PVPOHEAD A,PVSUPMAST B ");
				sbConn.Append(" WHERE A.VENDOR_ID=B.VENDOR_ID AND A.STATUS !='C' ORDER BY PO_NO" );

				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "tblOrder");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		/// <summary>
		/// fills up the dataset with products (Order Tracking by Entering a product description)
		/// </summary>
		/// <returns></returns>
		public DataSet OTDesc_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append("SELECT DISTINCT trim(C.DSCP_DESC) as ProdName, A.PRODUCT as product FROM PVPODETL A, PVPOHEAD B,pvcatcurr C " );
				sbConn.Append("WHERE A.PO_NO=B.PO_NO AND A.STATUS !='C' AND TRIM(A.PRODUCT)=TRIM(C.PRODUCT) AND TRIM(A.WAREHOUSE)=TRIM(C.WAREHOUSE) " );
				sbConn.Append(" AND A.WAREHOUSE NOT LIKE '%Z' order by product" );
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "tblProducts");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		

		
		/// <summary>
		/// fills up the dataset with products (Order Tracking by Product)
		/// Used to populate a drop down box with products
		/// </summary>
		/// <returns></returns>
		public DataSet OTProduct_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append("SELECT DISTINCT trim(A.WAREHOUSE||'-'||A.PRODUCT||'-'||C.DSCP_DESC) as ProdName, A.PRODUCT as product FROM PVPODETL A, PVPOHEAD B,pvcatcurr C " );
				sbConn.Append("WHERE A.PO_NO=B.PO_NO AND A.STATUS !='C' AND TRIM(A.PRODUCT)=TRIM(C.PRODUCT) AND TRIM(A.WAREHOUSE)=TRIM(C.WAREHOUSE) " );
				sbConn.Append(" AND A.WAREHOUSE NOT LIKE '%Z' order by product" );
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "tblProducts");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		

		
		/// <summary>
		/// fills up the dataset with Suppliers (Order Tracking by Supplier)
		/// </summary>
		/// <returns></returns>
		public DataSet OTSupplier_DS()
		{
			DataSet dbDataSet = new DataSet();
			try
			{
				StringBuilder sbConn = new StringBuilder();

				sbConn.Append(" SELECT DISTINCT B.VENDOR_ID,B.VENDOR_DISPNAME " );
				sbConn.Append(" FROM PVPOHEAD A,PVSUPMAST B WHERE A.STATUS !='C' ");
				sbConn.Append(" AND A.VENDOR_ID=B.VENDOR_ID ORDER BY B.VENDOR_ID " );

				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtblSupplier");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		

		
		/// <summary>
		/// fills up the dataset with product details of a particular order (Order Tracking by PO)
		/// </summary>
		/// <param name="selOrder"></param>
		/// <returns></returns>
		public DataSet OTOrderdetails_DS(string selOrder)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append(" select A.nsn,A.product,B.dscp_desc,A.orig_order_qty,A.order_qty,A.rcvd_qty,A.shipd_qty,A.balance_qty, " );
				sbConn.Append(" A.status,A.plan_qty,C.physical_qty,C.allocated_qty,(C.physical_qty-C.allocated_qty) as free_qty, " );
				sbConn.Append(" D.po_no,to_char(D.po_date,'dd-Mon-rr') as po_date,E.vendor_code,E.vendor_name " );
				sbConn.Append(" from pvpodetl A,pvcatcurr B,stockm C,pvpohead D,pvsupmast E  " );
				sbConn.Append(" where A.nsn=B.stock_number and trim(A.po_no)=trim('"+selOrder+"') and  " );
				sbConn.Append(" A.warehouse=C.warehouse and A.product=C.product AND A.PO_NO=D.PO_NO " );
				sbConn.Append(" and A.WAREHOUSE NOT LIKE '%Z' and D.VENDOR_ID=E.VENDOR_ID  order by 2,1 " );
				

				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvordetls");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}
		


		
		/// <summary>
		/// fills up the dataset with product details of a particular product (Order Tracking by product description)
		/// </summary>
		/// <param name="desc"></param>
		/// <returns></returns>
		public DataSet OTDescdetails_DS(string desc)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append(" select A.NSN,A.PRODUCT as product,B.dscp_desc,A.orig_order_qty,A.order_qty,A.rcvd_qty,A.shipd_qty,A.balance_qty, " );
				sbConn.Append(" A.status,A.plan_qty,C.physical_qty,C.allocated_qty,(C.physical_qty-C.allocated_qty) as free_qty, " );
				sbConn.Append(" D.po_no,to_char(D.po_date,'dd-Mon-rr') as po_date,E.vendor_code,E.vendor_name " );
				sbConn.Append(" from pvpodetl A,pvcatcurr B,stockm C,pvpohead D,pvsupmast E  " );
				sbConn.Append(" where A.nsn=B.stock_number and trim(B.dscp_desc) like '"+desc+"%' and " );
				sbConn.Append(" A.warehouse=C.warehouse and A.product=C.product " );
				sbConn.Append(" and D.po_no=A.po_no and D.vendor_id=E.vendor_id " );
				sbConn.Append(" and A.status !='C' and B.WAREHOUSE NOT LIKE '%Z' order by A.po_no " );

				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtblprdescdetls");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}




		
		/// <summary>
		/// fills up the dataset with product details of a particular product (Order Tracking by product)
		/// </summary>
		/// <param name="selproduct"></param>
		/// <returns></returns>
		public DataSet OTProductdetails_DS(string selproduct)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append(" select A.NSN,A.PRODUCT as product, B.dscp_desc,A.orig_order_qty,A.order_qty,A.rcvd_qty,A.shipd_qty,A.balance_qty, " );
				sbConn.Append(" A.status,A.plan_qty,C.physical_qty,C.allocated_qty,(C.physical_qty-C.allocated_qty) as free_qty, " );
				sbConn.Append(" D.po_no,to_char(D.po_date,'dd-Mon-rr') as po_date,E.vendor_code,E.vendor_name " );
				sbConn.Append(" from pvpodetl A,pvcatcurr B,stockm C,pvpohead D,pvsupmast E  " );
				sbConn.Append(" where A.nsn=B.stock_number and trim(A.product)=trim('"+selproduct+"') and " );
				sbConn.Append(" A.warehouse=C.warehouse and A.product=C.product " );
				sbConn.Append(" and D.po_no=A.po_no and D.vendor_id=E.vendor_id " );
				sbConn.Append(" and A.status !='C' and B.WAREHOUSE NOT LIKE '%Z' order by A.po_no " );

				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtblprdetls");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		
		/// <summary>
		/// fills up the dataset with product details of a particular supplier (Order Tracking by Supplier)
		/// </summary>
		/// <param name="selSupplier"></param>
		/// <returns></returns>
		public DataSet OTSupdetails_DS(string selSupplier)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append(" select A.NSN,A.PRODUCT as product,B.dscp_desc,A.orig_order_qty,A.order_qty,A.rcvd_qty,A.shipd_qty,A.balance_qty, " );
				sbConn.Append(" A.status,A.plan_qty,C.physical_qty,C.allocated_qty,(C.physical_qty-C.allocated_qty) as free_qty, " );
				sbConn.Append(" D.po_no,to_char(D.po_date,'dd-Mon-rr') as po_date,E.vendor_code,E.vendor_name " );
				sbConn.Append(" from pvpodetl A,pvcatcurr B,stockm C,pvpohead D,pvsupmast E  " );
				sbConn.Append(" where A.nsn=B.stock_number and trim(D.vendor_id)=trim('"+selSupplier+"') and " );
				sbConn.Append(" A.warehouse=C.warehouse and A.product=C.product " );
				sbConn.Append(" and D.po_no=A.po_no and D.vendor_id=E.vendor_id " );
				sbConn.Append(" and A.status !='C' and B.WAREHOUSE NOT LIKE '%Z' order by A.po_no " );

				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtblSupplier");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		
		/// <summary>
		/// fills up the dataset with  details of a Product
		/// </summary>
		/// <param name="product"></param>
		/// <param name="pono"></param>
		/// <returns></returns>
		public DataSet OTgetproductdetls_DS(string product,string pono)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();

				sbConn.Append(" select trim('"+pono+"') as pono, B.product,B.warehouse,B.stock_number as nsn,B.dscp_desc  " );
				sbConn.Append(" from pvpodetl A,pvcatcurr B ");
				sbConn.Append(" where trim(B.product)=trim('"+product+"' ) and trim(a.nsn)=trim(b.stock_number) and B.WAREHOUSE NOT LIKE '%Z' and rownum<2 ");
				
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtb");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}
		
		
		
		
		/// <summary>
		/// fills up the dataset with GRN details of a PO
		/// </summary>
		/// <param name="selpo">Selected Purchase Order</param>
		/// <param name="nsn"></param>
		/// <returns></returns>
		public DataSet OTPrdDetlGrn_DS(string selpo,string nsn)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();

				sbConn.Append(" select to_char(A.GRN_DATE,'dd-Mon-rr') as grndate,B.GRN_NO,B.RCVD_QTY " );
				sbConn.Append(" from PVGRNHEAD  A,PVGRNDETL B " );
				sbConn.Append(" where A.GRN_NO=B.GRN_NO and trim(B.PO_NO)=trim('"+selpo+"')" );
				sbConn.Append(" and trim(b.nsn)=trim('"+nsn+"') and b.status !='C' " );
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtblprdetls");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		
		/// <summary>
		/// fills up the dataset with ASN details of a PO
		/// </summary>
		/// <param name="selpo">Selected Purchase Order</param>
		/// <param name="nsn"></param>
		/// <returns></returns>
		public DataSet OTPrdDetlASN_DS(string selpo,string nsn)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();

				sbConn.Append(" select to_char(A.ASN_DATE,'dd-Mon-rr') as asndate,B.ASN_NO,B.QTY_SHIPPED,  " );
				sbConn.Append(" to_char(A.ASN_DATE+D.LEAD_TIME,'dd-Mon-rr') as eta," );
				sbConn.Append(" to_char(A.ASN_DATE+D.LEAD_TIME+D.LEAD_TIME_VAR,'dd-Mon-rr') maxeta" );
				sbConn.Append(" from pvasnhead  A,pvasndetl B,PVASNSTAT C,PVSUPMAST D " );
				sbConn.Append(" where A.ASN_NO=B.ASN_NO and trim(B.PO_NUMBER)=trim('"+selpo+"')" );
				sbConn.Append(" and trim(B.NSN)=trim('"+nsn+"')" );
				sbConn.Append(" and C.vendor_id=D.vendor_id and A.ASN_NO=C.ASN_NO AND C.STATUS !='C' " );
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtblpr");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		
		/// <summary>
		/// fills up the dataset with SHIPPING PLAN details of a PO 
		/// </summary>
		/// <param name="selpo">Selected Purchase Order</param>
		/// <param name="nsn"></param>
		/// <returns></returns>
		public DataSet OTPrdDetlPlan_DS(string selpo,string nsn)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();

				sbConn.Append(" select to_char(B.PLANDATE,'dd-Mon-rr') as plandate,B.SHPLANNO,B.PLAN_QTY,  " );
				sbConn.Append(" to_char( B.PLANDATE+C.LEAD_TIME,'dd-mon-rr') as eta, ");
				sbConn.Append(" to_char( B.PLANDATE+C.LEAD_TIME+C.LEAD_TIME_VAR,'dd-mon-rr') as maxeta ");
				sbConn.Append(" from PVSHPLANHEAD  A,PVSHPLANDETL B, PVSUPMAST C " );
				sbConn.Append(" where A.SHPLANNO=B.SHPLANNO and trim(B.PO_NO)=trim('"+selpo+"')" );
				sbConn.Append(" and A.vendor_id=C.vendor_id and trim(B.nsn)='"+nsn+"' and b.status !='C' " );
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvtbl");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		
		/// <summary>
		/// fills up the dataset with ASN Header details of a PO 
		/// </summary>
		/// <param name="asnno"></param>
		/// <returns></returns>
		public DataSet ASNheadView_DS(string asnno)
		{
			DataSet dbDataSet = new DataSet();
			
			try
			{
				StringBuilder sbConn = new StringBuilder();

				sbConn.Append(" select A.ASN_NO,A.VESSEL,B.TCN_NO,A.CNTR_NO, " );
				sbConn.Append(" A.CNTR_TYPE,A.INV_NO,to_char(A.INV_DATE,'dd-Mon-rr')as invdate, " );
				sbConn.Append(" A.PORT_DISP,A.PORT_ARRV,to_char(A.ETA,'dd-Mon-rr') as ETA,C.VENDOR_DISPNAME " );
				sbConn.Append(" from pvasnhead  A,PVASNSTAT B,PVSUPMAST C " );
				sbConn.Append(" where A.ASN_NO=B.ASN_NO and trim(A.ASN_NO)=trim('"+asnno+"') " );
				sbConn.Append(" and B.vendor_id=C.vendor_id and B.STATUS !='C' " );
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvasn");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

		
		
		
		/// <summary>
		/// fills up the dataset with ASN detail details of a PO
		/// </summary>
		/// <param name="asnno"></param>
		/// <param name="nsn"></param>
		/// <returns></returns>
		public DataSet ASNDetlView_DS(string asnno,string nsn)
		{
			DataSet dbDataSet = new DataSet();

			

			
			try
			{
				StringBuilder sbConn = new StringBuilder();

				sbConn.Append(" select A.ASN_NO,A.NSN,A.PO_NUMBER,A.PACKAGING_CODE,A.BRAND, " );
				sbConn.Append(" A. QTY_SHIPPED,A.VENDOR_COST,A.NAPA_DISCOUNT, " );
				sbConn.Append(" A.TOTAL_WT,A.BMMI_PRICE" );
				sbConn.Append(" from pvasndetl  A,PVASNSTAT B " );
				sbConn.Append(" where trim(A.ASN_NO)=trim(B.ASN_NO) AND trim(A.ASN_NO)=trim('"+asnno+"') " );
				sbConn.Append(" AND trim(a.nsn)='"+nsn+"'and B.STATUS !='C' " );
				string conn= sbConn.ToString();
				OleDbConnection dbConnection = new OleDbConnection(connStr);
				OleDbDataAdapter dbAdapter = new OleDbDataAdapter(conn, dbConnection);
				dbAdapter.Fill(dbDataSet, "pvasndetl");
			}
			catch (Exception ex)
			{
				string errMessage = ex.Message;
				// ex.Message;
			}
			return dbDataSet;
		}

	
	}	



	/// <summary>
	/// Database related function for RF file processing is
	/// defined in dBRFLayer class
	/// </summary>
	public class dBRFLayer :db
	{

		string XLConnStr;
		OleDbCommand XLCommand;
		OleDbConnection XLConn;
		OleDbDataReader XLdataReader;
		public static string errordetl;
		
		
		/// <summary>
		/// The Constructor that sets the static variable errordetl to empty
		/// </summary>
		public dBRFLayer()
		{
			errordetl="";		
		}

		
		/// <summary>
		/// Opens the xl Connection
		/// </summary>
		/// <param name="filepath"></param>
		public void openXLConnection(string filepath)
		{
			XLConnStr ="Provider=Microsoft.Jet.OLEDB.4.0;" +
				"Data Source="+filepath+"; Jet OLEDB:Engine Type=5;"+
				"Extended Properties=Excel 8.0;";

			XLConn=new OleDbConnection(XLConnStr);
			XLConn.Open(); 
			XLCommand = new OleDbCommand();
			XLCommand.Connection = XLConn;
		}



		/// <summary>
		/// collects all sheets details from sheet named [DATA] into seperate arrays for checking errors
		/// </summary>
		/// <param name="sheettype"></param>
		/// <returns>Errors in ! seperated string</returns>
		public string checkXLErrors(string sheettype)
		{
			
			Utilities utl=new Utilities ();

			string [] name=null;
			string [] pallets=null;
			string [] trpriority=null;
			string [] overwritetcn=null;
			
			
			ArrayList namelist		=new ArrayList();
			ArrayList palletslist	=new ArrayList();
			ArrayList trprioritylist=new ArrayList();
			ArrayList overwritetcnlist  =new ArrayList();
			try
			{				
				if(sheettype=="DRY")					
				{
					XLCommand.CommandText = "SELECT * FROM [DATA$A1:D65536]";
				}
				if(sheettype=="CHILLED")					
				{
					XLCommand.CommandText = "SELECT * FROM [DATA$E1:H65536]";
				}
				if(sheettype=="FROZEN")					
				{
					XLCommand.CommandText = "SELECT * FROM [DATA$I1:L65536]";
				}
				XLdataReader = XLCommand.ExecuteReader();
			
			
				while (XLdataReader.Read())
				{
					namelist.Add(XLdataReader[0].ToString());
					palletslist.Add(XLdataReader[1].ToString());
					trprioritylist.Add(XLdataReader[2].ToString());
					overwritetcnlist.Add(XLdataReader[3].ToString());
				
					if(XLdataReader[0].ToString().Length ==0) break;
				}	
				XLdataReader.Close ();		
				XLCommand.Cancel();  

				name=(String[])namelist.ToArray(typeof(String));
				pallets=(String[])palletslist.ToArray(typeof(String));
				trpriority=(String[])trprioritylist.ToArray(typeof(String));
				overwritetcn=(String[])overwritetcnlist.ToArray(typeof(String));
			
				for(int i=0;i<(name.Length) ;i++)
				{
			
					if((name[i].Length   >0) && !utl.ValidateNumber(name[i].Trim()))
					{
					
						return "Error.[DATA] sheet entries should be numbers";
					}
				
					if(overwritetcn[i].ToUpper().Trim()!="YES" )
					{
						if(overwritetcn[i].ToUpper().Trim().Length > 0 )
						{
							return " OVERWRITE FIELDS MUST BE EITHER BLANK OR YES !";
						}
					}


					if(name[i].Length >0)
					{
						name[i]=sheettype+" "+Convert.ToInt32(name[i]);
						errordetl=chkRF(name[i],pallets[i],trpriority[i]);
					
					}

				}
			}
			catch
			{
				errordetl="PLEASE CHECK [DATA] SHEET AND MAKE SURE ITS IN CORRECT FORMAT ! "+errordetl; 
			}
				
			return errordetl;
		}
				
		
		/// <summary>
		/// checks all RF sheets for errors	
		/// </summary>
		/// <param name="cntrtype">Sheet name </param>
		/// <param name="pallets">Pallettes from DATA sheet</param>
		/// <param name="trpriority">TR Priority from DATA sheet</param>
		/// <returns></returns>
		public string chkRF(string cntrtype,string pallets,string trpriority)
		{
		
			Utilities utl=new Utilities();
			

			string tcn			=getExcelValue(cntrtype,"C19:C20");
			string container	=getExcelValue(cntrtype,"G10:G11");
			string carriercode	=getExcelValue(cntrtype,"G15:G16");
			int	   itemcnt		=0;
			string poe			=getExcelValue(cntrtype,"G16:G17");			
			string pod			=getExcelValue(cntrtype,"G17:G18");			
			string dodaac		=getExcelValue(cntrtype,"C9:C10");			
			string pvdodaac		=tcn.Substring (0,6);
			string jshipdate	=getExcelValue(cntrtype,"C18:C19");
			string stuffdate	=getExcelValue(cntrtype,"G9:G10");
			
			int datepart=stuffdate.IndexOf (' ');
			if (datepart !=-1)
			{
				stuffdate=stuffdate.Substring (0,datepart);
			}

			string shipdate		=stuffdate;
			string dlvrdate		=stuffdate;
			string pieces		="";
			string weight		=getExcelValue(cntrtype,"G11:G12");	
			string cube			="";
			string sealno		=getExcelValue(cntrtype,"G13:G14");	
			string dscp_ord_num	=getExcelValue(cntrtype,"G12:G13");
			string po_number	=getExcelValue(cntrtype,"G12:G13").Substring (0,6);
			string nsn			="";	
			string uom			="";
			string qty			="";
			string clin			="";
			
			int i=22;

			errordetl +=utl.checkMaxLength(cntrtype,dodaac,"DODAAC",8,"C10");
			errordetl +=utl.ValidateExcelInteger(cntrtype,jshipdate,"RDD","C19");
			errordetl +=utl.checkMaxLength(cntrtype,tcn,"CONTAINER TCN",20,"C20");
			errordetl +=utl.checkMaxLength(cntrtype,container,"CONTAINER #",15,"G11");
			errordetl +=utl.ValidateExcelNumber(cntrtype,weight,"GROSS WEIGHT(LBS)","G12");
			errordetl +=utl.checkMaxLength(cntrtype,sealno,"SEALNO",20,"G14");
			errordetl +=utl.checkMaxLength(cntrtype,carriercode,"SCAC",10,"G16");
			errordetl +=utl.checkMaxLength(cntrtype,poe,"POE",5,"G17");
			errordetl +=utl.checkMaxLength(cntrtype,pod,"POD",5,"G18");

			
			try
			{
				do 
				{
					clin			=getExcelValue(cntrtype,"A"+i+":A"+(i+1));	
					nsn				=getExcelValue(cntrtype,"B"+i+":B"+(i+1));	
					nsn				=nsn.Replace("-","");
					uom				=getExcelValue(cntrtype,"E"+i+":E"+(i+1));	
					qty				=getExcelValue(cntrtype,"F"+i+":F"+(i+1));
					qty				=qty.Replace (",","");

					if (nsn!="")
					{
						itemcnt++;

						/*			Validating values received from excel	 */	


						errordetl +=utl.ValidateExcelInteger(cntrtype,clin,"SI#","A"+(i));
						errordetl +=utl.checkMaxLength(cntrtype,nsn,"NSN#",15,"B"+(i));
						errordetl +=utl.checkMaxLength(cntrtype,uom,"UNIT",5,"E"+(i));
						errordetl +=utl.ValidateExcelNumber(cntrtype,qty,"QUANTITY","F"+(i));
						
					}// end of if (nsn!="")
					i++;
				}
				while (nsn!="");

				cube	  =	getExcelValue(cntrtype,"D"+i+":D"+(++i));
				pieces	  =	getExcelValue(cntrtype,"D"+i+":D"+(i+1));
				
				errordetl +=utl.ValidateExcelNumber(cntrtype,cube,"CUBIC FEET","D"+(i+1));
				errordetl +=utl.ValidateExcelNumber(cntrtype,pieces,"TOTAL NUMBER OF UNIT(S):","D"+(i+1));
				
			}

			catch (Exception ex)
			{
				
				string errorMsg = ex.Message;
				

			}
			
			return errordetl;

		}	




		/// <summary>
		/// collects all sheets details from sheet named [DATA] into seperate arrays for saving xl file
		/// </summary>
		/// <param name="sheettype">one of DRY,FROZEN or CHILLED</param>
		/// <param name="sheetssaved">A reference variable that stores all sheets successfully saved</param>
		/// <returns>Errors if any,in a ! seperated string</returns>
		public string SaveXLData(string sheettype,ref string sheetssaved)
		{
			
			Utilities utl=new Utilities ();
			string [] name=null;
			string [] pallets=null;
			string [] trpriority=null;
			string [] overwritetcn=null;
			string errorMsg="";
			
			ArrayList namelist		=new ArrayList();
			ArrayList palletslist	=new ArrayList();
			ArrayList trprioritylist=new ArrayList();
			ArrayList overwritetcnlist  =new ArrayList();

			try
			{
				if(sheettype=="DRY")					
				{
					XLCommand.CommandText = "SELECT * FROM [DATA$A1:D65536]";
				}
				if(sheettype=="CHILLED")					
				{
					XLCommand.CommandText = "SELECT * FROM [DATA$E1:H65536]";
				}
				if(sheettype=="FROZEN")					
				{
					XLCommand.CommandText = "SELECT * FROM [DATA$I1:L65536]";
				}
				XLdataReader = XLCommand.ExecuteReader();
			
			
				while (XLdataReader.Read())
				{
					namelist.Add(XLdataReader[0].ToString());
					palletslist.Add(XLdataReader[1].ToString());
					trprioritylist.Add(XLdataReader[2].ToString());
					overwritetcnlist.Add(XLdataReader[3].ToString());
				
					if(XLdataReader[0].ToString().Length ==0) break;
				}	
				XLdataReader.Close ();		
				XLCommand.Cancel(); 

				name=(String[])namelist.ToArray(typeof(String));
				pallets=(String[])palletslist.ToArray(typeof(String));
				trpriority=(String[])trprioritylist.ToArray(typeof(String));
				overwritetcn=(String[])overwritetcnlist.ToArray(typeof(String));
			
				for(int i=0;i<(name.Length) ;i++)
				{
			
					if((name[i].Length   >0) && !utl.ValidateNumber(name[i].Trim()))
					{
					
						return "Error.[DATA] sheet entries should be numbers";
					}
				
					if(overwritetcn[i].ToUpper().Trim()!="YES" )
					{
						if(overwritetcn[i].ToUpper().Trim().Length > 0 )
						{
							return " OVERWRITE Fields must be either blank or YES !";
						}
					}

					if(name[i].Length >0)
					{
						name[i]=sheettype+" "+Convert.ToInt32(name[i]);
						errorMsg+=saveRF(name[i],pallets[i],trpriority[i],overwritetcn[i],ref sheetssaved);
					
					}

						
				}
			}
			catch
			{
				errorMsg="PLEASE CHECK [DATA] SHEET AND MAKE SURE ITS IN CORRECT FORMAT ! "+errorMsg; 
			}
				
			return errorMsg;
		}
			
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cntrtype">Sheet Name</param>
		/// <param name="pallets">Pallettes from DATA sheet </param>
		/// <param name="trpriority">TR Priority from DATA sheet</param>
		/// <param name="overwritetcn">OVERWRITE from DATA sheet which indicates if an existing TCN is to be overwritten</param>
		/// <param name="sheetssaved">A reference variable that stores all sheets successfully saved</param>
		/// <returns>Errors if any,in a ! seperated string</returns>
		public string saveRF(string cntrtype,string pallets,string trpriority,string overwritetcn,ref string sheetssaved)
		{
			//the parameters are single record from [data] sheet.
			Utilities utl=new Utilities();
			string errorMsg="";				

			string tcn			=getExcelValue(cntrtype,"C19:C20");
			string container	=getExcelValue(cntrtype,"G10:G11");
			string carriercode	=getExcelValue(cntrtype,"G15:G16");
			int	   itemcnt		=0;
			string poe			=getExcelValue(cntrtype,"G16:G17");			
			string pod			=getExcelValue(cntrtype,"G17:G18");			
			string dodaac		=getExcelValue(cntrtype,"C9:C10");			
			string pvdodaac		=tcn.Substring (0,6);
			string jshipdate	=getExcelValue(cntrtype,"C18:C19");
			string stuffdate	=getExcelValue(cntrtype,"G9:G10");
			
			int datepart=stuffdate.IndexOf (' ');
			if (datepart !=-1)
			{
				stuffdate=stuffdate.Substring (0,datepart);
			}

			string shipdate		=stuffdate;
			string dlvrdate		=stuffdate;
			string pieces		="";
			string weight		=getExcelValue(cntrtype,"G11:G12");	
			string cube			="";
			string sealno		=getExcelValue(cntrtype,"G13:G14");	
			string dscp_ord_num	=getExcelValue(cntrtype,"G12:G13");
			string po_number	=getExcelValue(cntrtype,"G14:G15").Substring (0,6);
			string invoiceno	="";
			string nsn			="";	
			string uom			="";
			string qty			="";
			string clin			="";
			string ctype		="";
			string warehouse	="";
			string product		="";
			string dscp_desc	="";

					
			switch(cntrtype.Substring(0,3))
			{
				case "DRY":
					ctype="DRY";
					break;
				case "CHI":
					ctype="CHILLED";
					break;
				case "FRO":
					ctype="FROZEN";
					break;
				default:
					return "ERROR.THE SHEET NAMES ARE NOT IN CORRECT FORMAT !";
			}
			
			
			int i=22;
			
			try
			{
				// if records exist in pvrfdetl with same tcn they are deleted first
				sbConn.Length =0;
				sbConn.Append( "delete bmmifsv.pvrfdetl where TCN='"+tcn+"'" );
				dbCommand.CommandText = sbConn.ToString();
				retErr = dbCommand.ExecuteNonQuery();
				

				do 
				{
					clin			=getExcelValue(cntrtype,"A"+i+":A"+(i+1));	
					nsn				=getExcelValue(cntrtype,"B"+i+":B"+(i+1));	
					nsn				=nsn.Replace("-","");
					uom				=getExcelValue(cntrtype,"E"+i+":E"+(i+1));	
					qty				=getExcelValue(cntrtype,"F"+i+":F"+(i+1));
					qty				=qty.Replace (",","");

					if (nsn!="")
					{
						itemcnt++;

						sbConn.Length =0;
						sbConn.Append( "select WAREHOUSE,PRODUCT,DSCP_DESC from bmmi.pvcatcurr " );
						sbConn.Append( "where STOCK_NUMBER=");
						sbConn.Append("'"+nsn+"'" );
						dbCommand.CommandText = sbConn.ToString();
						dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
						dataReader.Read();
						if (dataReader.HasRows) 
						{
							warehouse = dataReader[0].ToString().Trim ();
							product	  =	dataReader[1].ToString().Trim ();
							dscp_desc = dataReader[2].ToString().Trim ();
							dscp_desc = dscp_desc.Replace ("&",",");
						}
						dataReader.Close(); 


						errorMsg+= RF_addDetl(tcn,container,dscp_ord_num,po_number,warehouse,
							product,nsn,"","",uom,qty,
							0,0,0,"","",dscp_desc,"","","",invoiceno,
							clin,"I");		
					
						
					}// end of if (nsn!="")
					i++;
				}
				while (nsn!="");

				cube	  =	getExcelValue(cntrtype,"D"+i+":D"+(++i));
				pieces	  =	getExcelValue(cntrtype,"D"+i+":D"+(i+1));
				
				//Header is added at the end to collect cube and pieces values
				//which are at the end of the xl sheet
				errorMsg+= RF_addHeader(tcn,container,carriercode,itemcnt,0,poe, pod,
					dodaac,pvdodaac,jshipdate,
					stuffdate,shipdate,dlvrdate,pieces,
					weight,cube,
					trpriority,"",ctype,sealno,"",
					pallets,"H","",overwritetcn,cntrtype);

				sheetssaved+=cntrtype+"!";
		
			}
			catch (Exception ex)
			{
				
				errorMsg = ex.Message;
				return cntrtype+"=>"+errorMsg+"!";

			}
			return errorMsg;
		}	

		
		/// <summary>
		/// Saves the Header part of the RF file 
		/// </summary>
		/// <param name="tcn"></param>
		/// <param name="container">Container number</param>
		/// <param name="carriercode"></param>
		/// <param name="itemcnt">Number of items in RF file</param>
		/// <param name="tcmdcount">Empty</param>
		/// <param name="poe"></param>
		/// <param name="pod"></param>
		/// <param name="dodaac"></param>
		/// <param name="pvdodaac"></param>
		/// <param name="jshipdate">RDD field in RF file</param>
		/// <param name="stuffdate">Date field in RF file</param>
		/// <param name="shipdate">Date field in RF file</param>
		/// <param name="dlvrdate">Date field in RF file</param>
		/// <param name="pieces"></param>
		/// <param name="weight"></param>
		/// <param name="cube"></param>
		/// <param name="trpriority">from DATA sheet</param>
		/// <param name="hazmat">empty</param>
		/// <param name="cntrtype">dry chilled or frozen</param>
		/// <param name="sealno"></param>
		/// <param name="jver"></param>
		/// <param name="pallets">from DATA sheet</param>
		/// <param name="tcnstatus"></param>
		/// <param name="freetext">empty</param>
		/// <param name="overwritetcn">from DATA sheet</param>
		/// <param name="sheetname"></param>
		/// <returns></returns>
		public string RF_addHeader( string tcn,string container,string carriercode,int itemcnt,
			int tcmdcount,string poe,string  pod,string dodaac,
			string pvdodaac,string jshipdate,string stuffdate,
			string shipdate,string dlvrdate,string pieces,
			string weight,string cube,string trpriority,string hazmat,
			string cntrtype,string sealno,string jver,
			string pallets,string tcnstatus,string freetext,string overwritetcn,
			string sheetname
			)	
			
		{
			string errorMsg="";
							
			try
			{

				// check for duplicate tcns in pvrfhead tables
				dbCommand.CommandText = "SELECT TCN FROM bmmifsv.pvrfhead where trim(tcn)='"+tcn+"'";
				dataReader = dbCommand.ExecuteReader();
				dataReader.Read ();
			
				if (dataReader.HasRows && overwritetcn.ToUpper()=="")
				{
					errorMsg=sheetname+"-=> Record with TCN "+tcn+ " is duplicate !";
					dataReader.Close ();	
					return errorMsg;
				}
				// overwrite if specified
				if (dataReader.HasRows && overwritetcn.ToUpper()=="YES")
				{
					dataReader.Close ();	
					sbConn.Length =0;
					sbConn.Append( "update bmmifsv.pvrfhead set " );
					sbConn.Append( "CONTAINER='"+container+"'," );
					sbConn.Append( "CARRIERCODE='"+carriercode+"'," );
					sbConn.Append( "ITEMCNT="+itemcnt+"," );
					sbConn.Append( "TCMDCOUNT="+tcmdcount+"," );
					sbConn.Append( "POE='"+poe+"'," );
					sbConn.Append( "POD='"+pod+"'," );
					sbConn.Append( "DODAAC='"+dodaac+"'," );
					sbConn.Append( "PVDODAAC='"+pvdodaac+"'," );
					sbConn.Append( "JSHIPDATE="+jshipdate+"," );
					sbConn.Append( "STUFFDATE=to_date('"+stuffdate+"','mm/dd/rrrr'),");
					sbConn.Append( "SHIPDATE=to_date('"+shipdate+"','mm/dd/rrrr'),");
					sbConn.Append( "DLVRDATE=to_date('"+dlvrdate+"','mm/dd/rrrr'), ");
					sbConn.Append( "PIECES="+pieces+",");
					sbConn.Append( "WEIGHT="+weight+"," );
					sbConn.Append( "CUBE="+cube+"," );
					sbConn.Append( "TRPRIORITY='"+trpriority+"'," );
					sbConn.Append( "HAZMAT='"+hazmat+"'," );
					sbConn.Append( "CNTRTYPE='"+cntrtype+"'," );
					sbConn.Append( "SEALNO='"+sealno+"'," );
					sbConn.Append( "JVER='"+jver+"'," );
					sbConn.Append( "PALLETS="+pallets+"," );
					sbConn.Append( " TCNSTATUS='"+tcnstatus+"'," );
					sbConn.Append( " FREETEXT='"+freetext+"'");
					sbConn.Append( " where trim(tcn)='"+tcn+"'");
					dbCommand.CommandText = sbConn.ToString ();
					retErr = dbCommand.ExecuteNonQuery();
					
				
				}
					// if the tcn is not in DB insert the new record into database.
				else
				{
					dataReader.Close ();	
					sbConn.Length =0;
					sbConn.Append( "INSERT INTO bmmifsv.pvrfhead" );
					sbConn.Append( " values( '" );
					sbConn.Append( tcn );
					sbConn.Append( "','" );
					sbConn.Append( container );
					sbConn.Append( "','" );
					sbConn.Append( carriercode );
					sbConn.Append( "'," );
					sbConn.Append( itemcnt );
					sbConn.Append( "," );
					sbConn.Append( tcmdcount );
					sbConn.Append( ",'" );
					sbConn.Append( poe );
					sbConn.Append( "','" );
					sbConn.Append( pod );
					sbConn.Append( "','" );
					sbConn.Append( dodaac );
					sbConn.Append( "','" );
					sbConn.Append( pvdodaac );
					sbConn.Append( "'," );
					sbConn.Append( jshipdate );
					sbConn.Append( ",to_date('");
					sbConn.Append( stuffdate );
					sbConn.Append( "','mm/dd/rrrr'),to_date('");
					sbConn.Append( shipdate );
					sbConn.Append( "','mm/dd/rrrr'),to_date(' ");
					sbConn.Append( dlvrdate );
					sbConn.Append( "','mm/dd/rrrr'),");
					sbConn.Append( pieces );
					sbConn.Append( "," );
					sbConn.Append( weight );
					sbConn.Append( "," );
					sbConn.Append( cube );
					sbConn.Append( ",'" );
					sbConn.Append( trpriority );
					sbConn.Append( "','" );
					sbConn.Append( hazmat );
					sbConn.Append( "','" );
					sbConn.Append( cntrtype );
					sbConn.Append( "','" );
					sbConn.Append( sealno );
					sbConn.Append( "','" );
					sbConn.Append( jver );
					sbConn.Append( "'," );
					sbConn.Append( pallets );
					sbConn.Append( ",'" );
					sbConn.Append( tcnstatus );
					sbConn.Append( "','" );
					sbConn.Append( freetext );
					sbConn.Append( "')" );
			
					dbCommand.CommandText = sbConn.ToString();
					retErr = dbCommand.ExecuteNonQuery();
				}
				
			}
			catch (Exception ex)
			{
				errorMsg += ex.Message+" ! ";
				return errorMsg;
			}
			
			return errorMsg;
		}

		/// <summary>
		/// Saves Detail Records of the RF Records
		/// </summary>
		/// <param name="tcn">Transport Control number.</param>
		/// <param name="container">Container number</param>
		/// <param name="dscp_ord_num"></param>
		/// <param name="po_number"></param>
		/// <param name="warehouse"></param>
		/// <param name="product"></param>
		/// <param name="nsn"></param>
		/// <param name="lin"></param>
		/// <param name="ric"></param>
		/// <param name="uom"></param>
		/// <param name="qty"></param>
		/// <param name="pallets">empty</param>
		/// <param name="weight">empty</param>
		/// <param name="cube">empty</param>
		/// <param name="condcode">empty</param>
		/// <param name="intmtcn"></param>
		/// <param name="dscp_desc"></param>
		/// <param name="misc1">empty</param>
		/// <param name="misc2">empty</param>
		/// <param name="ctg_desc"></param>
		/// <param name="inv_no"></param>
		/// <param name="clin">SL Number</param>
		/// <param name="linestatus"></param>
		/// <returns>Errors if any</returns>
		/// <remarks >RF detail Records are added in a loop</remarks>
		public string RF_addDetl(string tcn,string container,string dscp_ord_num,
			string po_number,string warehouse,string product,
			string nsn,string lin,string ric,string uom,
			string qty,int pallets,double weight,double cube,
			string condcode,string intmtcn,string dscp_desc,
			string misc1,string misc2,string ctg_desc,
			string inv_no,string clin,string linestatus
			)

		{
			string errorMsg="";
						
			sbConn.Length =0; 
			
			
			try
			{
			
				sbConn.Length =0;
				sbConn.Append( "INSERT INTO bmmifsv.pvrfdetl" );
				sbConn.Append( " values( '" );
				sbConn.Append( tcn );
				sbConn.Append( "','" );
				sbConn.Append( container );
				sbConn.Append( "','" );
				sbConn.Append( dscp_ord_num );
				sbConn.Append( "','" );
				sbConn.Append( po_number );
				sbConn.Append( "','" );
				sbConn.Append( warehouse );
				sbConn.Append( "','" );
				sbConn.Append( product );
				sbConn.Append( "','" );
				sbConn.Append( nsn );
				sbConn.Append( "','" );
				sbConn.Append( lin );
				sbConn.Append( "','" );
				sbConn.Append( ric );
				sbConn.Append( "','" );
				sbConn.Append( uom );
				sbConn.Append( "'," );
				sbConn.Append( qty );
				sbConn.Append( "," );
				sbConn.Append( pallets );
				sbConn.Append( "," );
				sbConn.Append( weight );
				sbConn.Append( "," );
				sbConn.Append( cube );
				sbConn.Append( ",'" );
				sbConn.Append( condcode );
				sbConn.Append( "','" );
				sbConn.Append( intmtcn );
				sbConn.Append( "',trim('" );
				sbConn.Append( dscp_desc );
				sbConn.Append( "'),'" );
				sbConn.Append( misc1 );
				sbConn.Append( "','" );
				sbConn.Append( misc2 );
				sbConn.Append( "','" );
				sbConn.Append( ctg_desc );
				sbConn.Append( "','" );
				sbConn.Append( inv_no );
				sbConn.Append( "','" );
				sbConn.Append( clin );
				sbConn.Append( "','" );
				sbConn.Append( linestatus );
				sbConn.Append( "')" );
			
				dbCommand.CommandText = sbConn.ToString();
				retErr = dbCommand.ExecuteNonQuery();
				
			}
			catch (Exception ex)
			{
				errorMsg = ex.Message;
				return errorMsg;
				
			}
			return errorMsg;
		}

		
		/// <summary>
		/// Retrieves a particular value from Excel sheet
		/// </summary>
		/// <param name="sheetname"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		public string getExcelValue(string sheetname,string range)
		{
			
						
			string excelvalue="";
						
			XLCommand.CommandText = "SELECT * FROM ["+sheetname+"$"+range+"]";
			
			XLdataReader = XLCommand.ExecuteReader(CommandBehavior.Default);
			

			while (XLdataReader.Read())
			{
				excelvalue = XLdataReader[0].ToString();
			}

			XLdataReader.Close ();
			XLCommand.Cancel();
			return excelvalue.Trim();
			
			
		}


		/// <summary>
		/// Closes the excel connection established for reading values
		/// </summary>
		public void closeXLconnection()
		{
			XLdataReader.Close ();		
			XLCommand.Cancel(); 
			XLConn.Close();
		}


	}




	/// <summary>
	/// Database related function for Purchase Analysis is
	/// defined in dbPurAnalysis class
	/// </summary>
	public class dbPurAnalysis:db
	{


		/// <summary>
		/// Returns the supplier Name from stockm table suggested by CS3 
		/// </summary>
		/// <param name="product"></param>
		/// <param name="warehouse"></param>
		/// <returns>Origninal Supplier Name for a product Suggested by cs3</returns>
		public string getstockmsupplier(string product,string warehouse)
		{

			string origsup="";
			try
			{
				strSql = " select B.VENDOR_DISPNAME from stockm A,pvsupmast B "+
					" where trim(A.supplier)=trim(b.vendor_code) "+
					" and trim(A.product)=trim('"+product+"') "+
					" and A.warehouse='"+warehouse+"'" ;
						 
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if(dataReader.HasRows )
				{
					origsup=dataReader[0].ToString().Trim ();
				}
				else
				{
					origsup="";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
			}
			finally
			{
				dataReader.Close ();
			}
			return origsup;
		}




		/// <summary>
		/// Returns the supplier id for the supplier from stockm table suggested by CS3 
		/// </summary>
		/// <param name="product"></param>
		/// <param name="warehouse"></param>
		/// <returns>Origninal the supplier id for the Supplier Suggested by cs3</returns>
		public string getstockmsupplierid(string product,string warehouse)
		{

			string origsup="";
			try
			{
				strSql = " select B.VENDOR_ID from stockm A,pvsupmast B "+
					" where trim(A.supplier)=trim(b.vendor_code) "+
					" and trim(A.product)=trim('"+product+"') "+
					" and A.warehouse='"+warehouse+"'" ;
						 
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if(dataReader.HasRows )
				{
					origsup=dataReader[0].ToString().Trim ();
				}
				else
				{
					origsup="";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
			}
			finally
			{
				dataReader.Close ();
			}
			return origsup;
		}



		/// <summary>
		/// Returns product details for a nsn
		/// </summary>
		/// <param name="nsn"></param>
		/// <returns>a collection of arrays containing product details, in an arraylist</returns>
		public ArrayList getProductdetls(string nsn)
		{
			ArrayList productdetls=new ArrayList ();
			ArrayList product=new ArrayList ();
			ArrayList desc=new ArrayList ();
			ArrayList stocknum=new ArrayList ();
			ArrayList purchunit=new ArrayList ();
			ArrayList warehouse=new ArrayList ();

			try
			{
				strSql = "select PRODUCT, DSCP_DESC,STOCK_NUMBER,PURCHASE_UNIT,WAREHOUSE from PVCATCURR where trim(STOCK_NUMBER)=trim('"+nsn+"') and WAREHOUSE NOT LIKE '%Z'";
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				while (dataReader.Read())
				{
					product.Add (dataReader[0].ToString().Trim ());
					desc.Add (dataReader[1].ToString().Trim ());
					stocknum.Add (dataReader[2].ToString().Trim ());
					purchunit.Add (dataReader[3].ToString().Trim ());
					warehouse.Add (dataReader[4].ToString().Trim ());
				}
				productdetls.Add (product);
				productdetls.Add (desc);
				productdetls.Add (stocknum);
				productdetls.Add (purchunit);
				productdetls.Add (warehouse);
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
			}
			finally
			{
				dataReader.Close ();
			}

			return productdetls;

		}




		/// <summary>
		/// Collect cost records of all suppliers who sell the specific product with the given nsn 
		/// </summary>
		/// <param name="nsn"></param>
		/// <returns>Collection of all cost Records from pvsupcscurr, for the given nsn  </returns>
		public ArrayList getDetlTblRecords(string nsn)
		{
			ArrayList DetlTblRecords=new ArrayList ();

			ArrayList vendorid		=	new ArrayList ();
			ArrayList bmmicost		=	new ArrayList ();
			ArrayList mfgcost		=	new ArrayList ();
			ArrayList napa			=	new ArrayList ();
			ArrayList vendordistfee =	new ArrayList ();
			ArrayList bmmidistfee	=	new ArrayList ();
			ArrayList bmmicurrprice =	new ArrayList ();
			ArrayList purchunit		=	new ArrayList ();
			ArrayList leadtime		=	new ArrayList ();
			ArrayList leadtimevar	=	new ArrayList ();
 
			try
			{
			
				strSql =  " select A.VENDOR_ID,A.BMMI_COST,A.MFG_COST,A.NAPA,A.VENDOR_DIST_FEE, "+
					" A.BMMI_DIST_FEE,A.BMMI_CURR_PRICE,A.PURCH_UNIT,B.LEAD_TIME,B.LEAD_TIME_VAR "+ 
					" from pvsupcscurr A,pvsupmast B WHERE A.VENDOR_ID=B.VENDOR_ID "+
					" AND trim(A.NSN)=trim('"+nsn+"') AND B.VENDOR_TYPE='A' "; 

				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				while (dataReader.Read())
				{
					vendorid.Add (dataReader[0].ToString().Trim ());
					bmmicost.Add (dataReader[1].ToString().Trim ());
					mfgcost.Add (dataReader[2].ToString().Trim ());
					napa.Add (dataReader[3].ToString().Trim ());
					vendordistfee.Add (dataReader[4].ToString().Trim ());
					bmmidistfee.Add (dataReader[5].ToString().Trim ());
					bmmicurrprice.Add (dataReader[6].ToString().Trim ());
					purchunit.Add (dataReader[7].ToString().Trim ());
					leadtime.Add (dataReader[8].ToString().Trim ());
					leadtimevar.Add (dataReader[9].ToString().Trim ());
						
				}
				DetlTblRecords.Add (vendorid);
				DetlTblRecords.Add (bmmicost);
				DetlTblRecords.Add (mfgcost);
				DetlTblRecords.Add (napa);
				DetlTblRecords.Add (vendordistfee);
				DetlTblRecords.Add (bmmidistfee);
				DetlTblRecords.Add (bmmicurrprice);
				DetlTblRecords.Add (purchunit);
				DetlTblRecords.Add (leadtime);
				DetlTblRecords.Add (leadtimevar);
					
				
				
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
			}
			finally
			{
				dataReader.Close ();
			}

			return DetlTblRecords;
		}




		/// <summary>
		/// Returns the collection of supplier names for a collection of vendor_ids
		/// </summary>
		/// <param name="vendorid"></param>
		/// <returns>Collection of supplier Names</returns>
		public string[]  getSupplierName(string[] vendorid)
		{

			
			ArrayList vendorname=new ArrayList();
			
			try
			{

				for(int i=0;i<vendorid.Length;i++)
				{
					strSql = "select trim(vendor_dispname) from pvsupmast where trim(vendor_id)=trim('"+vendorid[i] +"') and vendor_type='A' ";
					dbCommand.CommandText = strSql;
					dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				
					dataReader.Read();
					if (dataReader.HasRows) 
					{
						vendorname.Add (dataReader[0].ToString().Trim ());
											
					}
					else
					{
						vendorname.Add ("");
					}
					dataReader.Close(); 
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message;
				
			}
			finally 
			{
			
				
			}
			return (String[])vendorname.ToArray(typeof(String));


		}


		/// <summary>
		/// Gets the supplier name for a vendor id
		/// </summary>
		/// <param name="vendorid"></param>
		/// <returns></returns>
		public string getSuppliername_selected(string vendorid)
		{
			string vendorname="";	
			strSql = "select vendor_dispname from pvsupmast where trim(vendor_id)= trim("+vendorid+")";
				
			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					vendorname = dataReader[0].ToString().Trim ();
											
				}
				else
				{
					vendorname="";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				vendorname = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return vendorname;
		}




		/// <summary>
		/// gets the vendors_analysed field for a poplanno
		/// </summary>
		/// <param name="pano"></param>
		/// <returns></returns>
		public string getVendors_analysed(string pano)
		{
			string vendorsanalysed="";	
			strSql = "select VENDORS_ANALYSED from pvpahead where trim(POPLANNO)= trim("+pano+")";
				

			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					vendorsanalysed = dataReader[0].ToString().Trim ();
											
				}
				else
				{
					vendorsanalysed="";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				vendorsanalysed = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return vendorsanalysed;
		}



		/// <summary>
		/// gets the analysed_on field for a poplanno
		/// </summary>
		/// <param name="pano"></param>
		/// <returns></returns>
		public string getanalysed_on(string pano)
		{
			string analysed_on="";	
			strSql = "select ANALYSISON_FLAG from pvpahead where trim(POPLANNO)= trim("+pano+")";
				

			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					analysed_on = dataReader[0].ToString().Trim ();
											
				}
				else
				{
					analysed_on="";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				analysed_on = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return analysed_on;
		}



		/// <summary>
		/// gets the analysedon_data field for a poplanno
		/// </summary>
		/// <param name="pano"></param>
		/// <returns></returns>
		public string getanalysedon_data(string pano)
		{
			string analysison_data="";	
			strSql = "select  ANALYSISON_DATA from pvpahead where trim(POPLANNO)= trim("+pano+")";
				

			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();
				if (dataReader.HasRows) 
				{
					analysison_data = dataReader[0].ToString().Trim ();
											
				}
				else
				{
					analysison_data="";
				}
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				analysison_data = "";
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return analysison_data;
		}




		/// <summary>
		/// gets the nsns for a poplanno in a string array
		/// </summary>
		/// <param name="pano"></param>
		/// <returns></returns>
		public string[] getNSNsAnalysed(string pano)
		{
			
			ArrayList nsnlist=new ArrayList();
			string[] arrnsnlist=null;
			strSql = "select  nsn from pvpadetl where trim(POPLANNO)= trim("+pano+")";
				

			try 
			{
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				
				while(dataReader.Read()) 
				{
					nsnlist.Add(dataReader[0].ToString().Trim ());
											
				}
				arrnsnlist=(String[])nsnlist.ToArray(typeof(String));
				
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				arrnsnlist = null;
			}
			finally 
			{
				dataReader.Close(); 
				
			}
			return arrnsnlist;

		}




		/// <summary>
		/// Collects all the Remarks available for purchase Analysis
		/// </summary>
		/// <returns></returns>
		public ArrayList collectPARemarks()
		{
			ArrayList PAremarks	=new ArrayList ();
			ArrayList Remid		=new ArrayList ();
			ArrayList Remarks	=new ArrayList ();
			
			try
			{
				strSql	= " select A.REMID,A.REMARKS from PVREMDESC A,PVREMHEAD B "+
					" where A.REMTYPE=B.REMTYPE AND B.REMTYPE = 1 ";
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				
				while (dataReader.Read()) 
				{
					Remid.Add (dataReader[0].ToString().Trim ());
					Remarks.Add(dataReader[1].ToString().Trim ());
					
				}
				dataReader.Close(); 
				PAremarks.Add (Remid);
				PAremarks.Add (Remarks);
			}
			catch
			{
				PAremarks=null;
			}
			return PAremarks;

		}



		/// <summary>
		/// Saves Purchase Analysis 
		/// </summary>
		/// <param name="poplanno"></param>
		/// <param name="nsnlist"> '!' seperated list of nsns analysed</param>
		/// <param name="remarksList"> '!' seperated list of remarks</param>
		/// <param name="selsupList"> '!' seperated suppliers chosen for each product</param>
		/// <param name="origvendorlist">A '!' seperated list of original vendors taken from stockm table for the products chosen</param>
		/// <param name="vendorsAnlaysed">A '!' seperated list of vendors analysed</param>
		/// <param name="analysisonflag">
		/// Indicates On which basis Products are selected for analysis.
		/// w-warehouse n-nsn a-all products s-supplier
		/// </param>
		/// <param name="analysisondata">The value for the analysis on flag
		///  eg:if analysison flag is w then the data may be one of VA,VC etc</param>
		/// <param name="analysisby">Margin or leadtime a supplier provides</param>
		/// <returns>Error Descriptions if any</returns>
		
		public string savePA(string poplanno,string nsnlist,string remarksList,string selsupList,
			string origvendorlist,string vendorsAnlaysed,string analysisonflag,
			string analysisondata, string analysisby )
		{
			string[] arrnsn=nsnlist.Split ('!');
			string[] remarkid=remarksList.Split ('!');
			string[] vid=selsupList.Split ('!');
			string[] origvendor=origvendorlist.Split ('!');

			string productno="";
			string desc		="";
			string nsn		="";
			string punit	="";
			string warehouse="";
			string bmmidfee ="";
			string vendordistfee="";		
			string bmmicost="";				
			string mfgcost	="";	
			string bmmicurrprice="";
			string napa		="";			
			string remarks	="";
			string errorMsg ="";
		
			try
			{
				//if  records exist with same plan no delete them
				strSql = " delete PVPAHEAD where POPLANNO="+poplanno;

				dbCommand.CommandText = strSql;
				dbCommand.ExecuteNonQuery();

				
				strSql = " delete PVPADETL where POPLANNO="+poplanno;

				dbCommand.CommandText = strSql;
				dbCommand.ExecuteNonQuery();
				
				
				// insert header records
				strSql = " insert into PVPAHEAD(POPLANNO,POPLANDATE,VENDORS_ANALYSED,ANALYSISON_FLAG,ANALYSISON_DATA,ANALYSISBY,STATUS) "+
					" values ("+poplanno+",sysdate,'"+vendorsAnlaysed+"','"+analysisonflag+"','"+analysisondata+"','"+analysisby+"','0') " ;

				dbCommand.CommandText = strSql;
				dbCommand.ExecuteNonQuery();

				//get product details for each NSN
				for(int i=0;i<arrnsn.Length-1;i++)
				{
				
					strSql	=	" select PRODUCT, DSCP_DESC,STOCK_NUMBER,PURCHASE_UNIT,WAREHOUSE "+
						" from PVCATCURR where trim(STOCK_NUMBER)=trim('"+arrnsn[i]+"') and WAREHOUSE NOT LIKE '%Z' ";
					
					dbCommand.CommandText = strSql;
					dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
					dataReader.Read();
					if (dataReader.HasRows) 
					{
						productno	=dataReader[0].ToString();
						desc	    =dataReader[1].ToString();
						nsn			=dataReader[2].ToString();
						punit		=dataReader[3].ToString();
						warehouse	=dataReader[4].ToString();
						
					}
					else
					{
						productno	="";
						desc	    ="";
						nsn			="";
						punit		="";
						warehouse	="";
					}

					dataReader.Close(); 
					
					
					//seelct cost records for each nsn with each vendor id
					strSql = " select nvl(BMMI_DIST_FEE,'0'),nvl(VENDOR_DIST_FEE,'0'),nvl(NAPA,'0')," +
						" nvl(BMMI_COST,'0'),nvl(BMMI_CURR_PRICE,'0'),nvl(MFG_COST,'0') from pvsupcscurr " +
						" where NSN='"+nsn+"' and TRIM(VENDOR_ID)=trim("+vid[i]+")";
 
					dbCommand.CommandText = strSql;
					dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
					dataReader.Read();
					if (dataReader.HasRows) 
					{
						bmmidfee=dataReader[0].ToString();
						vendordistfee=dataReader[1].ToString();
						napa=dataReader[2].ToString();
						bmmicost=dataReader[3].ToString();			
						bmmicurrprice=dataReader[4].ToString();
						mfgcost	=dataReader[5].ToString();	
						
					}
					else
					{
					
						bmmidfee="0";
						vendordistfee="0";
						napa="0";
						bmmicost="0";
						bmmicurrprice="0";
						mfgcost	="0";
					
					}
					dataReader.Close(); 
	
					
					// collect remarks for each remark id
					strSql	= " select REMARKS from PVREMDESC "+
						" where TRIM(REMID)=trim('"+remarkid[i]+"')";
	
					dbCommand.CommandText = strSql;
					dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
					dataReader.Read();
					if (dataReader.HasRows) 
					{
						remarks=dataReader[0].ToString();
					}
					else
					{
						remarks="";
					}
					dataReader.Close(); 
					// if original venor id not found set original vendor id to zero.
					if(origvendor[i]=="")
						origvendor[i]="0";

					// insert collected data into detail table of purchase Analysis
					strSql = " insert into PVPADETL(POPLANNO,WAREHOUSE,PRODUCT,NSN,ORIG_VENDOR_ID, "+
						" PURCH_UNIT,VENDOR_ID,STATUS,REMARKS,PLAN_QTY,MFG_COST,VENDOR_DIST_FEE,NAPA,BMMI_COST,BMMI_DIST_FEE,BMMI_CURR_PRICE) "+
						" values ("+poplanno+",trim('"+warehouse+"'),trim('"+productno+"'),trim('"+nsn+"'),nvl("+origvendor[i]+",0)," +
						" trim('"+punit+"'),"+vid[i]+",'O',nvl('"+remarks+"','0'),0,nvl("+mfgcost+",0),nvl("+vendordistfee+",0),nvl("+napa+",0),nvl("+bmmicost+",0),nvl("+bmmidfee+",0),nvl("+bmmicurrprice+",0))";

									
					dbCommand.CommandText = strSql;
					dbCommand.ExecuteNonQuery();
					
							
				

				}
			}
			catch(Exception Ex)
			{
				errorMsg=Ex.Message ;
			}
			
			return errorMsg;
		}



		/// <summary>
		/// Checks if at least one supplier in the vidlist provides a product with the given nsn
		/// </summary>
		/// <param name="nsn"></param>
		/// <param name="vidlist"></param>
		/// <returns></returns>
		public string chkproduct(string nsn,string vidlist)
		{
			string retnsn="";

			try
			{
				strSql = "select nsn from PVSUPCSCURR where trim(nsn)=trim('"+nsn+"')and vendor_id in("+vidlist+")";
				dbCommand.CommandText = strSql;
				dataReader = dbCommand.ExecuteReader(CommandBehavior.Default);
				dataReader.Read();

				if(dataReader.HasRows )
				{
					retnsn=dataReader[0].ToString ();
				
				}

				else
				{
					retnsn="";
				}

			}
			catch(Exception ex)
			{
				string error=ex.Message ;
			}

			finally
			{
				dataReader.Close ();
			}

			return retnsn;

		
		}


	}
}
