﻿using System;
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

        public ProductionAppService(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public IEnumerable<Production> Get()
        {
            return _productionRepository.Get();
        }

        public async Task<Production> GetById(int id)
        {
            return await _productionRepository.GetByID(id).ConfigureAwait(false);
        }

        public async Task<int> InsertAsync(string Name, int PersonId, DateTime Created, DateTime Updated)
        {
            var person = await _productionRepository.GetByID(PersonId);

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
            return 0;
        }
    }
}


