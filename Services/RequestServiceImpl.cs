using AspdotNetCoreMVCExam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
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

	public dynamic find(string sFrom, string sTo, int PriorityId, string username)
	{
		var list = findAllBySender(username);
		DateTime From, To;
		if (PriorityId == -1)
		{
			
			if (string.IsNullOrEmpty(sFrom) && string.IsNullOrEmpty(sTo))
			{
				//return new JsonResult("find all");
				return findAllBySenderDynamic(username);
			}
			else if (!(string.IsNullOrEmpty(sFrom) || string.IsNullOrEmpty(sTo)))
			{
				//return new JsonResult("tim theo from to");
				From = DateTime.ParseExact(sFrom, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				To = DateTime.ParseExact(sTo, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				return findByDateDynamic(From, To, username);
			}
			else
			{
				//return new JsonResult("error");
				return "400";
			}
		}
		else
		{
			
			if (string.IsNullOrEmpty(sFrom) && string.IsNullOrEmpty(sTo))
			{
				//return new JsonResult("tim theo pri");
				return findByPriorityDynamic(PriorityId, username);
			}
			else if (string.IsNullOrEmpty(sFrom) || string.IsNullOrEmpty(sTo))
			{
				//return new JsonResult("error");
				return "400";
			}
			else
			{
				From = DateTime.ParseExact(sFrom, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				To = DateTime.ParseExact(sTo, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				//return new JsonResult("tim theo ca 3");
				return findByDateAndPriorityDynamic(From, To, PriorityId, username);
			}
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

	public dynamic findByAdmin(string From,	string To, int PriorityId)
	{
		var list = findAllByAdmin();
		DateTime dFrom, dTo;
		if (PriorityId == -1)
		{
			if (string.IsNullOrEmpty(From) && string.IsNullOrEmpty(To))
			{
				//return new JsonResult("find all");
				return findAllDynamicByAdmin();
			}
			else if (!(string.IsNullOrEmpty(From) || string.IsNullOrEmpty(To)))
			{
				dFrom = DateTime.ParseExact(From, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				dTo = DateTime.ParseExact(To, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				//return new JsonResult("tim theo from to");
				return findByDateDynamicByAdmin(dFrom, dTo);
			}
			else
			{
				//return new JsonResult("error");
				return "400";
			}
		}
		else
		{
			if (string.IsNullOrEmpty(From) && string.IsNullOrEmpty(To))
			{
				//return new JsonResult("tim theo pri");
				return findByPriorityDynamicByAdmin(PriorityId);
			}
			else if (string.IsNullOrEmpty(From) || string.IsNullOrEmpty(To))
			{
				//return new JsonResult("error");
				return "400";
			}
			else
			{
				dFrom = DateTime.ParseExact(From, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				dTo = DateTime.ParseExact(To, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				//return new JsonResult("tim theo ca 3");
				return findByDateAndPriorityDynamicByAdmin(dFrom, dTo, PriorityId);
			}
		}
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

	public dynamic findBySupport(string sFrom, string sTo, int PriorityId, string username)
	{
		DateTime From, To;
		if (PriorityId == -1)
		{

			if (string.IsNullOrEmpty(sFrom) && string.IsNullOrEmpty(sTo))
			{
				//return new JsonResult("find all");
				return findAllDynamicBySupport(username);
			}
			else if (!(string.IsNullOrEmpty(sFrom) || string.IsNullOrEmpty(sTo)))
			{
				//return new JsonResult("tim theo from to");
				From = DateTime.ParseExact(sFrom, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				To = DateTime.ParseExact(sTo, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				return findByDateDynamicBySupport(From, To, username);
			}
			else
			{
				//return new JsonResult("error");
				return "400";
			}
		}
		else
		{

			if (string.IsNullOrEmpty(sFrom) && string.IsNullOrEmpty(sTo))
			{
				//return new JsonResult("tim theo pri");
				return findByPriorityDynamicBySupport(PriorityId, username);
			}
			else if (string.IsNullOrEmpty(sFrom) || string.IsNullOrEmpty(sTo))
			{
				//return new JsonResult("error");
				return "400";
			}
			else
			{
				From = DateTime.ParseExact(sFrom, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				To = DateTime.ParseExact(sTo, "yyyy/MM/dd", CultureInfo.InvariantCulture);
				//return new JsonResult("tim theo ca 3");
				return findByDateAndPriorityDynamicBySupport(From, To, PriorityId, username);
			}
		}
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
