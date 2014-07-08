namespace ReestrFacade.Interfaces
{
    public interface IObjectConverter<TSource, TDest>
        where TSource : class where TDest : class
    {
        TSource Convert(TDest obj);

        TDest Convert(TSource obj);

        
    }
}