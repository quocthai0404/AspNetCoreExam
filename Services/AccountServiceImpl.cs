using AspdotNetCoreMVCExam.Models;
using System.Security.AccessControl;

namespace AspdotNetCoreMVCExam.Services;

public class AccountServiceImpl : AccountService
{
	private DatabaseContext db;
	public AccountServiceImpl(DatabaseContext _db)
	{
		db = _db;
	}
	//public bool Exist(string username)
	//{
	//    throw new NotImplementedException();
	//}

	public NhanVien FindByUsername(string username)
	{
		return db.NhanViens.SingleOrDefault(a => a.Username == username);
	}
	public bool Login(string username, string password)
	{
		NhanVien nv = db.NhanViens.SingleOrDefault(a => a.Username == username);
		if (nv != null)
		{
			if (BCrypt.Net.BCrypt.Verify(password, nv.Password))
			{
				return true;
			}
		}
		return false;

	}

	public bool Update(NhanVien nv)
	{

		try
		{
			db.Entry(nv).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return db.SaveChanges() > 0;
		}
		catch
		{
			return false;
		}

	}
}
