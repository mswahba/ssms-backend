using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class Article
    {
        public Article()
        {
            ArticleDate = DateTime.UtcNow.AddHours(3);
            DisplayAlsoAt = "none";
        }
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleText { get; set; }
        public DateTime ArticleDate { get; set; }
        public string AuthorName { get; set; }
        public string MainPhotoURL { get; set; }
        public string PhotosURLs { get; set; }
        public string VideosURLs { get; set; }
        public string DisplayAlsoAt { get; set; }
        public bool ForCompany { get; set; }
        public bool Approved { get; set; }
        public bool Enabled { get; set; }
        public byte? SchoolId { get; set; }
        public byte? StageId { get; set; }
        public int? EmpJobId { get; set; }
        public string CategoryIds { get; set; }
        public string Keywords { get; set; }

        public School _School { get; set; }
        public Department _Department { get; set; }
        public EmployeeJob _EmployeeJob { get; set; }
    }
}
