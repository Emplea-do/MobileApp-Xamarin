using App.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App.Views
{
    public partial class JobDetailView : ContentPage
    {
        public JobDetailView(string link)
        {
            InitializeComponent();
           // BindingContext = new JobDetailViewModel(link);
        }
    }
}
