using System;
using System.Collections.Generic;

namespace DBModels
{
    public class User: IDBModel
    {
        #region Fields
        private string _name;
        private string _surname;
        private Guid _guid;
        private string _email;
        private string _password;
        private List<Request> _requests;
        #endregion

        #region Properties
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            private set => _surname = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        public string Password
        {
            get => _password;
            private set => _password = value;
        }

        public List<Request> Requests
        {
            get => _requests;
            private set => _requests = value;
        }
        #endregion

        #region Constructors

        public User(string name, string surname, string email, string password):this()
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
        public User()
        {
            Guid = Guid.NewGuid();
            Requests = new List<Request>();
        }
        #endregion
    }
}