using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Domain.Entities
{
    public class Genre
    {
        public Genre(int id, string label)
            {
                Label = label;
                Id = id;
            }
            public int Id { get; private set; }
            public string Label { get; private set; }
    }
}

