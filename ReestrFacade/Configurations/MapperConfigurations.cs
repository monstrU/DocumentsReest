namespace ReestrFacade.Configurations
{
    using AutoMapper;

    using ReestrFacade.Profiles;

    public class MapperConfigurations
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DocNamesProfile>();
                x.AddProfile<DocumentProfile>();
                x.AddProfile<DocSenderProfile>();
                x.AddProfile<UpdateDocumentProfile>();
                
            });
            Mapper.AssertConfigurationIsValid();
        }

    }
}
