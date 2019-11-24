using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public void AddRequest(Guid userGuid, Request request)
        {
            using (var context = new RandomizerDBContext())
            {
               context.Users.FirstOrDefault(user1 => user1.Guid == userGuid)?.Requests.Add(request);
               context.SaveChanges();
            }
        }

        public List<Request> GetAllRequests(Guid userGuid)
        {
            using (var context = new RandomizerDBContext())
            {
                var requests = context.Requests.Where(rec => rec.OwnerGuid == userGuid).ToList();
                return requests;
            }
        }

        public void ChangeUserDate(Guid userGuid)
        {
            using (var context = new RandomizerDBContext())
            {
                // ReSharper disable once PossibleNullReferenceException
                context.Users.FirstOrDefault(user => user.Guid == userGuid).Time = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}