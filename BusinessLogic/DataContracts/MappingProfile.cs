using AutoMapper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DataContracts
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;
            CreateMap<Record, RecordDto>().ReverseMap();
        }
    }
}
