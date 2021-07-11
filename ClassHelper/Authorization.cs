using Accounting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.ClassHelper
{
    class Authorization
    {
        private static User currentUser;

        public static void setUser(User user)
        {
            currentUser = user;
        }

        public static string getUsername()
        {
            return currentUser?.Login ?? "User";
        }
           
    }
}
