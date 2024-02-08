using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
            SubGenres = new HashSet<SubGenre>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<SubGenre> SubGenres { get; set; }
    }
}
