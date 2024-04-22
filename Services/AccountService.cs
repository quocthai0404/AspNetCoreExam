using AspdotNetCoreMVCExam.Models;

namespace AspdotNetCoreMVCExam.Services;

public interface AccountService
{
	public bool Login(string username, string password);
    //public bool Exist(string username);
    public NhanVien FindByUsername(string username);
	public bool Update(NhanVien nv);
	public bool Add(NhanVien nv);
}
