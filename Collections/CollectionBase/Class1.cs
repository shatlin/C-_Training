using System;
using System.Collections;

namespace CollectionBase2
{


	public class Int16Collection : CollectionBase  
	{

		public Int16 this[ int index ]  
		{
			get  
			{
				return( (Int16) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}
ISerializable
		public int Add( Int16 value )  
		{
			return( List.Add( value ) );
		}

		public int IndexOf( Int16 value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, Int16 value )  
		{
			List.Insert( index, value );
		}

		public void Remove( Int16 value )  
		{
			List.Remove( value );
		}

		public bool Contains( Int16 value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )  
		{
			// Insert additional code to be run only when inserting values.
		}

		protected override void OnRemove( int index, Object value )  
		{
			// Insert additional code to be run only when removing values.
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )  
		{
			// Insert additional code to be run only when setting values.
		}

		protected override void OnValidate( Object value )  
		{
			if ( value.GetType() != Type.GetType("System.Int16") )
				throw new ArgumentException( "value must be of type Int16.", "value" );
		}

	}


	public class SamplesCollectionBase  
	{

		public static void Main()  
		{
 
			// Creates and initializes a new CollectionBase.
			Int16Collection myI16 = new Int16Collection();

			// Adds elements to the collection.
			myI16.Add( (Int16) 1 );
			myI16.Add( (Int16) 2 );
			myI16.Add( (Int16) 3 );
			myI16.Add( (Int16) 5 );
			myI16.Add( (Int16) 7 );

			// Displays the contents of the collection using the enumerator.
			Console.WriteLine( "Initial contents of the collection:" );
			PrintIndexAndValues( myI16 );

			// Searches the collection with Contains and IndexOf.
			Console.WriteLine( "Contains 3: {0}", myI16.Contains( 3 ) );
			Console.WriteLine( "2 is at index {0}.", myI16.IndexOf( 2 ) );
			Console.WriteLine();

			// Inserts an element into the collection at index 3.
			myI16.Insert( 3, (Int16) 13 );
			Console.WriteLine( "Contents of the collection after inserting at index 3:" );
			PrintIndexAndValues( myI16 );

			// Gets and sets an element using the index.
			myI16[4] = 123;
			Console.WriteLine( "Contents of the collection after setting the element at index 4 to 123:" );
			PrintIndexAndValues( myI16 );

			// Removes an element from the collection.
			myI16.Remove( (Int16) 2 );

			// Displays the contents of the collection using the index.
			Console.WriteLine( "Contents of the collection after removing the element 2:" );
			for ( int i = 0; i < myI16.Count; i++ )  
			{
				Console.WriteLine( "   [{0}]:   {1}", i, myI16[i] );
			}
			Console.ReadLine();

		}
 
		public static void PrintIndexAndValues( Int16Collection myCol )  
		{
			int i = 0;
			System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
			while ( myEnumerator.MoveNext() )
				Console.WriteLine( "   [{0}]:   {1}", i++, myEnumerator.Current );
			Console.WriteLine();
		}
	}

}
