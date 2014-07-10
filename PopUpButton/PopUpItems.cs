using System;
using System.Collections;

namespace RCO.PopUpButtons
{	/// <summary>
	/// Summary description for PupUpItems.
	/// </summary>
	public class PopUpItems:EventArgs
	{
		private Hashtable _Items;

		public Hashtable Items
		{
			get {return _Items; }
		}
		
		public PopUpItems():base()
		{
			//
			// TODO: Add constructor logic here
			//
			_Items=new Hashtable();
		}
	}
}
