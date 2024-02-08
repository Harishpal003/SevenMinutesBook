using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class Description
    {
        public decimal Id { get; set; }
        public decimal AuthorId { get; set; }
        public decimal? BookId { get; set; }
        public string? About { get; set; }
        public DateTimeOffset? ModificationDt { get; set; }
        public string? IsDeactivated { get; set; }
    }
}
