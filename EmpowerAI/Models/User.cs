using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmpowerAI.Models
{
    public interface IUser
    {
         int Id { get;  }
         int CompanyId { get;  }
         string FirstName { get;  }
         string LastName { get;  }
         string Email { get;  }
         int AccessFailedCount { get;  }
         DateTime? LockoutEndDate { get;  }
         bool LockoutEnabled { get;  }
         string PasswordHash { get;  }
         string SecurityStamp { get;  }
         string PhoneNumber { get;  }
    }
    public partial class User : IUser
    {
        
        public User()
        {
            Submission = new HashSet<Submission>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public int AccessFailedCount { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public bool LockoutEnabled { get; set; }
        
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public CompanyInfo Company { get; set; }
        public ICollection<Submission> Submission { get; set; }
    }
}
