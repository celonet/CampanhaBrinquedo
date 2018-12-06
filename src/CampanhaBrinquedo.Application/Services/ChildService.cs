using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBrinquedo.Domain.Services;

namespace CampanhaBrinquedo.Application.Services
{
    public class ChildService : IChildServiceApp
    {
        private readonly ICampaignServiceApp _serviceApp;
        private readonly IChildRepository _repository;

        public ChildService(ICampaignServiceApp serviceApp, IChildRepository repository)
        {
            _serviceApp = serviceApp;
            _repository = repository;
        }

        public async Task Associate(Guid childId, Guid associateChildId)
        {
            var child = await _repository.FindById(childId);
            var associateChild = await _repository.FindById(associateChildId);
            
            if(child != null && associateChild != null)
            {
                var mergedChild = child.Merge(associateChild);
                await _repository.UpdateAsync(mergedChild);
                await _repository.DeleteAsync(associateChild.Id);
            }
        }

        public async Task Create(Child child) => await _repository.CreateAsync(child);

        public async Task Delete(Guid id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<Child>> Get()
        {
            var currentCampaign = await _serviceApp.GetCurrent();
            return await _repository.GetCriancasPorCampanha(currentCampaign.Year);
        }

        public async Task<IEnumerable<Child>> GetAll() => await _repository.List();

        public async Task<Child> GetById(Guid id) => await _repository.FindById(id);

        public async Task Update(Child child) => await _repository.UpdateAsync(child);
    }
}