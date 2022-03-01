using Assignment_3_Product.Models;
using AutoMapper;

namespace Assignment_3_Product.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        //Database -> Services 2 ways
        CreateMap<CategoryDBModel, CategoryDTO>();

        //Service -> Database
        CreateMap<CategoryDTO, CategoryDBModel>();
 
        //Service => Controller
        CreateMap<CategoryDTO, CategoryPresentModel>();

        //Controller -> Service
        CreateMap<CategoryPresentModel, CategoryDTO>();
    }
}