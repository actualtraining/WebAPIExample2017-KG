using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DAL;

namespace BL
{
    public class BarangBL
    {
        public async Task<IEnumerable<Barang>> GetAll()
        {
            BarangDAL barangDal = new BarangDAL();
            return await barangDal.GetAll();
        }

        public async Task<Barang> GetById(string id)
        {
            BarangDAL barangDal = new BarangDAL();
            try
            {
                return await barangDal.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Insert(Barang obj)
        {
            BarangDAL barangDal = new BarangDAL();
            try
            {
                await barangDal.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<viewBarangWithKategori>> GetAllBarangWithKategori()
        {
            BarangDAL barangDal = new BarangDAL();
            return await barangDal.GetAllBarangWithKategori();
        }

        public async Task<IEnumerable<Barang>> GetAllBarangKategoriMap()
        {
            BarangDAL barangDal = new BarangDAL();
            return await barangDal.GetAllBarangKategoriMap();
        }

        public async Task Update(Barang obj)
        {
            BarangDAL barangDal = new BarangDAL();
            try
            {
                await barangDal.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(string id)
        {
            BarangDAL barangDal = new BarangDAL();
            try
            {
                await barangDal.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
