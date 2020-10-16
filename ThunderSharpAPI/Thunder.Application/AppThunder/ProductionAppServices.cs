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
    public class ProductionAppServices : IProductionAppServices
    {
        private readonly IProductionRepository _productionRepository;

        public ProductionAppServices(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public IEnumerable<Production> Get()
        {
            return _productionRepository.Get();
        }

        public async Task<Production> GetByID(int id)
        {
            return await _productionRepository.GetByID(id).ConfigureAwait(false);
        }

        public async Task<Production> Insert(ProductionInput input)
        {
            var production = new Production(input.Name, input.CPF, input.Created, input.Updated);

            //validações

            var id = _productionRepository.Insert(production);
            var productionNew = await GetByID(id);

            return productionNew;
        }

    }
    
}


