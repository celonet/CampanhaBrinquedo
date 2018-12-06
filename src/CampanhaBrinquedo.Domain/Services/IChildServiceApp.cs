using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities.Child;

namespace CampanhaBrinquedo.Domain.Services
{
    public interface IChildServiceApp
    {
        Task<IEnumerable<Child>> Get();
        Task<IEnumerable<Child>> GetAll();
        Task<Child> GetById(Guid id);
        Task Create(Child child);
        Task Update(Child child);
        Task Delete(Guid id);
        Task Associate(Guid childId, Guid associateChild);
    }
}