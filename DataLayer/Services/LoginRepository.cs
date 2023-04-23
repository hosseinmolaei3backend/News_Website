using DataLayer.Context;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class LoginRepository : ILoginRepository
    {
         MyNewsContext db;
        public LoginRepository(MyNewsContext context)
        {
            this.db = context;
        }
        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogins.Any(u => u.Username == username && u.Password == password);
        }
    }
}
