using System;
using System.Collections.Generic;
using System.ServiceModel;
using ClientSide.RandomizerService;
using DBModels;

namespace ClientSide
{
    public static class RestApi
    {
        private static readonly EndpointAddress RemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:57196/RandomizerService.svc");
        public static void AddUser(User user)
        {
            using (var randomizerService = new RandomizerServiceClient(new System.ServiceModel.BasicHttpBinding(), RemoteAddress))
            {
                randomizerService.AddUser(user);
                randomizerService.Close();

            }
        }

        public static IEnumerable<User> GetAllUsers()
        {
            using (var randomizerService = new RandomizerServiceClient(new System.ServiceModel.BasicHttpBinding(), RemoteAddress))
            {


                //call web service method
                var users = randomizerService.GetAllUsers();
                randomizerService.Close();
                return users;

            }
        }

        public static void AddRequest(Guid userGuid, Request request)
        {
            using (var randomizerService =
                new RandomizerServiceClient(new System.ServiceModel.BasicHttpBinding(), RemoteAddress))
            {
                randomizerService.AddRequest(userGuid, request);
                randomizerService.Close();
            }
        }
    }
}