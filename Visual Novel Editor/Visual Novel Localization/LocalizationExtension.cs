using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Resources;

namespace Vnrt.Localization
{
    public class LocalizationExtension : CustomXamlResourceLoader
    {
        //This can obviously be made more generic. text-AppName, image-coolLook...but this will work for now
        protected override object GetResource(string resourceId, string objectType, string propertyName, string propertyType)
        {
            try
            {
                ResourceLoader loader = ResourceLoader.GetForCurrentView("Vnrt.Localization\\" + CultureInfo.CurrentCulture.Name);
                return loader.GetString(resourceId);
            }
            catch
            {
                return "";
            }
        }
    }
}
