using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReestrFacade.Converters
{
    using AutoMapper;
    using AutoMapper.Mappers;

    using DomainModel;

    using ReestrFacade.Interfaces;
    using ReestrFacade.Profiles;

    using ReestrModel;

    public class DocSendersConverter : IObjectConverter<DocSender, DocSenderModel>
    {
        private IMappingEngine Engine { get; set; }

        public DocSendersConverter()
        {
            ConfigurationStore store = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            store.AddProfile<DocSenderProfile>();
            Engine = new MappingEngine(store);
        }

        public DocSender Convert(DocSenderModel obj)
        {
            throw new NotImplementedException();
        }

        public DocSenderModel Convert(DocSender obj)
        {
            return Engine.Map<DocSender, DocSenderModel>(obj);
        }
    }
}
