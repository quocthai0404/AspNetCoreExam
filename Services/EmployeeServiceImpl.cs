using AspdotNetCoreMVCExam.Models;

namespace AspdotNetCoreMVCExam.Services;

public class EmployeeServiceImpl : EmployeeService
{
	private DatabaseContext db;
	public EmployeeServiceImpl(DatabaseContext _db)
	{
		db = _db;
	}

	public List<NhanVien> findAll()
	{
		return db.NhanViens.Where(emp => emp.Quyen==2 || emp.Quyen==1).ToList();
	}

	public dynamic findSupportEmpDynamic()
	{
		return db.NhanViens.Where(e => e.Quyen == 2).Select(e => new {
			Username = e.Username,
			Hoten = e.Hoten,
			Ngaysinh = e.Ngaysinh.ToString("yyyy/MM/dd"),
			Hinhanh = e.Hinhanh
		}).ToList();
	}

	public List<NhanVien> findSupportEmps()
	{
		return db.NhanViens.Where(e => e.Quyen==2).ToList();
	}
}
