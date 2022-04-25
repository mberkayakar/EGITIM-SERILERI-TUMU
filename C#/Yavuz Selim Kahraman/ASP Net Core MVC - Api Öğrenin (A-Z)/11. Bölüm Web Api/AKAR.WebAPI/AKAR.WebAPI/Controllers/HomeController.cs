using Microsoft.AspNetCore.Mvc;
using System;

namespace AKAR.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        public class KARŞILAMA
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
        }


        [HttpGet]
        public IActionResult karsilama_ekrani_fonksiyonu()
        {
            KARŞILAMA p = new KARŞILAMA
            {
                Name = "AKAR YAZILIM HİZMETLERİ",
                Description = "AKAR İLK WEP APİ YAZILIMI - REST SERVİS 2022 ",
                Date = DateTime.Now
            };

            return Ok(p);

        }



    }
}
