using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public partial class Procedure
    {
        public Procedure()
        {
            StudentsProcedures = new HashSet<StudentProcedure>();
            IsDeleted = false;
        }

        public short ProcedureId { get; set; }
        public string ProcedureNameAr { get; set; }
        public string ProcedureNameEn { get; set; }
        public byte? AtViolationDegreeId { get; set; }
        public byte AtRepetition { get; set; }
        public string NotesAr { get; set; }
        public string NotesEn { get; set; }
        public bool? IsDeleted { get; set; }

        public ViolationDegree _ViolationDegree { get; set; }
        public ICollection<StudentProcedure> StudentsProcedures { get; set; }
    }
}
