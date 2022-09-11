using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStackCrud.Shared
{
    public partial class Nghanh
    {
        public Nghanh()
        {
            Lops = new HashSet<Lop>();
        }

        public int MaNghanh { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Vui lòng nhập tên dưới 50 ký tự")]
   
        public string TenNghanh { get; set; } = null!;

        public virtual ICollection<Lop>? Lops { get; set; }
    }
}
