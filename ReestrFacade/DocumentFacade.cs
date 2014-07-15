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
                var db = context.Documents.OrderByDescending(d=>d.DateAdmission);
                var converter = new DocumentConverter();
                return db.Select(converter.Convert).ToList();
            }
            
        }

        public static void SaveDocument(DocumentModel document)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                string userId = "5D8E89C3-3CE6-44FD-B3E0-D52D5E67E5DD";
                document.CreatorUserId = new Guid(userId); 
                var converter = new DocumentConverter();
                var dbDocument = converter.Convert(document);
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

                dbDoc.DocSender.DocSenderId = updateDoc.DocSenderId;
                dbDoc.Comments = updateDoc.Comments;
                if (updateDoc.DocSender != null)
                {
                    dbDoc.DocSender.DocSenderId = updateDoc.DocSender.DocSenderId;
                }
                else
                {
                    dbDoc.Name = updateDoc.Name;
                }

                dbDoc.DateAdmission = updateDoc.DateAdmission;
                

                if (!document.IsCreatedFromDictionary)
                {
                    dbDoc.TermExecution = updateDoc.TermExecution;
                }

                context.SubmitChanges();

            }
        }
    }
}
