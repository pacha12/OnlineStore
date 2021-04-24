using AutoMapper;
using OnlineStore_Domain.Models;
using OnlineStore_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore_UI.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

        }
    }
}
