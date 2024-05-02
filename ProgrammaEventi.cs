using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        //ATTRIBUTI
        private string titolo;
        private List<Evento> eventi;

        //COSTRUTTORE
        public ProgrammaEventi(string Titolo)
        {
            titolo = Titolo;
            eventi = new List<Evento>();
        }

        //METODI
        public void AggiungiEvento(Evento Evento)
        {
            eventi.Add(Evento);
        }

        public List<Evento> EventiPerData(DateTime data)
        {
            List<Evento> eventiPerData = new List<Evento>();
            foreach (Evento evento in eventi)
            {
                if (evento.Data == data)
                {
                    eventiPerData.Add(evento);
                }
            }

            return eventiPerData;
        }

        public static string StampaListaEvento(List<Evento> eventi)
        {
            string lista = "";
            foreach (Evento evento in eventi)
            {
                lista += $"{evento.Data} - {evento.Titolo} \n";
            }
            return lista;
        }

        public int NumeroEventi()
        {
            return eventi.Count;
        }

        public void SvuotaListaEventi()
        {
            eventi.Clear();
        }

        public string MostraProgrammaEventi()
        {
            string listaEventi = $"{titolo} \n";
            foreach (Evento evento in eventi) 
            {
                listaEventi += $"{evento.Data} - {evento.Titolo} \n"; 
            }
            return listaEventi;
        }
    }
}
