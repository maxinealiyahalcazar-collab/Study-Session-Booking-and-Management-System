using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Study_Session
{
    public class Session
    {
        private int sessionId;
        private int? creatorStudentId;
        private int? creatorTutorId;
        private string creatorTutorName = "";
        private int requiredTutors;
        private string subject  = "";
        private string topic = "";
        private DateTime startDateTime;
        private DateTime endDateTime;
        private int slots;
        private int occupiedSlots;
        private int availableSlots;
        private int waitlistedCount;
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

        public string CreatorTutorName
        {
            get { return creatorTutorName; }
            set { creatorTutorName = value; }
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

        public DateTime StartDateTime
        {
            get { return startDateTime; }
        }

        public DateTime EndDateTime
        {
            get { return endDateTime; }
        }

        public int Slots
        {
            get { return slots; }
        }

        public int OccupiedSlots
        {
            get { return occupiedSlots; }
        }

        public int AvailableSlots
        {
            get { return availableSlots; }
        }

        public int WaitlistedCount
        {
            get { return waitlistedCount; }
        }

        public string Location
        {
            get { return location; }
        }

        public string SessionStatus
        {
            get { return sessionStatus; }
        }

        public Session(int sessionId, int? creatorStudentId, int? creatorTutorId, int requiredTutors, string subject, string topic,
        DateTime startDateTime, DateTime endDateTime, int slots, string location, string sessionStatus, int occupiedSlots, int availableSlots, int waitlistedCount)
        {
            this.sessionId = sessionId;
            this.creatorStudentId = creatorStudentId;
            this.creatorTutorId = creatorTutorId;
            this.requiredTutors = requiredTutors;
            this.subject = subject;
            this.topic = topic;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.slots = slots;
            this.occupiedSlots = occupiedSlots;
            this.availableSlots = availableSlots;
            this.waitlistedCount = waitlistedCount;
            this.location = location;
            this.sessionStatus = sessionStatus;

        }

        public bool EditSession(string subject, string topic, DateTime startDateTime, DateTime endDateTime, int slots, int requiredTutors, string location)
        {
            if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(topic) || string.IsNullOrWhiteSpace(location) || startDateTime <= DateTime.Now ||
            endDateTime <= startDateTime || slots <= 0 || requiredTutors < 0)
            {
                return false;
            }

            this.subject = subject;
            this.topic = topic;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.slots = slots;
            this.requiredTutors = requiredTutors;
            this.location = location;

            return true;
        }

        public void CompleteSession()
        {
            this.sessionStatus = "Completed";
        }

        public void CancelSession()
        {
            this.sessionStatus = "Cancelled";
        }

        public bool AddMaterials(string materialName, string description, string fileLink)
        {
            return !string.IsNullOrWhiteSpace(materialName)
            && !string.IsNullOrWhiteSpace(fileLink);
        }

        public DataTable ViewMaterials(SessionRepository repository)
        {
            return repository.GetMaterialsBySessionId(sessionId);
        }

        public void RestoreSessionStatus(string status)
        {
            this.sessionStatus = status;
        }
    }
}
