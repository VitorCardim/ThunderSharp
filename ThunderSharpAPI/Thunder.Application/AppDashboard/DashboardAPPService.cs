using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;
using Thunder.Application.AppDashboard.Interfaces;
using Thunder.Domain.Interfaces.Repository;

namespace Thunder.Application.AppDashboard

{
    public class DashboardAPPService : IDashboardAppService
    {
        private readonly IDashboardRepository _DashboardRepository;
        
        public IEnumerable<Dashboard> Get()
        {
            return _heroRepository.Get();
        }

        public async Task<Hero> GetByIdAsync(int id)
        {
            return await _heroRepository
                            .GetByIdAsync(id)
                            .ConfigureAwait(false);
        }

        public async Task<Hero> Insert(HeroInput input)
        {
            //TODO: Criar metodo de obter o editor pelo Id
            var hero = new Hero(input.Name, new Editor(input.IdEditor), input.Age);

            if (!hero.IsValid())
            {
                _notification.NewNotificationBadRequest("Os dados não foram preenchidos corretamente!");
                return default;
            }

            if (!hero.IsMaiority())
            {
                _notification.NewNotificationConflict("O heroi não é maior de idade");
                return default;
            }

            var id = _heroRepository.Insert(hero);
            var heroNew = await GetByIdAsync(id);

            return heroNew;
        }
    }
}
