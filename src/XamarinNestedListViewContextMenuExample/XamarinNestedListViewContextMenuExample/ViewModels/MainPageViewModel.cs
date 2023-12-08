
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinNestedListViewContextMenuExample.Models;

namespace XamarinNestedListViewContextMenuExample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        public string PageTitle => "XamarinNestedListViewContextMenuExample";

        public ContentItemViewModel TopLevelContentItem { get; private set; }

        public MainPageViewModel()
        {
            ContentItemModel contentItem = new ContentItemModel("FIRST ITEM");
            TopLevelContentItem =  new ContentItemViewModel(contentItem);
            ContentItemModel subContentItem = new ContentItemModel("FIRST SUB ITEM");
            TopLevelContentItem.AddSubContentItem(subContentItem);
        }
    }
}
