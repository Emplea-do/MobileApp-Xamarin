using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
   
    public class Jobs
    {
        public string Link { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string JobType { get; set; }
        public string Location { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsRemote { get; set; }
        public int ViewCount { get; set; }
        public int Likes { get; set; }
        public string CompanyLogoUrl { get; set; }
        public string Description { get;set; }
        public string HowToApply { get; set; }
    }

    public class JobListModel
    {
        public List<Jobs> Jobs { get; set; }
        public int PageSize { get; set; }
        public int PagesCount { get; set; }
        public int PageNumber { get; set; }
        public int TotalItemCount { get; set; }
    }
}
