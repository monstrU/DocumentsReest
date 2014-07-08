using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReestrFacade
{
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
    }
}
