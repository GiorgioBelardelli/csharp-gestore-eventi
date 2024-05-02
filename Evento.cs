using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        //ATTRIBUTI
        private string titolo;
        private DateTime data;
        private int capienzaMassima;
        private int postiPrenotati;

        //PROPRIETA'
        public string Titolo
        {
            get { return titolo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Il Titolo non puó essere vuoto");
                titolo = value;
            }
        }
        public DateTime Data
        {
            get { return data; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("La data del nuovo evento deve trovarsi nel futuro");
                data = value;
            }
        }
        public int CapienzaMassima
        {
            get { return capienzaMassima; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("I posti massimi devono avere un numero positivo");
                capienzaMassima = value;
            }
        }
        public int PostiPrenotati
        {
            get { return postiPrenotati; }
            private set { postiPrenotati = value; }
        }

        //COSTRUTTORE
        public Evento(string Titolo, DateTime Data, int CapienzaMassima)
        {
            titolo = Titolo;
            data = Data;
            capienzaMassima = CapienzaMassima;
            postiPrenotati = 0;
        }

        //METODI
        public void PrenotaPosti(int numPosti) 
        {
            if (numPosti < 0)
                throw new ArgumentException("Il numero dei posti deve avere un valore positivo");
            if (data < DateTime.Now)
                throw new InvalidOperationException("Impossibile prenotare posti per un evento passato");
            if (numPosti + postiPrenotati > CapienzaMassima)
                throw new InvalidOperationException("I posti inseriti eccedono la capienza massima dell'evento");

            postiPrenotati += numPosti;
        }

        public void DisdiciPosti(int numPosti)
        {
            if (numPosti < 0)
                throw new ArgumentException("Il numero dei posti deve avere un valore positivo");
            if (data < DateTime.Now)
                throw new InvalidOperationException("Impossibile disdire prenotazioni per un evento passato");
            if (numPosti - postiPrenotati < 0)
                throw new InvalidOperationException("Non ci sono abbastanza prenotati da disdire");
            postiPrenotati -= numPosti;
        }

        public override string ToString()
        {
            string dataFormattata = data.ToString("dd/MM/yyyy");
            return $"{dataFormattata} - {titolo}";
        }

    }
}
