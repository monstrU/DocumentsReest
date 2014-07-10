using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReestrFacade
{
    using DomainModel;

    using ReestrFacade.Converters;

    using ReestrModel;

    public static class DocumentFacade
    {
        public static IList<DocumentModel> LoadDocuments()
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var db = context.Documents;
                var converter = new DocumentConverter();
                return db.Select(converter.Convert).ToList();
            }
            
        }

        public static void SaveDocument(DocumentModel document)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var converter = new DocumentConverter();
                var dbDocument = converter.Convert(document);
                dbDocument.CreatorUserId = new Guid("5D8E89C3-3CE6-44FD-B3E0-D52D5E67E5DD");
                context.Documents.InsertOnSubmit(dbDocument);
                context.SubmitChanges();
            }
        }
    }
}
