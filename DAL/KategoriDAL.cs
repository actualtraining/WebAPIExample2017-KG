using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class KategoriDAL : ICrud<Kategori>
    {
        public async Task Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"delete from Kategori where KategoriID=@KategoriID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@KategoriID", SqlDbType.Int,int.MaxValue).Value=id;
                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message + " " + sqlEx.Number);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public async Task<IEnumerable<Kategori>> GetAll()
        {
            List<Kategori> lstKategori = new List<Kategori>();
            using(SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"sp_GetAllKategori";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    if(dr.HasRows)
                    {
                        while (await dr.ReadAsync())
                        {
                            lstKategori.Add(new Kategori
                            {
                                KategoriID = Convert.ToInt32(dr["KategoriID"]),
                                NamaKategori = dr["NamaKategori"].ToString()
                            });
                        }
                    }
                    return lstKategori;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            
        }

        public async Task<Kategori> GetById(string id)
        {
            Kategori objKat = new Kategori();
            using(SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"select * from Kategori where KategoriID=@KategoriID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KategoriID", id);
                try
                {
                    await conn.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    if (dr.HasRows)
                    {
                        while (await dr.ReadAsync())
                        {
                            objKat.KategoriID = Convert.ToInt32(dr["KategoriID"]);
                            objKat.NamaKategori = dr["NamaKategori"].ToString();
                        }
                    }
                    return objKat;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message + " " +sqlEx.Number);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public async Task Insert(Kategori obj)
        {
            using(SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"sp_InserKategori";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NamaKategori", obj.NamaKategori);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message + " " + sqlEx.Number);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public async Task Update(Kategori obj)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnStr()))
            {
                string strSql = @"sp_UpdateKategori";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NamaKategori", obj.NamaKategori);
                cmd.Parameters.AddWithValue("@KategoriID", obj.KategoriID);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message + " " + sqlEx.Number);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
