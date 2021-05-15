using AutoMapper;
using IdentityOAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Mapper
{
    public class MapperConfig
    {
        public static IMapper mapp { get; set; }

        static MapperConfig()
        {
            var config = new MapperConfiguration(
          cfg =>
          {
              
              cfg.CreateMap<CartProduct, CartProductDto>().ReverseMap();


          });

            mapp = config.CreateMapper();
        }
    }
}