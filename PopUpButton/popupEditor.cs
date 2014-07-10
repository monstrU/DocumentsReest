using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Windows.Forms;

namespace RCO.PopUpButtons.Desing
{
	internal class IDSConverter : TypeConverter 
	{
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		//ITypeDescriptorContext _context, CultureInfo _culture, object _value, Type _type
		public override bool CanConvertTo(ITypeDescriptorContext context,
			Type destinationType)
		{
			//Debug.WriteLine(destinationType.GetType().ToString());
			//InstanceDescriptor
				
			if (destinationType==typeof(InstanceDescriptor))
				return true;
			return base.CanConvertTo(context, destinationType);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
				
			
			if (sourceType==typeof(string))
				return true;
			else
				MessageBox.Show("Не могу преобразовать к типу ID");
				

			return base.CanConvertFrom(context, sourceType);
				
		}
		public override Object ConvertFrom(ITypeDescriptorContext context,
			System.Globalization.CultureInfo culture,
			Object value)
		{
				
			
			if (value.GetType()== typeof(TypeConverter ))
			{
				string r;
				r=Convert.ToString(value);
				
//				if (r.IndexOf('=')==-1)
//					throw new Exception("Не могу преобразовать к виду ключ=значение");
//
//				string[] keys=(Convert.ToString(value).Split('='));
//				paramItem pr=new paramItem(keys[0],keys[1]);
				return r;

			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context,
			System.Globalization.CultureInfo culture,
			Object value,
			Type destinationType)
		{

			if (destinationType==typeof(InstanceDescriptor))
			{
					
				ConstructorInfo ci = typeof(string).GetConstructor(
					new Type[] {
								   typeof(ID)}
					);
//				paramItem pi=(paramItem)value;
//
//				return new InstanceDescriptor(ci,new object[]{
//																 pi.Key,
//																 pi.KeyValue});
				ID id=new ID();
				id.Text=Convert.ToString(value);
				return id;

			}
				
			
			return base.ConvertTo(context,culture, value,destinationType);
		}

				

	}

	internal class IDSCollectionEditor : CollectionEditor
	{
		private Type[] types;
		private CollectionForm collectionForm;

		public IDSCollectionEditor(Type pType):base(pType)
		{
			this.types=new Type[] { typeof(string) };
		}
			
		protected override Type[] CreateNewItemTypes()
		{
			return this.types;
		}

		protected override CollectionForm CreateCollectionForm()
		{
			this.collectionForm = base.CreateCollectionForm();
            
			return this.collectionForm;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if (this.collectionForm != null && this.collectionForm.Visible)
			{
				IDSCollectionEditor editor = new IDSCollectionEditor(this.CollectionType);
            
				return editor.EditValue(context, provider, value);
			}
			else
			{
				return base.EditValue(context, provider, value);
			}
		}
	}	
	
}
