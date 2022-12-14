using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.Persistance.Contracts;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<LeaveType> GetLeaveTypeWithDetails(int Id);
    Task<List<LeaveType>> GetLeaveTypesList();
    Task<LeaveType> AddLeaveType(LeaveType leaveType);


}