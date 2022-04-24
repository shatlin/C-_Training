using System;
using System.Collections; 

namespace Collections
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//////////////////Collections//////////////
			
				Console.WriteLine ("Arrayist\n\n");
				arraylist();
				Console.WriteLine ("BitArray\n\n");
				bitarray();
				Console.WriteLine ("HashTable\n\n");
				hashtable();
				Console.WriteLine ("Queue\n\n");
				queue();
				Console.WriteLine ("SortedList\n\n");
				sortedlist();
			
			///////////////////////////////////////////////
			
			Class3 cl3= new Class4();
			Class3 cl4= new Class5();
			cl3.showname();
			cl4.showname();
			Console.ReadLine();
		}

		static void arraylist()
		{
			// create arraylist instance
			ArrayList myList = new ArrayList();
			Class2 [] cl2=new Class2[5];
			
			myList.Add(cl2[0]=new Class2());
			myList.Add(cl2[1]=new Class2());
			myList.Add(cl2[2]=new Class2());
			myList.Add(cl2[3]=new Class2());
			myList.Add(cl2[4]=new Class2());

			// sort array items
			myList.Reverse(); ;
			
			// remove first two items
			myList.RemoveRange(0, 2);
			
			// output final 3 item after sorting
			
			foreach (Object item in myList)
			{
				Class2 cla2=new Class2();
				cla2=(Class2)item;
				int i=cla2.getI();
				Console.WriteLine(i);
			}
			Console.ReadLine(); 
		}


		static void bitarray()
		{
			// initialize BitArray with boolean values
			bool[] values1 = {true, false, true, false, true, false,
								 false};
			BitArray myArray = new BitArray(values1);
			foreach (Object item in myArray)
			{
				// output value will the same as declared in array
				 Console.WriteLine(item);
			}
			Console.WriteLine("---------------Bits from Int---------------");
				// 110000.....0
				// first two bits are 1, others 0, first two out value will
			int[] values2 = {1};
			myArray = new BitArray(values2);
			int i=0;
			foreach (Object item in myArray)
			{
				Console.Write(i++ +":"+item + " "+"\n");
			}
			Console.ReadLine(); 
		}


		static void hashtable()
		{
			Hashtable myHash = new Hashtable();
			// add key-pair values
			myHash.Add("First", 1);
			myHash.Add("Second", 2);
			myHash.Add("Third", 3);
			// move through hashtable data in cycle
			foreach (DictionaryEntry item in myHash)
			{
				Console.WriteLine(item.Key);
				Console.WriteLine(item.Value);
			}
			// get first item
			Console.WriteLine("Get first item: " + myHash["First"]);
			// this will not work, name of item is not identical
			Console.WriteLine("Get second item: " + myHash["SECOND"]);

			getHashTableValues(myHash);
			Console.ReadLine();
		}

		static void getHashTableValues(Hashtable HT)
		{
			IDictionaryEnumerator IDEnum=HT.GetEnumerator();
			while(IDEnum.MoveNext())
			{
				Console.WriteLine("The Key {0} and The value {1}",IDEnum.Key,IDEnum.Value );
			}

		}

		static void queue()
		{
			Queue myQueue = new Queue();
			// put some values into queue
			myQueue.Enqueue(0);
			myQueue.Enqueue(2);
			myQueue.Enqueue(3);
			// get values from queue (first in - first out)
			while (myQueue.Count > 0)
			{
				Console.WriteLine(myQueue.Dequeue());
			}
			Console.ReadLine(); 
		}

		static void sortedlist()
		{
			// values in sorted list are sorted according to key
			SortedList myList = new SortedList();
			try
			{
				myList.Add(12, "December");
				myList.Add(9, "September");
				myList.Add(10, "October");
				myList.Add(4, "April");
				myList.Add(5, "May");
				myList.Add(6, "June");
				myList.Add(2, "February");
				myList.Add(8, "August");
				myList.Add(7, "July");
				myList.Add(3, "March");
				myList.Add(11, "November");
				myList.Add(1, "January");
				// output values that are sorted according to key
				foreach (DictionaryEntry item in myList)
				{
					Console.WriteLine(item.Value);
				}
			}
			catch
			{
					Console.WriteLine("Error in sortedList");
			}
			Console.ReadLine();
		}

	}
	class Class2
	{
		private int i;
		public Class2()
		{
			i=10;
		}
		public int getI()
		{
			return 2*i;
		}
	}

	class Class3
	{
		protected string name="Hello";
		public virtual void showname()
		{
			Console.WriteLine(name);
		}
	}

	class Class4:Class3
	{
		public override void showname()
		{
			Console.WriteLine(name+ "hi"+name); 
		}
	}

	class Class5:Class4
	{
		public override void showname()
		{
			Console.WriteLine(name+ "hi hi  hi"+name); 
		}
	}
}
