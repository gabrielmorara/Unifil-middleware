﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaRodaJequitiServer.Services
{
    public static class PalavrasServices
    {
        public static List<String> listaPalavras = new List<String>();
        public static List<String> SorteiaListaPalavras()
        {
            //listaPalavras.Add("Amarelo");
            //listaPalavras.Add("Amiga");
            //listaPalavras.Add("Amor");
            //listaPalavras.Add("Branco");
            //listaPalavras.Add("Cama");
            //listaPalavras.Add("Caneca");
            //listaPalavras.Add("Celular");
            //listaPalavras.Add("Clube");
            //listaPalavras.Add("Copo");
            //listaPalavras.Add("Doce");
            //listaPalavras.Add("Elefante");
            //listaPalavras.Add("Parque");
            //listaPalavras.Add("Passarinho");
            //listaPalavras.Add("Peixe");
            //listaPalavras.Add("Pijama");
            //listaPalavras.Add("Rato");
            //listaPalavras.Add("Umbigo");
            listaPalavras.Add("DADO");
            listaPalavras.Add("UVA");
            listaPalavras.Add("Elefante");
            var list = new List<String>();
            var random = new Random();
            for (int i = 0; i < 3; i++)
            {
                //int index = random.Next(listaPalavras.Count);
                list.Add(listaPalavras[i].ToUpper());
            }
            return list;
        }
    }
}
