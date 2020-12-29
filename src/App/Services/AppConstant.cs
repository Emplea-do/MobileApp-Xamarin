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
        public const string ApiUrl = "";
        public const string AppSecrets = "";
        public const string ApiEndPoint = "jobs";
        public const int PageSize = 50;
        public const string ApiEndPointSearch = "jobs/search";
        public const string ApiEndPointDetail = "jobs/detail/";

        public const string AppCenteriOS = "";
        public const string AppCenterAndroid = "";



        public static readonly Color Background = Color.FromHex("F8F8F8");

    }
}