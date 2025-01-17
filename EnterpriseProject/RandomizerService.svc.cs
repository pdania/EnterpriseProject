﻿using System;
using System.Collections.Generic;
using DBModels;
using ServerImplementation;

namespace EnterpriseProject
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "RandomizerService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы RandomizerService.svc или RandomizerService.svc.cs в обозревателе решений и начните отладку.
    public class RandomizerService : IRandomizerService
    {
        public void AddUser(User user)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.AddUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            DBConnection dbConnection = new DBConnection();
            return dbConnection.GetAllUsers();
        }

        public void AddRequest(Guid userGuid, Request request)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.AddRequest(userGuid, request);
        }

        public List<Request> GetAllRequests(Guid userGuid)
        {
            DBConnection dbConnection = new DBConnection();
            return dbConnection.GetAllRequests(userGuid);
        }

        public void ChangeUserDate(Guid userGuid)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.ChangeUserDate(userGuid);
        }
    }
}
