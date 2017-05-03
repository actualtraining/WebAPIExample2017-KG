using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class viewBarangWithKategori
    {
        public string KodeBarang { get; set; }
        public int KategoriID { get; set; }
        public string NamaKategori { get; set; }
        public string NamaBarang { get; set; }
        public decimal? HargaBeli { get; set; }
        public decimal? HargaJual { get; set; }
        public int? Stok { get; set; }
    }
}
