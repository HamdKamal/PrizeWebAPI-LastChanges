using AutoMapper.Internal;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Forms.Queries.Statuses
{
    public class GetStatusesQueryHandler : IGetStatusesQueryHandler
    {
        private IStatusRepository _statusesRepository;

        public GetStatusesQueryHandler(
            IStatusRepository statusesRepository
            ) 
        { 
            _statusesRepository = statusesRepository;
        }

        public async Task<List<Status>> HandleGetAllStatusesAsync()
        {
            List<Status> result = new List<Status>();

            result = await _statusesRepository.GetAllStatuses();

            return result;
        }


    }
}
