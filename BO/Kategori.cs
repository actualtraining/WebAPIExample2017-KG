using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Kategori
    {
        public int KategoriID { get; set; }

        [Required(ErrorMessage ="Nama Kategori harus diisi !")]
        [MaxLength(50)]
        public string NamaKategori { get; set; }

    }
}
