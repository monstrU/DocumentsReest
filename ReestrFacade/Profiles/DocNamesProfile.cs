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

    public class DocNamesProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DocNamesProfile"; }
        }

        protected override void Configure()
        {
            this.CreateMap<DocName, DocNameModel>();
        }
    }
}
