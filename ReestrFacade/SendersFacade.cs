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

    public class SendersFacade
    {
        public static IList<DocSenderModel> LoadSenders()
        {
            using (var context = new ReestrContextDataContext(ModelUtils.ConnectionString))
            {
                var dbList = context.DocSenders;
                var converter = new DocSendersConverter();
                return dbList.Select(p => converter.Convert(p)).ToList();
            }

        }
    }
}
