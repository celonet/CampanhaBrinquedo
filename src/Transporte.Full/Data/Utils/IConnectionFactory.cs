namespace Transporte.Full
{
    public interface IConnectionFactory<T>
    {
        T GetConnection();
    }
}