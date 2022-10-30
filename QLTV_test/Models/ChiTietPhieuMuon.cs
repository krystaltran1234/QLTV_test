namespace QLTV_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuMuon")]
    public partial class ChiTietPhieuMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCTPM { get; set; }

        public int? MaPhieuMuon { get; set; }

        public int? STT { get; set; }

        public int? MaSach { get; set; }

        public int? MaTheLoai { get; set; }

        public bool? DaXoa { get; set; }

        public virtual PhieuMuonSach PhieuMuonSach { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TheLoaiSach TheLoaiSach { get; set; }
    }
}
