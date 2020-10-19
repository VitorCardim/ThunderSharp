using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Domain.Entities
{
    public class Profile
    {
        public Profile(int id, string label)
        {
            Label = label;
            Id = id;
        }
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
