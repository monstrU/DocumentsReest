namespace ReestrFacade.Converters
{
    using AutoMapper;
    using AutoMapper.Mappers;

    using DomainModel;

    using ReestrFacade.Interfaces;
    using ReestrFacade.Profiles;

    using ReestrModel;

    public class DocumentConverter : IObjectConverter<Document, DocumentModel>
    {
        private IMappingEngine Engine { get; set; }

        public DocumentConverter()
        {
            ConfigurationStore store = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            store.AddProfile<DocumentProfile>();
            Engine = new MappingEngine(store);
        }

        public Document Convert(DocumentModel obj)
        {
            return Engine.Map<DocumentModel, Document>(obj);
        }

        public DocumentModel Convert(Document obj)
        {
            return Engine.Map<Document, DocumentModel>(obj);

            /*return new DocumentModel()
            {
                DocumentId = obj.DocumentId,
                Name = obj.Name,
                DocNumber = obj.DocNumber,
                DateAdmission = obj.DateAdmission
            };*/
        }
    }
}