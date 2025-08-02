using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Common;

namespace Application.Abstractions.Common
{
    public interface ICurrentUserService
    {
        SAPUserInfoModel User { get; }

    }
}
