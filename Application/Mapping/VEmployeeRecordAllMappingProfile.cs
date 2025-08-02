using Application.Models.Common;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class VEmployeeRecordAllMappingProfile: Profile
    {
        public VEmployeeRecordAllMappingProfile()
        {
            CreateMap<VEmployeeRecordAll, SAPUserInfoModel>();
                //.ReverseMap();
        }
    }
}
