using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.Configuration
{
    public static class AppSetting
    {
        public static string APIBaseUrl { get; } = ConfigurationManager.AppSettings["APIBaseUrl"];
    }
}
