using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class SubGenre
    {
        public SubGenre()
        {
            Books = new HashSet<Book>();
        }

        public int SubGenreId { get; set; }
        public string Name { get; set; } = null!;
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; }
    }
}
