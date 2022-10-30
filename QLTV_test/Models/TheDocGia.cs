namespace QLTV_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheDocGia")]
    public partial class TheDocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheDocGia()
        {
            PhieuMuonSaches = new HashSet<PhieuMuonSach>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaThe { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public int? LoaiDocGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLapThe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }

        public int? SLSachDangMuon { get; set; }

        public bool? DaXoa { get; set; }

        public virtual LoaiDocGia LoaiDocGia1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuonSach> PhieuMuonSaches { get; set; }
    }
}
