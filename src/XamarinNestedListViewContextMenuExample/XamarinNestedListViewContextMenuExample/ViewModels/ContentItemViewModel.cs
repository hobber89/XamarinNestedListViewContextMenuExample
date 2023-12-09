using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinNestedListViewContextMenuExample.Models;

namespace XamarinNestedListViewContextMenuExample.ViewModels
{
    internal class ContentItemViewModel : ViewModelBase
    {
        public string ContentText { get => _contentItem.ContentText; }
        public Guid ID => _contentItem.ID;
        public ObservableCollection<ContentItemViewModel> ContentItems { get; set; } = new ObservableCollection<ContentItemViewModel>();
        public ContentItemViewModel This => this;
        public GridLength Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
        GridLength _height = GridLength.Auto;
        public GridLength SubItemsHeight
        {
            get => _subItemsHeight;
            set => SetProperty(ref _subItemsHeight, value);
        }
        GridLength _subItemsHeight = GridLength.Auto;
        public GridLength TotalHeight
        {
            get
            {
                if (Height.IsAuto || (SubItemsHeight.IsAuto && HasSubContentItems))
                    return GridLength.Auto;
                if (HasSubContentItems == false)
                    return Height.Value;
                return Height.Value + SubItemsHeight.Value;
            }
        }
        public bool HasSubContentItems { get => _contentItem.ContentItems.Count > 0; }

        ContentItemModel _contentItem;
        ContentItemViewModel _parentViewModel;
        Dictionary<Guid, GridLength> _subItemsHeightMap = new Dictionary<Guid, GridLength>();

        public ContentItemViewModel(ContentItemModel contentItem, ContentItemViewModel parentViewModel)
        {
            _contentItem = contentItem;
            _parentViewModel = parentViewModel;

            foreach(ContentItemModel subItem in _contentItem.ContentItems)
            {
                ContentItems.Add(new ContentItemViewModel(subItem, this));
            }
        }

        public void AddSubContentItem(ContentItemModel subContentItem)
        {
            _contentItem.ContentItems.Add(subContentItem);
            ContentItems.Add(new ContentItemViewModel(subContentItem, this));

            //If this subContenItem is the first item, HasSubContentItems has changed
            if (ContentItems.Count == 1)
                OnPropertyChanged(nameof(HasSubContentItems));
        }

        public void OnSizeAllocated(double width, double height)
        {
            //Currently size depends on Height of own and childrens (in list) ContentTextLabel -> use them to define height
        }

        public void ContentTextLabel_SizeChanged(object sender, System.EventArgs e)
        {
            Label contentTextLabel = sender as Label;
            if (contentTextLabel != null)
                Height = contentTextLabel.Height;

            _parentViewModel?.OnSubContentTextLabel_SizeChanged(this);
        }

        public void OnSubContentTextLabel_SizeChanged(ContentItemViewModel subContentItemViewModel)
        {
            if (_subItemsHeightMap.ContainsKey(subContentItemViewModel.ID) == false)
                _subItemsHeightMap.Add(subContentItemViewModel.ID, subContentItemViewModel.TotalHeight);
            else
                _subItemsHeightMap[subContentItemViewModel.ID] = subContentItemViewModel.TotalHeight;

            double subItemsHeight = 0;
            foreach(GridLength subContentItemHeight in _subItemsHeightMap.Values)
            {
                if(subContentItemHeight.IsAuto)
                {
                    SubItemsHeight = GridLength.Auto;
                    return;
                }
                subItemsHeight += subContentItemHeight.Value;
            }
            SubItemsHeight = subItemsHeight;

            _parentViewModel?.OnSubContentTextLabel_SizeChanged(this);
        }
    }
}
