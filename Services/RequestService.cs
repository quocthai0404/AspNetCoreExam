using AspdotNetCoreMVCExam.Models;

namespace AspdotNetCoreMVCExam.Services;

public interface RequestService
{
	public bool add(YeuCau yeucau);
	public bool update(YeuCau yeucau);
	public YeuCau findById(int id);
	public List<YeuCau> findAllBySender(string username);
	public List<YeuCau> findByDate(DateTime From, DateTime To, string username);
	public List<YeuCau> findByDateAndPriority(DateTime From, DateTime To, int PriorityId, string username);
	public List<YeuCau> findByPriority(int PriorityId, string username);

	//sender
	public dynamic findAllBySenderDynamic(string username);
	public dynamic findByDateDynamic(DateTime From, DateTime To, string username);
	public dynamic findByDateAndPriorityDynamic(DateTime From, DateTime To, int PriorityId, string username);
	public dynamic findByPriorityDynamic(int PriorityId, string username);

	public dynamic find(string From, string To, int PriorityId, string username);
	//admin
	public List<YeuCau> findAllByAdmin();
	public dynamic findAllDynamicByAdmin();
	public dynamic findByDateDynamicByAdmin(DateTime From, DateTime To);
	public dynamic findByDateAndPriorityDynamicByAdmin(DateTime From, DateTime To, int PriorityId);
	public dynamic findByPriorityDynamicByAdmin(int PriorityId);
	public dynamic findByAdmin(string From, string To, int PriorityId);

	// sp
	public List<YeuCau> findAllBySupport(string username);
	public dynamic findAllDynamicBySupport(string username);
	public dynamic findByDateDynamicBySupport(DateTime From, DateTime To, string username);
	public dynamic findByDateAndPriorityDynamicBySupport(DateTime From, DateTime To, int PriorityId, string username);
	public dynamic findByPriorityDynamicBySupport(int PriorityId, string username);
	public dynamic findBySupport(string sFrom, string sTo, int PriorityId, string username);
}
