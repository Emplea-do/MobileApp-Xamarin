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
        public const string AppSecrets = "Empleado-APIKEY";
        public const string ApiEndPoint = "jobs";
        public const int PageSize = 50;


        public static readonly Color Background = Color.FromHex("F8F8F8");

    }
}