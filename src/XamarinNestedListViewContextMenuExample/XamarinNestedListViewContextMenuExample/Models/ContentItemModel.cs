using System;
using System.Collections.Generic;

namespace XamarinNestedListViewContextMenuExample.Models
{
    public class ContentItemModel
    {
        public string ContentText { get; set; }
        public Guid ID;
        public List<ContentItemModel> ContentItems { get; set; } = new List<ContentItemModel>();

        public ContentItemModel(string contentText, Guid? id = null)
        {
            ContentText = contentText ?? throw new ArgumentNullException(nameof(contentText), "Must not be null!");
            ID = id ?? Guid.NewGuid();
        }

        protected ContentItemModel(Guid? id = null)
        {
            ContentText = null;
            ID = id ?? Guid.NewGuid();
        }
    }
}
