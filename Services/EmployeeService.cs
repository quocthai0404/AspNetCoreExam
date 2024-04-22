using AspdotNetCoreMVCExam.Models;

namespace AspdotNetCoreMVCExam.Services;

public interface EmployeeService
{
	public List<NhanVien> findSupportEmps();
	public dynamic findSupportEmpDynamic();
	public List<NhanVien> findAll();
}
