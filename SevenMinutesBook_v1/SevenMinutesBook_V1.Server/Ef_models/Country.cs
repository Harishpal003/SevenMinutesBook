using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class Country
    {
        public Country()
        {
            Authors = new HashSet<Author>();
            Publishers = new HashSet<Publisher>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; } = null!;
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
