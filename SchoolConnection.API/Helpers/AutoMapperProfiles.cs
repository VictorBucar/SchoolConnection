using System;
using System.Linq;
using AutoMapper;
using SchoolConnection.API.Dtos;
using SchoolConnection.API.Models;

namespace SchoolConnection.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(x => x.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url)
                )
                .ForMember(dest => dest.Age, src => src.MapFrom(d => d.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailedDto>()
                .ForMember(x => x.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url)
                )
                .ForMember(dest => dest.Age, opt => {opt.MapFrom(d => d.DateOfBirth.CalculateAge());});
  
            CreateMap<Photo, PhotosForDetailedDto>();
        }

        
    }
   
}