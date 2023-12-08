﻿
using System.Collections.Generic;

namespace XamarinNestedListViewContextMenuExample.Models
{
    public class ContentItemModel
    {
        public string ContentText { get; set; }
        public List<ContentItemModel> ContentItems { get; set; } = new List<ContentItemModel>();

        public ContentItemModel(string contentText)
        {
            ContentText = contentText;
        }
    }
}