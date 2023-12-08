using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinNestedListViewContextMenuExample.Models;
using XamarinNestedListViewContextMenuExample.ViewModels;

namespace XamarinNestedListViewContextMenuExample
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;
        }
    }
}
