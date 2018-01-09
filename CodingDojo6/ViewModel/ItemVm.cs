using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
   public class ItemVm:ViewModelBase
    {
        public string Description { get; set; }
        public BitmapImage Image { get; set; }

        public ObservableCollection<ItemVm> Items { get; set; }

        public string AgeRecomm { get; set; }


        public int NoOfItems
        {
            get
            {
                if (Items != null)
                {
                    return Items.Count;
                }
                else
                    return 0;

            }
        }

        public ItemVm(string description, BitmapImage image, string reco)
        {
            Description = description;
            Image = image;
            this.AgeRecomm = reco;
        }

        public void AddItem(ItemVm item)
        {
            if (Items == null)
            {
                Items = new ObservableCollection<ItemVm>();
                Items.Add(item);
            }
        }
    
}
}
