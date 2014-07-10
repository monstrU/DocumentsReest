using System;
using System.Collections;
using System.ComponentModel;

namespace RCO.PopUpButtons
{
    using RCO.PopUpButton;

    [Serializable]
	public class paramsCollection : CollectionBase
	{
		#region paramsCollection body

		public override string  ToString()
		{
			return this.Count+" elements";
		}
		public virtual   int Add(paramItem value)
		{
			if (value.Equals(null))
				throw new ArgumentException("item");
			else
				return base.List.Add(value);
		}

		public void insert(int index, paramItem param)
		{
			this.List.Insert(index, param);
		}

		public int indexOf(paramItem param)
		{
		  IEnumerator en = this.List.GetEnumerator();
		  int i = -1, index = 0;
		  
		  while(en.MoveNext())
		  {
        if (((paramItem)en.Current).Key == param.Key && ((paramItem)en.Current).KeyValue == param.KeyValue)
		    {
		      i = index;break;
		    }
		    index++;
		  }
		  
			return i;
		}

		public bool Contains(paramItem param)
		{
			return this.List.Contains(param);
		}

		public void Remove(paramItem param)
		{
			this.List.Remove(param);
		}

		public void CopyTo(paramItem[] items, int index)
		{
			this.List.CopyTo(items, index);
		}

		public paramItem this[int index]
		{
			get { return (paramItem) base.List[index]; }
			set { base.List[index] = value; }
		}


		protected override void OnInsert(int index, object value)
		{
			if (!(value is paramItem))
				throw new ArgumentException("Invalid type");
			else
				base.OnInsert(index, value);
		}

		protected override void OnSet(int index, object oldValue, object newValue)
		{
			if (!(newValue is paramItem))
				throw new ArgumentException("Invalid type");
			else
				base.OnSet(index, oldValue, newValue);
		}

		protected override void OnValidate(object value)
		{
			if (!(value is paramItem))
				throw new ArgumentException("Invalid type");
			else
				base.OnValidate(value);
		}

		public void AddRange(paramItem[] ci)
		{
			this.InnerList.AddRange(ci);
		}

		public paramItem[] GetValues()
		{
			//It is used by the ComplexItemConverter
			paramItem[] ci= new paramItem[this.InnerList.Count];
			this.InnerList.CopyTo(0,ci,0,this.InnerList.Count);
			return ci;
		}
		#endregion
	}


	[Serializable]
	[TypeConverter(typeof (ParamItemConverter))]
	public class paramItem
	{
		#region paramItem body

		
		private  string _key;
		private  string _keyValue;

		

		public paramItem()
		{
		}
		public paramItem(string pKey,string pValue)
		{
			_key=pKey;
			_keyValue=pValue;
		}

		public  override string ToString()
		{
			return (Key!=null)? Key+"="+KeyValue:"parameter";
		}

		/// <summary>
		/// Ключ параметра
		/// </summary>
		[Description("Ключ параметра"),
		RefreshProperties(RefreshProperties.All),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
		]
		public string Key
		{
			get
			{
				return _key;
			}
			set
			{
				_key=value;
			}
		}

		/// <summary>
		/// Значение параметра
		/// </summary>
		[Description("Значение параметра"),
		RefreshProperties(RefreshProperties.All),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
		]
		public string KeyValue
		{
			get
			{
				return _keyValue;
			}
			set
			{
				_keyValue=value;
			}
		}
		#endregion
	}



}
