using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReestrFacade.Profiles
{
    using AutoMapper;

    using DomainModel;

    using ReestrModel;

    public class DocSenderProfile: Profile
    {
        public override string ProfileName
        {
            get { return "DocSenderProfile"; }
        }

        protected override void Configure()
        {
            this.CreateMap<DocSender, DocSenderModel>();
        }
    }
}
