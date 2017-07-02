using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Shared.DTO
{
    [AuditEntity]
    public class UserTO: MainViewModel
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        string _urlProfile;
        public string UrlProfile
        {
            get
            { return _urlProfile; }
            set
            {
                _urlProfile = value;
              
            }
        }

        public string FullName { get
            { return FirstName + " " + Surname; } }
    }
}
