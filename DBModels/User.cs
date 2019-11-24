using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class User: IDBModel
    {
        #region Fields
        [DataMember]
        private string _name;
        [DataMember]
        private string _surname;
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _email;
        [DataMember]
        private string _password;
        [DataMember]
        private List<Request> _requests;
        [DataMember]
        private DateTime _time;

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

        public DateTime Time
        {
            get => _time;
            set => _time = value;
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
            Time = DateTime.Now;
        }
        public User()
        {
            Guid = Guid.NewGuid();
            Requests = new List<Request>();
        }
        #endregion
    }
}