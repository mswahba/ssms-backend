using System;
using System.Collections.Generic;

namespace SSMS.Models
{
    public partial class UserDocs
    {
        public int UserId { get; set; }
        public byte DocTypeId { get; set; }
        public string FilePath { get; set; }
    }
}
