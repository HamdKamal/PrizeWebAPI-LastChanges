using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Common
{
    public class SAPUserInfoModel
    {     
        public string? EmployeeName { get; set; }
        public string? UID { get; set; }
        public string? JobTitle { get; set; }
        public string? DepartmentNameAr { get; set; }
        public string NationalId { get; set; }
        public string? Extention { get; set; }
        public string? Mobile { get; set; }
        public int? JobRank { get; set; }
        public string? JobDegree { get; set; }
        public string? Email { get; set; }
        public string NationalType { get; set; }
        public DateTime? BrithDate { get; set; }
        public bool IsSapUser { get; set; }
        public string? LocationCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? DepartmentCode { get; set; }
        public Nullable<int> DegreeCode { get; set; }
        public Nullable<int> MajorCode { get; set; }
        public string? SectorCode { get; set; }
        public string? SectionCode { get; set; }       

    }
}
