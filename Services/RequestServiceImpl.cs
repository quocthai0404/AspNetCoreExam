using AspdotNetCoreMVCExam.Models;
using System.Collections.Generic;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace AspdotNetCoreMVCExam.Services;

public class RequestServiceImpl : RequestService
{

	private DatabaseContext db;
	public RequestServiceImpl(DatabaseContext _db)
	{
		db = _db;
	}
	public bool add(YeuCau yeucau)
	{
		try
		{
			db.YeuCaus.Add(yeucau);
			return db.SaveChanges() > 0;
		}
		catch
		{
			return false;
		}
	}

	public List<YeuCau> findAllByAdmin()
	{
		return db.YeuCaus.ToList();
	}

	public List<YeuCau> findAllBySender(string username)
	{
		return db.YeuCaus.Where(r => r.ManvGui == username).ToList();
	}

	public dynamic findAllBySenderDynamic(string username)
	{
		return db.YeuCaus.Where(r => r.ManvGui == username).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public List<YeuCau> findAllBySupport(string username)
	{
		return db.YeuCaus.Where(r=> r.ManvXuly==username).ToList();
	}

	public dynamic findAllDynamicByAdmin()
	{
		return db.YeuCaus.Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public dynamic findAllDynamicBySupport(string username)
	{
		var list = findAllBySupport(username);
		return list.Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public List<YeuCau> findByDate(DateTime From, DateTime To, string username)
	{
		var list = findAllBySender(username);
		return list.Where(r => r.Ngaygui >= From && r.Ngaygui <= To).ToList();
	}

	public List<YeuCau> findByDateAndPriority(DateTime From, DateTime To, int PriorityId, string username)
	{
		var list = findAllBySender(username);
		return list.Where(r => r.Ngaygui >= From && r.Ngaygui <= To && r.Madouutien == PriorityId).ToList();
	}

	public dynamic findByDateAndPriorityDynamic(DateTime From, DateTime To, int PriorityId, string username)
	{
		var list = findAllBySender(username);
		return list.Where(r => r.Ngaygui >= From && r.Ngaygui <= To && r.Madouutien == PriorityId).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public dynamic findByDateAndPriorityDynamicByAdmin(DateTime From, DateTime To, int PriorityId)
	{
		return db.YeuCaus.Where(r => r.Ngaygui >= From && r.Ngaygui <= To && r.Madouutien == PriorityId).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public dynamic findByDateAndPriorityDynamicBySupport(DateTime From, DateTime To, int PriorityId, string username)
	{
		var list = findAllBySupport(username);
		return list.Where(r => r.Ngaygui >= From && r.Ngaygui <= To && r.Madouutien == PriorityId).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public dynamic findByDateDynamic(DateTime From, DateTime To, string username)
	{
		var list = findAllBySender(username);
		return list.Where(r => r.Ngaygui >= From && r.Ngaygui <= To).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();


	}

	public dynamic findByDateDynamicByAdmin(DateTime From, DateTime To)
	{
		return db.YeuCaus.Where(r => r.Ngaygui >= From && r.Ngaygui <= To).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public dynamic findByDateDynamicBySupport(DateTime From, DateTime To, string username)
	{
		var list = findAllBySupport(username);
		return list.Where(r => r.Ngaygui >= From && r.Ngaygui <= To).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public YeuCau findById(int id)
	{
		return db.YeuCaus.SingleOrDefault(r => r.Mayeucau == id);
	}

	public List<YeuCau> findByPriority(int PriorityId, string username)
	{
		var list = findAllBySender(username);
		return list.Where(r => r.Madouutien == PriorityId).ToList();
	}

	public dynamic findByPriorityDynamic(int PriorityId, string username)
	{
		var list = findAllBySender(username);
		return list.Where(r => r.Madouutien == PriorityId).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();

	}

	public dynamic findByPriorityDynamicByAdmin(int PriorityId)
	{
		return db.YeuCaus.Where(r => r.Madouutien == PriorityId).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public dynamic findByPriorityDynamicBySupport(int PriorityId, string username)
	{
		var list = findAllBySupport(username);
		return list.Where(r => r.Madouutien == PriorityId).Select(r => new
		{
			Mayeucau = r.Mayeucau,
			Tieude = r.Tieude,
			Noidung = r.Noidung,
			Ngaygui = r.Ngaygui.ToString("yyyy/MM/dd"),
			Madouutien = r.Madouutien,
			ManvGui = r.ManvGui,
			ManvXuly = r.ManvXuly
		}).ToList();
	}

	public bool update(YeuCau yeucau)
	{
		try
		{
			db.Entry(yeucau).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return db.SaveChanges() > 0;
		}
		catch
		{
			return false;
		}

	}

}
