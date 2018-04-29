using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class RemedialProcedure
    {
        public RemedialProcedure()
        {
            StudentsProcedures = new HashSet<StudentProcedure>();
        }

        public short ProcedureId { get; set; }
        public string ProcedureNameAr { get; set; }
        public string ProcedureNameEn { get; set; }
        public byte? CategoryId { get; set; }

        public ICollection<StudentProcedure> StudentsProcedures { get; set; }
    }
}
