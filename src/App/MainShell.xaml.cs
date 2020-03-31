using App.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("listJobs", typeof(JobsListView));
        }
    }
}
