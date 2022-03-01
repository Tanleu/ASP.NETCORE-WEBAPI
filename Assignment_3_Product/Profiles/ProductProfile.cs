using Assignment_3_Product.Models;
using AutoMapper;

namespace Assignment_3_Product.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        //Database -> Services
        CreateMap<ProductDBModel, ProductDTO>();

        //Service -> Database
        CreateMap<ProductDTO, ProductDBModel>();

        //Service => Controller
        CreateMap<ProductDTO, ProductPresentModel>();

        //Controller -> Service
        CreateMap<ProductPresentModel, ProductDTO>();
    }
}