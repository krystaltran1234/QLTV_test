namespace QLTV_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNguoiDung { get; set; }

        [StringLength(30)]
        public string TenNguoiDung { get; set; }

        public int? LoaiNguoiDung { get; set; }

        [StringLength(10)]
        public string TenDangNhap { get; set; }

        [StringLength(30)]
        public string MatKhau { get; set; }

        public bool? DaXoa { get; set; }

        public virtual LoaiNguoiDung LoaiNguoiDung1 { get; set; }
    }
}
