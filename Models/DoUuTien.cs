using System;
using System.Collections.Generic;

namespace AspdotNetCoreMVCExam.Models;

public partial class DoUuTien
{
    public int Madouutien { get; set; }

    public string? TendouuTien { get; set; }

    public virtual ICollection<YeuCau> YeuCaus { get; set; } = new List<YeuCau>();
}
