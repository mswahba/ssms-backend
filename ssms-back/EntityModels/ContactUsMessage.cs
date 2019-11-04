using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class ContactUsMessage
    {
        public ContactUsMessage()
        {
            IsDeleted = false;
        }
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string MessageTitle { get; set; }
        public string MessageText { get; set; }
        public int? EmpJobId { get; set; }
        public string ReplayNotes { get; set; }
        public bool? IsDeleted { get; set; }

        public EmployeeJob EmpJob { get; set; }

    }
}
