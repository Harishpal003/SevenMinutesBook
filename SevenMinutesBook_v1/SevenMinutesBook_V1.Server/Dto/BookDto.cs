namespace SevenMinutesBook_V1.Server.Dto
{
    public class BookDto
    {

        public int BookId { get; set; }
        public string? BookTitle { get; set; }
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



    }
}
