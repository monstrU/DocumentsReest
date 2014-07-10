namespace RCO.PopUpButtons
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Reflection;
    using System.Windows.Forms;

    
    internal class ParamItemConverter : ExpandableObjectConverter
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
				MessageBox.Show("Не могу преобразовать к типу paramItem 2");
				

			return base.CanConvertFrom(context, sourceType);
				
		}
		public override Object ConvertFrom(ITypeDescriptorContext context,
			System.Globalization.CultureInfo culture,
			Object value)
		{
				
			if (value.GetType()== typeof(string))
			{
				string r;
				r=Convert.ToString(value);
				if (r.IndexOf('=')==-1)
					throw new Exception("Не могу преобразовать к виду ключ=значение");

				string[] keys=(Convert.ToString(value).Split('='));
				paramItem pr=new paramItem(keys[0],keys[1]);
				return pr;

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
					
				ConstructorInfo ci = typeof(paramItem).GetConstructor(
					new Type[] {
								   typeof(string),
								   typeof(string)}
					);
				paramItem pi=(paramItem)value;

				return new InstanceDescriptor(ci,new object[]{
																 pi.Key,
																 pi.KeyValue});
			}
				
			return base.ConvertTo(context,culture, value,destinationType);
		}

				

	}
}
