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
    public class KategoriController : ApiController
    {
        // GET: api/Kategori
        public async Task<IEnumerable<Kategori>> Get()
        {
            KategoriBL kategoriBL = new KategoriBL();
            return await kategoriBL.GetAll();
        }

        // GET: api/Kategori/5
        public async Task<Kategori> Get(string id)
        {
            KategoriBL kategoriBL = new KategoriBL();
            return await kategoriBL.GetById(id);
        }

        // POST: api/Kategori
        public async Task<IHttpActionResult> Post(Kategori obj)
        {
            KategoriBL kategoriBL = new KategoriBL();
            try
            {
                await kategoriBL.Insert(obj);
                return Ok("insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public async Task<IHttpActionResult> Put(Kategori obj)
        {
            KategoriBL kategoriBL = new KategoriBL();
            try
            {
                await kategoriBL.Update(obj);
                return Ok("update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Kategori/5
        public async Task<IHttpActionResult> Delete(string id)
        {
            KategoriBL kategoriBL = new KategoriBL();
            try
            {
                await kategoriBL.Delete(id);
                return Ok("delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
