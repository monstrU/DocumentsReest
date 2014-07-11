using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReestrFacade.Profiles
{
    using AutoMapper;

    using DomainModel;

    using ReestrModel;

    public class DocumentProfile : Profile
    {

        public override string ProfileName
        {
            get { return "DocumentProfile"; }
        }

        protected override void Configure()
        {
            this.CreateMap<Document, DocumentModel>()
                .ForMember(d => d.DocSender, mo => mo.Ignore())
                .ForMember(d => d.DocName, mo => mo.Ignore());

            this.CreateMap<DocumentModel, Document>()
                .ForMember(d => d.DocSenderId, mo => mo.Ignore())
                .ForMember(d => d.DocSender, mo => mo.Ignore())
                .ForMember(d => d.DocNameId, mo => mo.Ignore())
                .ForMember(d => d.DocName, mo => mo.Ignore())
                .ForMember(d => d.CreatorUserId, mo => mo.Ignore())
                .ForMember(d => d.aspnet_User, mo => mo.Ignore());
        }
    }
}
