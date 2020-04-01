using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.Services
{
    public class AppConstant
    {
        public const string ApiUrl = "URL";
        public const string AppSecrets = "ApiKey";
        public const string ApiEndPointSearch = "jobs/search";
        public const string ApiEndPointDetail = "jobs/detail/";
        public const int PageSize = 50;


        public static readonly Color Background = Color.FromHex("F8F8F8");

    }
}