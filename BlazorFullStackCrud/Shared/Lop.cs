using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStackCrud.Shared
{
    public partial class Lop
    {
        public Lop()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public int MaLop { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Vui lòng nhập tên dưới 50 ký tự")]
      
        public string TenLop { get; set; } = null!;
        [Required]
        public int MaNghanh { get; set; }

        public virtual Nghanh? MaNghanhNavigation { get; set; } = null!;
        public virtual ICollection<SinhVien>? SinhViens { get; set; }
    }
}
