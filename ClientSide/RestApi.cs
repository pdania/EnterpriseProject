using System;
using System.Collections.Generic;
using ClientSide.RandomizerService;
using DBModels;

namespace ClientSide
{
    public static class RestApi
    {
        public static void AddUser(User user)
        {
            RandomizerService.RandomizerServiceClient client = new RandomizerServiceClient();
            client.AddUser(user);
            client.Close();
        }

        public static IEnumerable<User> GetAllUsers()
        {
//            RandomizerService.RandomizerServiceClient client = new RandomizerServiceClient();
//            var users = client.GetAllUsers();
//            client.Close();
//            return users;
            var remoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:57196/RandomizerService.svc");

            using (var randomizerService = new RandomizerServiceClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
            {


                //call web service method
                var users = randomizerService.GetAllUsers();
                randomizerService.Close();
                return users;

            }
        }

        public static void AddRequest(Guid userGuid, Request request)
        {
            RandomizerService.RandomizerServiceClient client = new RandomizerServiceClient();
            client.AddRequest(userGuid, request);
            client.Close();
        }
    }
}