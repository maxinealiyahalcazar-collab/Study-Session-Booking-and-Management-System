using System;
using System.Collections.Generic;
using System.Text;

namespace Study_Session
{
    public class Session
    {
        private int sessionId;
        private int? creatorStudentId;
        private int? creatorTutorId;
        private int requiredTutors;
        private string subject  = "";
        private string topic = "";
        private DateTime dateTime;
        private int slots;
        private string location = "";
        private string sessionStatus = "";

        public int SessionId
        {
            get { return sessionId; }
        }

        public int? CreatorStudentId
        {
            get { return creatorStudentId; }
        }

        public int? CreatorTutorId
        {
            get { return creatorTutorId; }
        }

        public int RequiredTutors
        {
            get { return requiredTutors; }
        }

        public string Subject
        {
            get { return subject; }
        }

        public string Topic
        {
            get { return topic; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        public int Slots
        {
            get { return slots; }
        }

        public string Location
        {
            get { return location; }
        }

        public string SessionStatus
        {
            get { return sessionStatus; }
        }
    }
}
