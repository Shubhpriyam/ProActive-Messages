using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHandson.DTOs;
using WebApiHandson.Models;

namespace WebApiHandson.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //SOurce - > target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
