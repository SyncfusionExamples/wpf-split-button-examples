using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Split_Button_MenuItem_Binding
{
    class CountryViewModel
    {
        private List<Country> dropDownItems;

        public List<Country> DropDownItems
        {
            get
            {
                return dropDownItems;
            }
            set
            {
                dropDownItems = value;
            }
        }

        public CountryViewModel()
        {
            DropDownItems = new List<Country>();
            DropDownItems.Add(new Country()
            {
                Name = "India",
                Flag = new BitmapImage(new Uri("/Images/india.png", UriKind.RelativeOrAbsolute))
            });
            DropDownItems.Add(new Country()
            {
                Name = "France",
                Flag = new BitmapImage(new Uri("/Images/france.png", UriKind.RelativeOrAbsolute))
            });
            DropDownItems.Add(new Country()
            {
                Name = "Germany",
                Flag = new BitmapImage(new Uri("/Images/germany.png", UriKind.RelativeOrAbsolute))
            });
        }
    }
}
