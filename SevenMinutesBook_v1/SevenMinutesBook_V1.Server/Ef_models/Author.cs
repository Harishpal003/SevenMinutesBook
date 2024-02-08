using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public string AuthorDescription { get; set; } = null!;
        public DateTimeOffset? DateOfBirth { get; set; }
        public int BirthCountry { get; set; }
        public int ContinentId { get; set; }

        public virtual Country BirthCountryNavigation { get; set; } = null!;
        public virtual Continent Continent { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; }
    }
}
