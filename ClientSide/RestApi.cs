using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using ClientSide.RandomizerServer;
using DBModels;

namespace ClientSide
{
    public static class RestApi
    {
        public static void AddUser(User user)
        {
            RandomizerServer.DBConnectorServiceClient client = new DBConnectorServiceClient();
            client.AddUser(user);
        }

        public static IEnumerable<User> GetAllUsers()
        {
            RandomizerServer.DBConnectorServiceClient client = new DBConnectorServiceClient();
            return client.GetAllUsers();
        }
    }
}