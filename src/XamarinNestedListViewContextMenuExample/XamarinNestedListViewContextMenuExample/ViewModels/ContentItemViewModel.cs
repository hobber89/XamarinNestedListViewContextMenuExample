﻿using System;
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
        public ObservableCollection<ContentItemViewModel> ContentItems { get; set; } = new ObservableCollection<ContentItemViewModel>();
        public ContentItemViewModel This => this;
        public GridLength Height = GridLength.Auto;

        ContentItemModel _contentItem;

        public ContentItemViewModel(ContentItemModel contentItem)
        {
            _contentItem = contentItem;

            foreach(ContentItemModel subItem in _contentItem.ContentItems)
            {
                ContentItems.Add(new ContentItemViewModel(subItem));
            }
        }

        public void OnSizeAllocated(double width, double height)
        {
            Height = height;
        }
    }
}
