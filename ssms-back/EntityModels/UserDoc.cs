using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class UsersDocs
    {
        public int UserDocId { get; set; }
        public string UserId { get; set; }
        public byte DocTypeId { get; set; }
        public string FilePath { get; set; }

        public DocType DocType { get; set; }
        public User User { get; set; }
    }
}
