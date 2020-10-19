using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repositories;

namespace Thunder.Application.AppThunder
{
    public class ProductionAppService : IProductionAppService

    {
        private readonly IProductionRepository _productionRepository;
        private readonly ISmartNotification _notification;
        private readonly IUserRepository _userRepository;

        public ProductionAppService(IProductionRepository productionRepository, ISmartNotification Notification, IUserRepository userRepository)
        {
            _productionRepository = productionRepository;
            _notification = Notification;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<Production>> Get()
        {
            return await _productionRepository.Get();
        }

        public async Task<Production> GetById(int id)
        {
            return await _productionRepository.GetByID(id).ConfigureAwait(false);
        }

        public async Task<int> InsertAsync(string Name, int PersonId, DateTime Created, DateTime Updated)
        {
            var person = await _userRepository.GetUserByIdAsync(PersonId);

            if (person != null)
            {
                var Production = new Production(Name, PersonId, Created, Updated);

                if (Production.isValid())
                {
                    var production = await _productionRepository.InsertAsync(Production);

                    if (production > 0)
                    {
                        return production;
                    }

                }

            }
            _notification.NewNotificationBadRequest("Campos Incorretos");
            return default;        
        }


        public async Task<IEnumerable<Production>> SearchProductionDetail(int id, int personid)
        {
            return await _productionRepository.SearchProductionDetail(id, personid);
        }
    }
}


