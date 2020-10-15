using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Interfaces.Repository;

namespace Thunder.Domain.Entities
{
    public class Production 

    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //AJUSTAR - para o tipo correto do CPF
        public string CPF { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }

        //AJUSTAR - para o tipo correto do CPF
        public Production(Guid id, string name, string cpf, DateTime created)
        {
            this.Id = id;
            this.Name = name;
            this.CPF = cpf;
            this.Created = DateTime.Now;

        }


    }
}
