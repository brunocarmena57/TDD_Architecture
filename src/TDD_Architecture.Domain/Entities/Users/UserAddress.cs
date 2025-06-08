using TDD_Architecture.Domain.Entities.Base;

namespace TDD_Architecture.Domain.Entities.Users
{
    public class UserAddress : EntityBase
    {
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string? Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public int UserId { get; set; }
        public virtual ICollection<User> User { get; set; }

        public UserAddress()
        {
            User = new HashSet<User>();
        }
    }
}
