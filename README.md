# XamarinNestedListViewContextMenuExample

This repository contains a Xamarin project with an UWP app and shows a nested ListView per ContentView, which can contain another instance of itself.
Every item in the ListView implements a ViewCell.ContextActions MenuItem to highlight itself.

**But:** if one clicks on the sub item to highlight it, the top level item is highlighted. This must be fixed!