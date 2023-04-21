using AutoMapper;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.View_Models;

namespace EmployeeLeaveManagement.Mapping
{
    public class Maps : Profile
    {


        public Maps()
        {

            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();




        }
    }
}
