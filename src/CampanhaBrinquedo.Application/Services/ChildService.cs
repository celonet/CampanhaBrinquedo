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

        public async Task<IEnumerable<Child>> Get()
        {
            var currentCampaign = await _serviceApp.GetCurrent();

            return await _repository.List(_ => _.Campaigns.Contains(currentCampaign));
        }
    }
}