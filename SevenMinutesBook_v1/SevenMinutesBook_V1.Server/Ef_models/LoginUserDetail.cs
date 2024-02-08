using System;
using System.Collections.Generic;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class LoginUserDetail
    {
        public decimal UserId { get; set; }
        public string? Firstname { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public string? Mobile { get; set; }
        public string? Token { get; set; }
        public string? IsAdmin { get; set; }
        public DateTime? EntryOn { get; set; }
        public string? IsDeactivate { get; set; }
        public DateTime? DeactivatedOn { get; set; }
    }
}
