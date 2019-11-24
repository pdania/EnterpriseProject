using System;
using System.Collections.Generic;
using System.ServiceModel;
using DBModels;

namespace EnterpriseProject
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IRandomizerService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IRandomizerService
    {
        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        void AddRequest(Guid userGuid, Request request);

        [OperationContract]
        List<Request> GetAllRequests(Guid userGuid);

        [OperationContract]
        void ChangeUserDate(Guid userGuid);
    }
}
