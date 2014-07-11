using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReestrFacade.Converters
{
    using AutoMapper;
    using AutoMapper.Mappers;

    using ReestrFacade.Interfaces;
    using ReestrFacade.Profiles;

    using ReestrModel;

    public class UpdateDocumentConverter : IObjectConverter<Document, Document>
    {
        private IMappingEngine Engine { get; set; }

        public UpdateDocumentConverter()
        {
            ConfigurationStore store = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);

            store.AddProfile<UpdateDocumentProfile>();
            Engine = new MappingEngine(store);   
        }

        public Document Convert(Document obj)
        {
            return Engine.Map<Document, Document>(obj);
        }

       
    }
}
