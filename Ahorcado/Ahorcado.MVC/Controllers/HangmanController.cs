using Ahorcado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AhorcadoGame;

namespace Ahorcado.MVC.Controllers
{
    public class HangmanController : Controller
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
            Juego = new AhorcadoJuego();
            Juego.IngresarPalabraSecreta(model.WordToGuess);

            model.ChancesLeft = Juego.VidasRestantes;
            model.GuessingWord = string.Join(" ", Juego.PalabraSecreta.Select(l => "_"));
            model.WrongLetters = string.Empty;
            model.Win = false;

            return Json(model);
        }

        [HttpPost]
        public JsonResult TryLetter(Hangman model)
        {
            Juego.AdivinarLetra(Convert.ToChar(model.LetterTyped));
            model.Win = Juego.JuegoGanado();
            model.ChancesLeft = Juego.VidasRestantes;
            model.GuessingWord = string.Join(" ", Juego.PalabraSecreta.Select(letra =>
            Juego.LetrasIntentadas.Contains(char.ToLower(letra)) ? letra.ToString() : "_"));
            model.WrongLetters = string.Join(",", Juego.LetrasIntentadas.Where(l => !Juego.PalabraSecreta.Contains(l.ToString())));
            model.LetterTyped = string.Empty;
            return Json(model);
        }
    }
}