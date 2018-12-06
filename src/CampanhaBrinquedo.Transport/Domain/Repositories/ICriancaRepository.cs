using CampanhaBrinquedo.Transport.Model;
using System.Collections.Generic;

namespace CampanhaBrinquedo.Transport
{
    public interface ICriancaRepository
    {
        IEnumerable<Crianca> GetCriancas(int year);
    }
}