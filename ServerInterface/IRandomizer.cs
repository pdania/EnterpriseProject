using System;
using System.Collections.Generic;
using System.ServiceModel;
using DBModels;

namespace ServerInterface
{
    [ServiceContract]
    public interface IRandomizer
    {
        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void AddRequest(Guid guid, Request request);
    }
}