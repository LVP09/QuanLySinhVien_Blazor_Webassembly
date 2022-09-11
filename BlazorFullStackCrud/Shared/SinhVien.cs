using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorFullStackCrud.Shared
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            Diems = new HashSet<Diem>();
        }

        public int MaSv { get; set; }
        [Required]
        public string AnhSv { get; set; } = null!;

        [Required]
        [StringLength(20, ErrorMessage = "Vui lòng nhập họ tên dưới 20 ký tự")]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s\W|_]+$", ErrorMessage = "Hãy nhập tên sinh viên đúng format ")]
        public string TenSv { get; set; } = null!;
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Hãy nhập Email đúng format ")]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(200, ErrorMessage = "Vui lòng nhập địa chỉ dưới 200 ký tự")]
        public string DiaChi { get; set; } = null!;
        [Required]
        public DateTime NgaySinh { get; set; }
       
        [Required]
        [StringLength(10, ErrorMessage = "Vui lòng nhập SDT đúng")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Hãy nhập tên sinh viên đúng format ")]

        
        public string SDT { get; set; }
        [Required]
        public int MaLop { get; set; }
       


        public virtual Lop? MaLopNavigation { get; set; } = null!;
        public virtual ICollection<Diem>? Diems { get; set; }
    }
}
