using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Request : IDBModel
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private int _startRange;
        [DataMember]
        private int _endRange;
        [DataMember]
        private int _count;
        [DataMember]
        private DateTime _requestTime;
        [DataMember]
        private Guid _ownerGuid;

        private User _user;

        #endregion

        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }

        public int StartRange
        {
            get { return _startRange; }
            private set => _startRange = value;
        }

        public int EndRange
        {
            get { return _endRange; }
            private set => _endRange = value;
        }

        public int Count
        {
            get { return _count; }
            private set => _count = value;
        }

        public DateTime RequestTime
        {
            get { return _requestTime; }
            private set => _requestTime = value;
        }

        public virtual User User
        {
            get => _user;
            set => _user = value;
        }

        public Guid OwnerGuid
        {
            get { return _ownerGuid; }
            private set => _ownerGuid = value;
        }
        #endregion

        #region Constructors
        public Request(int startRange, int endRange) : this()
        {
            StartRange = startRange;
            EndRange = endRange;
            Count = EndRange - StartRange;
        }

        public Request()
        {
            Guid = Guid.NewGuid();
            RequestTime = DateTime.Now;
        }
        #endregion

    }
}