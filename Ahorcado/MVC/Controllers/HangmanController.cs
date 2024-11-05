using Ahorcado;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public static AhorcadoJuego Juego { get; set; }

        // GET: Hangman
        public ActionResult Index()
        {
            return View(new Hangman());
        }

        [HttpPost]
        public JsonResult InsertWordToGuess(Hangman model)
        {
            Juego = new AhorcadoJuego(model.WordToGuess);
            model.ChancesLeft = Juego.ChancesRestantes;
            return Json(model);
        }

        [HttpPost]
        public JsonResult TryLetter(Hangman model)
        {
            Juego.insertarLetra(Convert.ToChar(model.LetterTyped));
            model.Win = Juego.ValidarPalabra();
            model.ChancesLeft = Juego.ChancesRestantes;
            model.WrongLetters = string.Empty;
            foreach (var wLetter in Juego.LetrasErradas)
            {
                model.WrongLetters += wLetter + ",";
            }
            model.GuessingWord = string.Empty;
            foreach (var rLetter in Juego.PalabraIngresada)
            {
                model.GuessingWord += rLetter + " ";
            }
            model.LetterTyped = string.Empty;
            return Json(model);
        }
    }
}
