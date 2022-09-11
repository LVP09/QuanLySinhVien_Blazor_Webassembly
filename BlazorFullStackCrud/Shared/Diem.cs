using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStackCrud.Shared
{
    public partial class Diem
    {
        public int MaDiem { get; set; }
        [Required]
        public int MonHocMaMh { get; set; }
        public int SinhViensMaSv { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Vui lòng nhập đúng fomart")]
        public string DiemThi { get; set; } = null!;

        public virtual MonHoc? MonHocMaMhNavigation { get; set; } = null!;
        public virtual SinhVien? SinhViensMaSvNavigation { get; set; } = null!;
    }
}
