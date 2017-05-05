using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Barang
    {
        [Required(ErrorMessage ="Kode Barang harus diisi !")]
        [MaxLength(5,ErrorMessage ="Kode Barang harus 5 karakter")]
        [MinLength(5,ErrorMessage = "Kode Barang harus 5 karakter")]
        [Display(Name = "Kode Barang")]
        public string KodeBarang { get; set; }

        public int KategoriID { get; set; }

        [Display(Name = "Nama Barang")]
        [Required(ErrorMessage ="Nama Barang harus diisi !")]
        [MaxLength(50)]
        public string NamaBarang { get; set; }

        [DataType(DataType.Currency,ErrorMessage = "Harus tipe decimal")]
        [Display(Name = "Harga Beli")]
        public decimal? HargaBeli { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Harus tipe decimal")]
        [Display(Name = "Harga Jual")]
        public decimal? HargaJual { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Harus tipe decimal")]
        [Range(0,int.MaxValue,ErrorMessage = "Diluar range nilai yang ditentukan")]
        public int? Stok { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
