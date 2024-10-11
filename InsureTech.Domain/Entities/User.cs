using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureTech.Domain.Entities
{
    namespace InsureTech.Domain.Entities
    {
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string PasswordHash { get; set; } = string.Empty;
        }
    }

}
