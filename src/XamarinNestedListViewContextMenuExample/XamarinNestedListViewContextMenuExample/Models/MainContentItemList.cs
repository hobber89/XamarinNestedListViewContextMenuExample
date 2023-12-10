using System;
using System.Runtime.Serialization;

namespace XamarinNestedListViewContextMenuExample.Models
{
    [DataContract]
    internal class MainContentItemList : ContentItemModel
    {
        public MainContentItemList(Guid? id = null) : base(id)
        {

        }
    }
}
