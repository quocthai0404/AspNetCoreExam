using AspdotNetCoreMVCExam.Models;

namespace AspdotNetCoreMVCExam.Services;

public interface PriorityService
{
	public List<DoUuTien> findAll();
	public string findNameById(int id);
}
