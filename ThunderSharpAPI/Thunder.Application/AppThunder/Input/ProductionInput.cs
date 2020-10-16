using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Application.AppThunder.Input
{
    public class ProductionInput
    {
        public string Name { get; set; }
        //AJUSTAR - para o tipo correto do CPF
        public int PersonId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
