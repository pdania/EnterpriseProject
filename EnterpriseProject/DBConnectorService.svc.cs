using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DBModels;
using ServerImplementation;

namespace EnterpriseProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DBConnectorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DBConnectorService.svc or DBConnectorService.svc.cs at the Solution Explorer and start debugging.
    public class DBConnectorService : IDBConnectorService
    {
        public string AddUser(User user)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.AddUser(user);
            return "success";
        }

        public IEnumerable<User> GetAllUsers()
        {
            DBConnection dbConnection = new DBConnection();
            return dbConnection.GetAllUsers();
        }
    }
}
