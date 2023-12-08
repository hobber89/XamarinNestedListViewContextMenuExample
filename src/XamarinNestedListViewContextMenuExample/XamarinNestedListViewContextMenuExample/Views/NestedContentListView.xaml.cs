using System.ComponentModel;
using Xamarin.Forms;
using XamarinNestedListViewContextMenuExample.ViewModels;

namespace XamarinNestedListViewContextMenuExample.Views
{
    public partial class NestedContentListView : ContentView
    {
        public NestedContentListView()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            ContentItemViewModel viewModel = BindingContext as ContentItemViewModel;
            if (viewModel == null)
                return;

            viewModel.OnSizeAllocated(width, height);
        }
    }
}