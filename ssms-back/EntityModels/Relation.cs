using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class Relation
    {
        public Relation()
        {
            StudentsRelatives = new HashSet<StudentRelative>();
        }

        public byte RelationId { get; set; }
        public string RelationNameAr { get; set; }
        public string RelationNameEn { get; set; }

        public ICollection<StudentRelative> StudentsRelatives { get; set; }
    }
}
