namespace ReestrFacade.Converters
{
    using ReestrFacade.Interfaces;

    using ReestrModel;

    public class DocumentConverter : IObjectConverter<Document, DocumentModel>
    {
        public Document Convert(DocumentModel obj)
        {
            throw new System.NotImplementedException();
        }

        public DocumentModel Convert(Document obj)
        {

            return new DocumentModel()
            {
                DocumentId = obj.DocumentId,
                Name = obj.Name
            };
        }
    }
}