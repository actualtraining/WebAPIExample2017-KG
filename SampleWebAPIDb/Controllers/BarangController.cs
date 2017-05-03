using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BO;
using BL;
using System.Threading.Tasks;

namespace SampleWebAPIDb.Controllers
{
    public class BarangController : ApiController
    {
        // GET: api/Barang
        public async Task<IEnumerable<Barang>> Get()
        {
            BarangBL barangBL = new BarangBL();
            return await barangBL.GetAll();
        }

        [Route("api/BarangWithKategori")]
        [HttpGet]
        public async Task<IEnumerable<viewBarangWithKategori>> GetAllBarangWithKategori()
        {
            BarangBL barangBL = new BarangBL();
            return await barangBL.GetAllBarangWithKategori();
        }

        [Route("api/BarangWithKategoriMap")]
        [HttpGet]
        public async Task<IEnumerable<Barang>> GetAllBarangKategoriMap()
        {
            BarangBL barangBL = new BarangBL();
            return await barangBL.GetAllBarangKategoriMap();
        }

        // GET: api/Barang/5
        public async Task<Barang> Get(string id)
        {
            BarangBL barangBL = new BarangBL();
            try
            {
                return await barangBL.GetById(id);
            }
            catch (Exception ex)
            {
                return new Barang() { };
            }
        }

        // POST: api/Barang
        public async Task<IHttpActionResult> Post(Barang obj)
        {
            BarangBL barangBL = new BarangBL();
            try
            {
                await barangBL.Insert(obj);
                return Ok("barang berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Barang/5
        public async Task<IHttpActionResult> Put(Barang obj)
        {
            BarangBL barangBL = new BarangBL();
            try
            {
                await barangBL.Update(obj);
                return Ok("barang berhasil diedit");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Barang/5
        public async Task<IHttpActionResult> Delete(string id)
        {
            BarangBL barangBL = new BarangBL();
            try
            {
                await barangBL.Delete(id);
                return Ok("barang berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
