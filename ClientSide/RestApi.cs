using System;
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
            RandomizerServer.RandomizerServiceClient client = new RandomizerServiceClient();
            client.AddUser(user);
            client.Close();
        }

        public static IEnumerable<User> GetAllUsers()
        {
            RandomizerServer.RandomizerServiceClient client = new RandomizerServiceClient();
            var users = client.GetAllUsers();
            client.Close();
            return users;
        }

        public static void AddRequest(Guid userGuid, Request request)
        {
            RandomizerServer.RandomizerServiceClient client = new RandomizerServiceClient();
            client.AddRequest(userGuid, request);
            client.Close();
        }
    }
}