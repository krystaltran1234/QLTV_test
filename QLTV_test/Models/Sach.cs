namespace QLTV_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietPhieuMuons = new HashSet<ChiTietPhieuMuon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [StringLength(100)]
        public string TenSach { get; set; }

        public int? TheLoai { get; set; }

        [StringLength(50)]
        public string TacGia { get; set; }

        public int? NamXB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public int? TinhTrang { get; set; }

        public bool? DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }

        public virtual TheLoaiSach TheLoaiSach { get; set; }

        public virtual TinhTrangSach TinhTrangSach { get; set; }
    }
}
