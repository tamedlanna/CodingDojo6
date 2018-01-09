using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo6.ViewModel
{
   public class NavigationService 
    {

        private String lastViewId = "";
        private string currentViewId = null;

        public ViewModelBase GoBack() {
           if(lastViewId!=""){
                return SimpleFactory(lastViewId);
            }
            return SimpleFactory(currentViewId);
        }

        private ViewModelBase NavigateTo(string viewId) {
            return SimpleFactory(viewId);
        }

        private ViewModelBase SimpleFactory(string viewId)
        {
            lastViewId = currentViewId;
            switch(viewId) {
                case "Overview":
                    currentViewId = viewId;
                    return SimpleIoc.Default.GetInstance<OverviewVm>();

                case "My Toys":
                    currentViewId = viewId;
                    return SimpleIoc.Default.GetInstance<MyToysVm>();

                default:
                    return SimpleFactory(currentViewId);
            }
        }
    }
}
