using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReestrFacade.Profiles
{
    using AutoMapper;
    using AutoMapper.Mappers;

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

            this.CreateMap<DocName, DocNameModel>();
            this.CreateMap<DocSender, DocSenderModel>();

            this.CreateMap<Document, DocumentModel>()
                .ForMember(d => d.DocSender, mo => mo.MapFrom(d => d.DocSender))
                .ForMember(d => d.DocName, mo => mo.MapFrom(d => d.DocName))
                .ForMember(d => d.ControlTermExecutionModel, mo => mo.MapFrom(d => d.ControlTermExecutionCalculated));

            this.CreateMap<DocumentModel, Document>()
                .ForMember(d => d.DocSenderId, mo => mo.MapFrom(dm => dm.DocSender.DocSenderId))
                .ForMember(d => d.DocSender, mo => mo.Ignore())
                .ForMember(d => d.DocNameId, mo => mo.MapFrom(dm => (dm.DocName != null) ? (Nullable<int>)dm.DocName.DocNameId : null))
                .ForMember(d => d.DocName, mo => mo.Ignore())
                .ForMember(d => d.aspnet_User, mo => mo.Ignore())
                .ForMember(d => d.ControlTermExecutionCalculated, mo => mo.MapFrom(d => d.ControlTermExecutionModel));
        }
    }
}
