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
        public string DescriptionHtml {
            get {
                string textHtml = "<html lang='es'><head><meta charset='UTF-8'/><style>body{font-family: 'Arial'; font-size: 18px; color: #9eabba;}</style></head><body>";
                textHtml = textHtml + Description + "</body></html>";
                return textHtml;
            } }
        public string HowToApply { get; set; }
        public string HowToApplyHtml {
            get {
                string textHtml = "<html><head><style>body{font-family: 'Arial'; font-size: 18px; color: #9eabba;}</style></head><body>";
                textHtml = textHtml + HowToApply + "</body></html>";
                return textHtml;
            }
        }
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
