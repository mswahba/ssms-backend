using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class JobAction
    {
        public JobAction()
        {
            IsDeleted = false;
        }
        public short JobId { get; set; }
        public short ActionId { get; set; }
        public bool? IsDeleted { get; set; }

        public Action Action { get; set; }
        public Job Job { get; set; }
    }
}
