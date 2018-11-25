namespace CampanhaBrinquedo.Transport.Utils
{
    public interface IConnectionFactory<T>
    {
        T GetConnection();
    }
}