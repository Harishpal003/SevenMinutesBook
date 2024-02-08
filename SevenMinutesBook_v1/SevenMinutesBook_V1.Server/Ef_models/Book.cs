using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public int BookTitle { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Edition { get; set; }
        public string Language { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int GenreId { get; set; }
        public int SubGenreId { get; set; }
        public int TotalPages { get; set; }
        public string About { get; set; } = null!;
        public int PublisherId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
        public virtual Publisher Publisher { get; set; } = null!;
        public virtual SubGenre SubGenre { get; set; } = null!;
    }
}
