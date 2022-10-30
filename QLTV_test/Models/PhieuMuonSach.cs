namespace QLTV_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuonSach")]
    public partial class PhieuMuonSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuonSach()
        {
            ChiTietPhieuMuons = new HashSet<ChiTietPhieuMuon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuMuon { get; set; }

        public int? MaTheDocGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMuon { get; set; }

        public int? MaChiTietPhieuMuon { get; set; }

        public bool? DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }

        public virtual TheDocGia TheDocGia { get; set; }
    }
}
