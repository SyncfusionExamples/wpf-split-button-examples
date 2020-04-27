using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SplitButton_Custom_Items
{
    public class ColorViewModel : NotificationObject
    {
        public ObservableCollection<UIElement> color = new ObservableCollection<UIElement>();
        public ObservableCollection<UIElement> items = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Colors
        {
            get { return color; }
            set { color = value; RaisePropertyChanged("Colors"); }
        }

        public ObservableCollection<UIElement> Items
        {
            get { return items; }
            set { items = value; RaisePropertyChanged("Items"); }
        }


        public ColorViewModel()
        {
            Colors.Add(new DropDownMenuItem() { Header = "More Items", Icon = new Image() { Source = new BitmapImage(new Uri("/Images/skyblue.png", UriKind.RelativeOrAbsolute)) } });
            Items.Add(new Label() { Content = "More Items" });
        }
    }
}
