
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinNestedListViewContextMenuExample.Models;

namespace XamarinNestedListViewContextMenuExample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        public string PageTitle => "XamarinNestedListViewContextMenuExample";
        public ButtonCommandBinding DebugButtonCommandBinding { get; private set; }

        public ContentItemViewModel TopLevelContentItem { get; private set; }

        public MainPageViewModel()
        {
            MainContentItemList mainContentItemList = new MainContentItemList();
            TopLevelContentItem =  new ContentItemViewModel(mainContentItemList, null);
            ContentItemModel subContentItem1 = new ContentItemModel("FIRST ITEM");

            ContentItemModel subContentItem1_1 = new ContentItemModel("FIRST SUB ITEM");
            subContentItem1.ContentItems.Add(subContentItem1_1);
            TopLevelContentItem.AddSubContentItem(subContentItem1);

            ContentItemModel subContentItem2 = new ContentItemModel("SECOND ITEM");
            TopLevelContentItem.AddSubContentItem(subContentItem2);
        }
    }
}
