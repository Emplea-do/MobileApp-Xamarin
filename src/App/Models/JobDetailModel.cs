using System;
namespace App.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
    }

    public class JobDetailModel
    {
        public string Link { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobDescriptionHtml {
            get
            {
                string textHtml = "<html lang='es'><head><meta charset='UTF-8'/><style>body{font-family: 'Arial'; font-size: 18px; color: #9eabba;}</style></head><body>";
                textHtml = textHtml + JobDescription + "</body></html>";
                return textHtml;
            }
        }
        public string JobType { get; set; }
        public string Location { get; set; }
        public int Visits { get; set; }
        public bool IsRemote { get; set; }
        public string HowToApply { get; set; }
        public string HowToApplyHtml
        {
            get
            {
                string textHtml = "<html><head><style>body{font-family: 'Arial'; font-size: 18px; color: #9eabba;}</style></head><body>";
                textHtml = textHtml + HowToApply + "</body></html>";
                return textHtml;
            }
        }
        public Company Company { get; set; }
    }
}
