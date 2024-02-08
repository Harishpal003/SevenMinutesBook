using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int PublisherId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CountryId { get; set; }
        public int ContinetId { get; set; }

        public virtual Continent Continet { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; }
    }
}
