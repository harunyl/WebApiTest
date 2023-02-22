using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTest.Models.Entity;

namespace WebApiTest.Controllers
{
 
    public class MetotController : ApiController
    {
        MetotDal metotdal = new MetotDal();

        //En çok kullanılan Http Status Kodları
        // 200 OK
        // 201 Created
        // 204 No Content
        // 400 Bad Request
        // 401 Unauthorized
        // 404 Not Found
        // 500 Internal Server Error




        //Orjinal hali
        //public IEnumerable<Tbl_Urunler> Get()
        //{
        //    return metotdal.Get();
        //}

        //Statüslü Hali Hata koduna göre işlem yaptırıcam
        //public HttpResponseMessage Get()
        //{
        //    var Metotlar = metotdal.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, Metotlar);
        //}

        //Yeni Kullanım Şekli Üsttekide geçerli az kod yazmak için altdakinide kullanabilirsin
        public IHttpActionResult Get()
        {
            var Metotlar = metotdal.Get();
            return Ok(Metotlar);
        }



        //Orjinali
        //public Tbl_Urunler Get(int id)
        //{
        //    return metotdal.GetbyId(id);
        //}


        //Olması gereken statüs kodlu
        //public HttpResponseMessage Get(int id)
        //{
        //    var Metotlar= metotdal.GetbyId(id);
        //    if (Metotlar==null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound,"Böyle bir kayıt bulunamadı...");
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, Metotlar);
        //}

        //Yeni Kullanım Şekli Üsttekide geçerli az kod yazmak için altdakinide kullanabilirsin
        public IHttpActionResult Get(int id)
        {
            var Metotlar = metotdal.GetbyId(id);
            if (Metotlar == null)
            {
                return NotFound();
            }
            return Ok(Metotlar);
        }


        //Ekleme işlemi Orjinali
        //public Tbl_Urunler Post(Tbl_Urunler p)
        //{
        //  return  metotdal.Create(p);
        //}

        //Statüslü
        //public HttpResponseMessage Post(Tbl_Urunler p)
        //{
        //    var Ekle= metotdal.Create(p);
        //    return Request.CreateResponse(HttpStatusCode.Created, Ekle);
        //}


        //Marka alanını zorunlu yapıp Modelstate uygalayıp hata kodunu döndürdüm
        //public HttpResponseMessage Post(Tbl_Urunler p)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var Ekle = metotdal.Create(p);
        //        return Request.CreateResponse(HttpStatusCode.Created, Ekle);
        //    }
        //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //}


        //Yeni Kullanım Şekli Üsttekide geçerli az kod yazmak için altdakinide kullanabilirsin
        public IHttpActionResult Post(Tbl_Urunler p)
        {
            if (ModelState.IsValid)
            {
                var Ekle = metotdal.Create(p);
                return CreatedAtRoute("DefaultApi", new { id = Ekle.UrunID }, Ekle);
            }
            return BadRequest(ModelState);
        }




        //Update işlemi
        //public Tbl_Urunler Put(int id, Tbl_Urunler p)
        //{
        //    return metotdal.Update(id, p);
        //}

        //public HttpResponseMessage Put(int id, Tbl_Urunler p)
        //{
        //    //id ye ait kayıt yoksa
        //    if (metotdal.KayitVarmi(id) == false)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı...");
        //    }
        //    //Model Doğrulanmadı ise
        //    else if (ModelState.IsValid==false)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, metotdal.Update(id, p));
        //    }

        //}


    

        public IHttpActionResult Put(int id, Tbl_Urunler p)
        {
            //id ye ait kayıt yoksa
            if (metotdal.KayitVarmi(id) == false)
            {
                return NotFound();
            }
            //Model Doğrulanmadı ise
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(metotdal.Update(id, p));
            }

        }



        //public void Delete(int id)
        //{
        //    metotdal.Delete(id);
        //}



        //public HttpResponseMessage Delete(int id)
        //{
        //    if (metotdal.KayitVarmi(id)==false)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı...");
        //    }
        //    else
        //    {
        //        metotdal.Delete(id);
        //        return Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //}


        //Yeni Kullanım Şekli Üsttekide geçerli az kod yazmak için altdakinide kullanabilirsin
        public IHttpActionResult Delete(int id)
        {
            if (metotdal.KayitVarmi(id) == false)
            {
                return NotFound();
            }
            else
            {
                metotdal.Delete(id);
                return Ok();
            }
        }


    }
}
