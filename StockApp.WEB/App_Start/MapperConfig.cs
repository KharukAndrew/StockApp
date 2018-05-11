using AutoMapper;
using StockApp.BLL.DTO;
using StockApp.BLL.Util;
using StockApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockApp.WEB.App_Start
{
    public class MapperConfig
    {
        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, ProductDTO>();
                cfg.CreateMap<ProviderDTO, ProviderViewModel>();
                cfg.CreateMap<ProviderViewModel, ProviderDTO>();
                cfg.CreateMap<StockDTO, StockViewModel>();
                cfg.CreateMap<StockViewModel, StockDTO>();
            });
        }
    }
}