using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoGame
{
    public class AhorcadoJuego
    {
        public string PalabraSecreta { get; set; }
        public List<char> LetrasIntentadas { get; set; }
        public List<char> LetrasDePalabra { get; set; }
        public int VidasRestantes { get; set; }
        public List<char> PalabraIngresada { get; set; }


        public AhorcadoJuego()
        {
            PalabraSecreta = "hola";
            LetrasIntentadas = new List<char>();
            VidasRestantes = 6;
        }

        public void IngresarPalabraSecreta(string palabra)
        {
            PalabraSecreta = palabra;
        }

        public bool AdivinarLetra(char l)
        {
            if (!char.IsLetter(l))
            {
                return false;
            }
            l = char.ToLower(l);

            LetrasIntentadas.Add(l);

            if (!PalabraSecreta.ToLower().Contains(l))
            {
                --VidasRestantes;
                return false;
            }

            return true;
        }

        public bool AdivinarPalabra(string palabra)
        {
            if (string.Equals(palabra.ToLower(), PalabraSecreta.ToLower()))
            {
                return true;
            }

            return false;
        }

        public bool JuegoGanado()
        {
            return PalabraSecreta.ToLower().All(letra => LetrasIntentadas.Contains(letra));
        }

        public bool JuegoPerdido()
        {
            return VidasRestantes <= 0;
        }
    }
}
