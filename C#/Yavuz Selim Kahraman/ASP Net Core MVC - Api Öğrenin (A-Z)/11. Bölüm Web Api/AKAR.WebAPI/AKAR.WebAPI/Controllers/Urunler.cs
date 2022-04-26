using AKAR.WebAPI.Data;
using AKAR.WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace AKAR.WebAPI.Controllers
{

    [ApiController]
    [Route("{controller}")]
    public class Urunler:ControllerBase
    {
         
        [HttpGet]
        public IActionResult GetAll()
        {
            using (var context = new MyDbContext())
            {
                var list = context.Products.ToList();
                if (list.Count == 0)
                {
                    return NotFound("Sistemde Yüklü Herhangi Bir Ürün Bulunmamaktadır");
                }
                else
                {
                    return Ok(list);
                }
            }

            return BadRequest("Veritabanına Erişim Sağlanamadı");
        }
         
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id )
        {
            using (var context = new MyDbContext())
            {
                var list = context.Products.Where(x=> x.Id == id).ToList();
                if (list.Count == 0)
                {
                    return NotFound("Böyle Bir ürün sistemde bulunmamaktadır . ");
                }
                else
                {
                    return Ok(list);
                }
            }
            return BadRequest("Veritabanına Erişim Sağlanamadı");
        }

        [HttpPost]
        public IActionResult Kaydet(Product p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                    return Created(String.Empty , p);

                    // 201 döner
                    // string empty yapmamızın temelindeki yatan sebep ise normal şartlar altında kayıt gerçekleştikten sonra action yapıp başka bir url e gitmesini istiyorsak bunu yapmamız gerkemetkedir.
                }
            }
            catch (ArgumentException EX)
            {
                return BadRequest(" Bir Hata İle Karşılaşıldı " + EX.Message);
            }

        }

         
        [HttpPut("{id}")]

        public IActionResult Guncelle(Product p )
        {
            using (var context = new MyDbContext())
            {
                var a = context.Products.Find(p.Id);
                if (a == null)
                {
                    return NotFound(a);
                }

                else
                {
                    context.Entry(a).CurrentValues.SetValues(p);
                    context.SaveChanges();
                    return NoContent();
                }

            }
        }


        [HttpDelete("{id}")]
        public IActionResult Sil(int id)
        {
            using (var context = new MyDbContext())
            {
                var eskiveri = context.Products.Find(id);
                if (eskiveri!= null)
                {
                    context.Products.Remove(eskiveri);
                    context.SaveChanges();
                }
                return NoContent();

            }

        }

        [HttpPost("{file}")]

        public IActionResult Dosyayukleme( IFormFile fromfile)
        {
            var NewName = Guid.NewGuid() + "."+ Path.GetExtension(fromfile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",NewName);
            var stream = new FileStream(path,FileMode.Create);
            fromfile.CopyTo(stream);
            return Created(String.Empty,fromfile);
        }


    }
}
 