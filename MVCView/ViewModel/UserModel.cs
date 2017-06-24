using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCView.ViewModel
{
    public class UserModel
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public int RoleID { get; set; }

        public string RoleName { get; set; }
    }
}
