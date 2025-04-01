using Microsoft.AspNetCore.Mvc;
using WebMangasAspCore.Models.MesExceptions;
using WebMangasAspCore.Models.Dao;
using WebMangasAspCore.Models.Metier;

using WebMangasAspCore.Models.Persistance;

namespace WebMangasAspCore.Controllers
{
    public class MangaController : Controller
    {
        public IActionResult Index()
        {
            System.Data.DataTable mesMangas = null;

            try
            {
                mesMangas = ServiceManga.GetTousLesMangas();
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des mangas : " + e.Message);
            }

            return View(mesMangas);
        }

        public IActionResult Modifier(string id)
        {
            Manga unManga = null;
            try
            {
                unManga = ServiceManga.GetunManga(id);
                return View(unManga);
            }
            catch (MonException e)
            {
                return NotFound();
            }
        }



        [HttpPost]
        public IActionResult Modifier(Manga unM)
        {
            try
            {
                ServiceManga.UpdateManga(unM);
                return View();
            }
            catch (MonException e)
            {
                return NotFound();
            }
        }


    }
}
