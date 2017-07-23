namespace Data.Users
{
    public interface IAltFactory<T> : IFactory 
        where T: IFactory
    {
        
    }
}