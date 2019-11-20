using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security;
using DBModels;
using EntityFrameworkWrapper;
using ServerInterface;

namespace ServerImplementation
{
    public class DBConnection:IRandomizer
    {
        public IEnumerable<User> GetAllUsers()
        {
            using (var context = new RandomizerDBContext())
            {
                return context.Users.Include(u => u.Requests).ToList();
            }
        }

        public void AddUser(User user)
        {
            using (var context = new RandomizerDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}