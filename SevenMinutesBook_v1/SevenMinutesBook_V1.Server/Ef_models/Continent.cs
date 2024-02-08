using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class Continent
    {
        public Continent()
        {
            Authors = new HashSet<Author>();
            Countries = new HashSet<Country>();
            Publishers = new HashSet<Publisher>();
        }

        public int ContientId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
