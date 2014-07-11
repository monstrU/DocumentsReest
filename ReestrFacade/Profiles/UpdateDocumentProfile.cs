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

    public class UpdateDocumentProfile : Profile
    {
          public override string ProfileName
        {
            get { return "UpdateDocumentProfile"; }
        }

        protected override void Configure()
        {
            
            this.CreateMap<Document, Document>()
                .ForMember(d => d.DocumentId, opt => opt.Ignore());

        }
    }
}
