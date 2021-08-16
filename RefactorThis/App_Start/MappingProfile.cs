using AutoMapper;
using refactor_this.Models;
using refactor_this.Context;
using System;

namespace refactor_me.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, TblProduct>();

            CreateMap<ProductOptions, TblProductOption>();
        }

        protected override void Configure()
        {
            throw new NotImplementedException();
        }
    }
}