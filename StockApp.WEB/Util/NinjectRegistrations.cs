using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using StockApp.BLL.DTO;
using StockApp.BLL.Interfaces;
using StockApp.BLL.Services;

namespace StockApp.WEB.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IServicesLists<StockDTO>>().To<StockService>();
        }
    }
}