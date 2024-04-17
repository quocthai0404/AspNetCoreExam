using System;
using System.Collections.Generic;

namespace AspdotNetCoreMVCExam.Models;

public partial class YeuCau
{
    public int Mayeucau { get; set; }

    public string? Tieude { get; set; }

    public string? Noidung { get; set; }

    public DateTime? Ngaygui { get; set; }

    public int? Madouutien { get; set; }

    public string? ManvGui { get; set; }

    public string? ManvXuly { get; set; }

    public virtual DoUuTien? MadouutienNavigation { get; set; }

    public virtual NhanVien? ManvGuiNavigation { get; set; }

    public virtual NhanVien? ManvXulyNavigation { get; set; }
}
