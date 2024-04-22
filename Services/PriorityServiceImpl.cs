using AspdotNetCoreMVCExam.Models;

namespace AspdotNetCoreMVCExam.Services;

public class PriorityServiceImpl : PriorityService
{
	private DatabaseContext db;
	public PriorityServiceImpl(DatabaseContext _db) { 
		db = _db;	
	}
	public List<DoUuTien> findAll()
	{
		return db.DoUuTiens.ToList();

	}

	public string findNameById(int id)
	{
		DoUuTien doUuTien = db.DoUuTiens.Find(id);
		return doUuTien.TendouuTien;
	}
}
