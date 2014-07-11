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

        public static DocumentModel LoadDocument(int documentId)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                
               var dbDoc= context.Documents.SingleOrDefault(d => d.DocumentId == documentId);
               var converter = new DocumentConverter();
                return converter.Convert(dbDoc);
            }
        }

        public static void UpdateDocument(DocumentModel document)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {

                var dbDoc = context.Documents.SingleOrDefault(d => d.DocumentId == document.DocumentId);
                var converter = new DocumentConverter();
                var updateDoc = converter.Convert(document);

                dbDoc.Name = updateDoc.Name;
                dbDoc.Comments = updateDoc.Comments;
                dbDoc.SenderName = updateDoc.SenderName;
                dbDoc.DateAdmission = updateDoc.DateAdmission;
                dbDoc.TermExecution = updateDoc.TermExecution;
                //dbDoc.ControlTermExecution = updateDoc.ControlTermExecution;
                
                context.SubmitChanges();

            }
        }
    }
}
