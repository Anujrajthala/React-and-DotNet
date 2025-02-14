using AutoMapper;
using ToDoListAPI.Models;
using ToDoListAPI.DTOs;
using Microsoft.Data.SqlClient;

public class AutoMapperProfiles: Profile{
    public AutoMapperProfiles(){
        CreateMap<TodoCreateDTO, TodoItem>();
        CreateMap<TodoItem,TodoResponseDTO>();
        CreateMap<ApplicationUser,UserResponseDTO>();
        CreateMap<RegisterDTO,ApplicationUser>()
        .ForMember(dest=> dest.UserName,opt=> opt.MapFrom(src=> src.Email))
        .ForMember(dest=> dest.Email,opt=> opt.MapFrom(src=> src.Email ));
        CreateMap<LoginDTO,ApplicationUser>()
        .ForMember(dest=> dest.Email, opt=> opt.MapFrom(src=> src.Email));
        CreateMap<TodoUpdateDTO,TodoItem>();
    }
}
