using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum FormStatusEnum
    {
        Draft=1,
        Applied,
        UnderReview, 
        Reset, 
        Accepted, 
        Denied, 
        ExpiredWithoutModification, 
        Reapply,
        DeletedByUser

    }
}
