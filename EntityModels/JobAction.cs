using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class JobAction
    {
        public short JobId { get; set; }
        public short ActionId { get; set; }

        public Action Action { get; set; }
        public Job Job { get; set; }
    }
}
