using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
