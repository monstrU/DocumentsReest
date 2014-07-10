namespace RCO.PopUpButtons.Design
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;

    internal class ParamsCollectionEditor : CollectionEditor
    {
        private Type[] types;
        private CollectionForm collectionForm;

        public ParamsCollectionEditor(Type pType):base(pType)
        {
            this.types=new Type[] { typeof(paramItem) };
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
                ParamsCollectionEditor editor = new ParamsCollectionEditor(this.CollectionType);
            
                return editor.EditValue(context, provider, value);
            }
            else
            {
                return base.EditValue(context, provider, value);
            }
        }
    }
}