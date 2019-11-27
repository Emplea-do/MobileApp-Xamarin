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
        public const string ApiUrl = "https://emplea-apm.azure-api.net/v1/api";
        public const string AppSecrets = "155d4cd48bb34ba0b8375fd50b779b85";
        public const string ApiEndPoint = "jobs";
        public const int PageSize = 10;


        public static readonly Color  Background = Color.FromHex("F8F8F8");

    }
}
