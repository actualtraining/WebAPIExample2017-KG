using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DAL;

namespace BL
{
    public class KategoriBL
    {
        public async Task<IEnumerable<Kategori>> GetAll()
        {
            KategoriDAL kategoriDal = new KategoriDAL();
            try
            {
                return await kategoriDal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Kategori> GetById(string id)
        {
            if (id == string.Empty)
                throw new Exception("id harus diisi !");

            KategoriDAL kategoriDal = new KategoriDAL();
            try
            {
                return await kategoriDal.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Insert(Kategori obj)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            try
            {
                await kategoriDAL.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Kategori obj)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            try
            {
                await kategoriDAL.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(string id)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            try
            {
                await kategoriDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
