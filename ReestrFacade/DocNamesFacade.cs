using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal;

namespace ReestrFacade
{
    using DomainModel;

    using ReestrFacade.Converters;

    using ReestrModel;

    public class DocNamesFacade
    {
        public static IList<DocNameModel> LoadDocNames()
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var dbNames = context.DocNames.OrderBy(d => d.Name);
                var converter = new DocNamesConverter();
                return dbNames.Select(d => converter.Convert(d)).ToList();
            }
        }

        public static void AddDocNames(DocNameModel docName)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var converter = new DocNamesConverter();
                var db = converter.Convert(docName);
                
                context.DocNames.InsertOnSubmit(db);
                context.SubmitChanges();
            }
        }

        public static void UpdateDocName(DocNameModel docName)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var db = context.DocNames.First(d => d.DocNameId == docName.DocNameId);
                db.Name = docName.Name;
                db.TermExecutionDays = docName.TermExecutionDays;
                context.SubmitChanges();
            }
        }

        public static void DeleteDocName(DocNameModel docName)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var db = context.DocNames.First(d => d.DocNameId == docName.DocNameId);
                context.DocNames.DeleteOnSubmit(db);
                context.SubmitChanges();
            }

        }

        public static DocNameModel GetDocName(int docNameId)
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var db = context.DocNames.First(d => d.DocNameId == docNameId);
                var converter = new DocNamesConverter();

                return converter.Convert(db);
            }
        }
    }
}
