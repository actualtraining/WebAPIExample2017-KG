using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using System.Data.SqlClient;
using Dapper;

namespace DAL
{
    public class BarangDAL : ICrud<Barang>
    {
        public async Task Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = "delete from Barang where KodeBarang=@KodeBarang";
                var param = new { KodeBarang = id };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message + " " + sqlEx.Number);
                }
            }
        }

        public async Task<IEnumerable<Barang>> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                //string strSql = @"select * from Barang order by NamaBarang";
                string strSql = @"sp_GetAllBarang";
                var results = await conn.QueryAsync<Barang>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task<IEnumerable<Barang>> GetAllBarangKategoriMap()
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"select * from Barang left join Kategori on Barang.KategoriID=Kategori.KategoriID";
                var results = await conn.QueryAsync<Barang, Kategori, Barang>(strSql, (b, k) =>
                {
                    b.Kategori = k;
                    return b;
                }, splitOn: "KategoriID");

                return results;
            }
        }

        public async  Task<IEnumerable<viewBarangWithKategori>> GetAllBarangWithKategori()
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"select * from viewBarangWithKategori";
                var results = await conn.QueryAsync<viewBarangWithKategori>(strSql);
                return results;
            }
        }

        public async Task<Barang> GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"sp_GetBarangByKode";
                var param = new { KodeBarang = id };
                var result = await conn.QuerySingleAsync<Barang>(strSql, param,
                    commandType: System.Data.CommandType.StoredProcedure);
                if (result != null)
                    return result;
                else
                    throw new Exception("Barang not found !");
            }
        }

        public async Task Insert(Barang obj)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = "sp_InsertBarang";
                try
                {
                    var param = new
                    {
                        KodeBarang = obj.KodeBarang,
                        KategoriID = obj.KategoriID,
                        NamaBarang = obj.NamaBarang,
                        HargaBeli = obj.HargaBeli,
                        HargaJual = obj.HargaJual,
                        Stok = obj.Stok
                    };
                    await conn.ExecuteAsync(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message + " " + sqlEx.Number);
                }
            }
        }

        public async Task Update(Barang obj)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"update Barang set NamaBarang=@NamaBarang,
                                  KategoriID=@KategoriID,
                                  HargaBeli=@HargaBeli,
                                  HargaJual=@HargaJual,
                                  Stok=@Stok 
                                  where KodeBarang=@KodeBarang";
                try
                {
                    var param = new
                    {
                        KodeBarang = obj.KodeBarang,
                        KategoriID = obj.KategoriID,
                        NamaBarang = obj.NamaBarang,
                        HargaBeli = obj.HargaBeli,
                        HargaJual = obj.HargaJual,
                        Stok = obj.Stok
                    };
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message + " " + sqlEx.Number);
                }
            }
        }
    }
}
