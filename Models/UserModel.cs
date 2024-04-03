using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropTrac_backend.Models
{
    public class UserModel
    {
        public int ID { get; set; } // Primary Key
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public string? Email { get; set; }
        public bool IsManager { get; set; }

        // Navigation properties for one-to-one relationship with TenantModel and ManagerModel
        public TenantModel Tenant { get; set; }
        public ManagerModel Manager { get; set; }

        public UserModel()
        {

        }
    }
}