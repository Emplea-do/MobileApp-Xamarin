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
                return $"<html lang='es'><head><meta charset='UTF-8'/><style></style></head><body>{JobDescription} </body></html>";
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
                return $"<html><head><style></style></head><body> {HowToApply} </body></html>";
            }
        }
        public Company Company { get; set; }
    }
}
