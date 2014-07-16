using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReestrModel.Extentions
{
    using DomainModel;

    public static class DocumnetModelExtentions
    {
        public static bool IsExpired (this DocumentModel doc)
        {
            return doc.ControlTermExecutionModel < DateTime.Now.Date;
        }

        public static bool IsExecutionToday(this DocumentModel doc)
        {
            return doc.ControlTermExecutionModel.Date == DateTime.Now.Date;
        }
    }
}
