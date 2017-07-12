using AutoMapper;
using BusinessLayer.DTOs;
using Dal.DTOs;
using DBModelLib.Entities;
using System.Collections;
using System.Collections.Generic;

namespace LittleHelperApi
{ 
    /// <summary>
    ///  Gloabel auto mapper configuration
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Constructor for configuration
        /// </summary>
        public AutoMapperConfig()
        {
            Mapper.Initialize(configuration =>
            {
                CreateMap<User, UserDto>()
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(m => m.City, opt => opt.MapFrom(s => s.City))
                .ForMember(m => m.EMail, opt => opt.MapFrom(s => s.EMail))
                .ForMember(m => m.Street, opt => opt.MapFrom(s => s.Street))
                .ForMember(m => m.SurName, opt => opt.MapFrom(s => s.SurName))
                .ForMember(m => m.ZipCode, opt => opt.MapFrom(s => s.ZipCode))
                .ForMember(m => m.Nickname, opt => opt.MapFrom(s => s.Nickname))
                ;

                CreateMap<UserDto, User>()
                .ForMember(m => m.Inventars, opt => opt.Ignore())
                .ForMember(m => m.Friendslist, opt => opt.Ignore())
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(m => m.City, opt => opt.MapFrom(s => s.City))
                .ForMember(m => m.EMail, opt => opt.MapFrom(s => s.EMail))
                .ForMember(m => m.Street, opt => opt.MapFrom(s => s.Street))
                .ForMember(m => m.SurName, opt => opt.MapFrom(s => s.SurName))
                .ForMember(m => m.ZipCode, opt => opt.MapFrom(s => s.ZipCode))
                .ForMember(m => m.Nickname, opt => opt.MapFrom(s => s.Nickname))
                ;

                CreateMap<Food, FoodDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Messurement, opt => opt.MapFrom(s => s.Messurement.Name))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.FoodSort, opt => opt.MapFrom(s => s.FoodSort.Name))
                ;

                CreateMap<Inventar, InventarDto>()
                .ForMember(m => m.InventarName, opt => opt.MapFrom(s => s.Guid))
                .ForMember(m => m.InventarId, opt => opt.Ignore())
                .ForMember(m => m.Foods, opt => opt.MapFrom(s => new List<Food> { s.Food }))
                ;
            });
        }
    }
}