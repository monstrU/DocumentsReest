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

    public class DocNamesConverter : IObjectConverter<DocName,  DocNameModel>
    {
        private IMappingEngine Engine { get; set; }

        public DocNamesConverter()
        {
            ConfigurationStore store = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            store.AddProfile<DocNamesProfile>();
            Engine = new MappingEngine(store);
        }

        public DocName Convert(DocNameModel obj)
        {
            throw new NotImplementedException();
        }

        public DocNameModel Convert(DocName obj)
        {
            return Engine.Map<DocName, DocNameModel>(obj);
        }
    }
}
