using AKAR.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AKAR.WebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]


    public class ProductsController:ControllerBase
    {

        #region SeedDAta
            static List<Product> urunler = new List<Product>
            {
                new Product { Id = 1, Name = "Samsung Galaxy S20 FE " , Description = " Mavi / 256 " ,  ImageUrl =" asdasd " },
                new Product { Id = 2, Name = "Monster Abra A5 V12.1 " , Description = " 512 SSD NVME " ,  ImageUrl =" asdasd " },
                new Product { Id = 3, Name = "Samsung Galaxy S9 FE " , Description = " Mavi / 256 " ,  ImageUrl =" asdasd " },
                new Product { Id = 4, Name = "Samsung Galaxy S10 FE " , Description = " Mavi / 256 " ,  ImageUrl =" asdasd " },
                new Product { Id = 5, Name = "Iphone 6s " , Description = " Black / 16 " ,  ImageUrl =" asdasd " },

            };

        #endregion

         
        // http://localhost:19037/Product

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(urunler);
        }


        // http://localhost:19037/Product/1
        // http://localhost:19037/Product/2
        // sonuncu id olarak düşünülecektir. 

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = urunler.FirstOrDefault(x=> x.Id == id);
            if (a!= null)
            {
                return Ok(a);
            }

            return NotFound();
        }
    }
}
