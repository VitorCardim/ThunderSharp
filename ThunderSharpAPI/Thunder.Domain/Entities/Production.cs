using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Interfaces.Repositories;

namespace Thunder.Domain.Entities
{
    public class Production 

    {
        public int Id { get; set; }
        public string Name { get; set; }
        //AJUSTAR - para o tipo correto do CPF
        public int PersonId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Production(int id, string name, int personId, DateTime created, DateTime updated)
        {
            this.Id = id;
            this.Name = name;
            this.PersonId = personId;
            this.Created = DateTime.Now;
            this.Updated = DateTime.Now;

        }

        public Production(string name, int personId, DateTime created, DateTime updated)
        {
            Name = name;
            PersonId = PersonId;
            Created = created;
        }
    }
}
