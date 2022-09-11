using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStackCrud.Shared
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            Diems = new HashSet<Diem>();
        }

        public int MaMh { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Vui lòng nhập tên môn học dưới 50 ký tự")]
        public string TenMh { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = "Vui lòng nhập dưới 20 ký tự")]
        public string Ki { get; set; } = null!;
          [Required]
     
        [RegularExpression("^[0-9]+$", ErrorMessage ="Vui lòng nhập đúng format")]
        public int SoTinChi { get; set; }

        public virtual ICollection<Diem>? Diems { get; set; }
    }
}
