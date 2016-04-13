using System;
using System.Collections.Generic;

namespace Carriers.Model
{
    public class Carrier
    {
        public Carrier()
        {
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
