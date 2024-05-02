using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Inserisci il nome del tuo programma degli eventi: ");
                string titoloProgramma = Console.ReadLine();
                if (string.IsNullOrEmpty(titoloProgramma))
                    throw new Exception("Il nome del programma non puó essere vuoto");

                ProgrammaEventi newProgramma = new ProgrammaEventi(titoloProgramma);

                Console.Write("Indica il numero di eventi da inserire all'interno del programma: ");
                int numEventi = int.Parse(Console.ReadLine());
                if (numEventi < 0)
                    throw new Exception("Non puoi inserire un numero di eventi negativo");

                for (int i = 1; i <= numEventi; i++)
                {
                    try
                    {
                        Console.Write($"Inserisci il nome del {i}° evento: ");
                        string titolo = Console.ReadLine();
                        if (string.IsNullOrEmpty(titolo))
                            throw new Exception("Il Titolo non puó essere vuoto");

                        Console.Write("Inserisci la data dell'evento nel seguente formato gg/mm/yyyy: ");
                        string inputData = Console.ReadLine();
                        if (string.IsNullOrEmpty(titolo))
                            throw new Exception("La data deve contenere i valori nel formato specificato");

                        DateTime data = DateTime.ParseExact(inputData, "dd/MM/yyyy", null);
                        if (data < DateTime.Now)
                            throw new Exception("La data del nuovo evento deve trovarsi nel futuro");

                        Console.Write("Inserisci il numero di posti totali: ");
                        int capienzaMassima = int.Parse(Console.ReadLine());
                        if (capienzaMassima < 0)
                            throw new Exception("I posti massimi devono avere un numero positivo");

                        Console.WriteLine("");

                        Evento newEvento = new Evento(titolo, data, capienzaMassima);
                        newProgramma.AggiungiEvento(newEvento);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Errore: {e.Message}. Riprova.");
                        i--;
                    }
                }
                Console.WriteLine($"Totale degli eventi nel programma: {newProgramma.NumeroEventi()}");
                Console.WriteLine($"Il tuo programma eventi:\n{newProgramma.MostraProgrammaEventi()}");

                Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
                DateTime userData = DateTime.Parse(Console.ReadLine());

                List<Evento> eventiNellaData = newProgramma.EventiPerData(userData);
                Console.WriteLine($"{ProgrammaEventi.StampaListaEvento(eventiNellaData)}");

                newProgramma.SvuotaListaEventi();

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }


           
            

            








            ///////////////MILESTONE 2/////////////// 
            /*Console.Write("Quanti posti desideri prenotare?: ");
            int postiPrenotati = int.Parse(Console.ReadLine());
            newEvento.PrenotaPosti(postiPrenotati);
            Console.WriteLine("");

            newEvento.StampaPosti();
            Console.WriteLine("");


            Console.Write($"Vuoi disdire dei posti (si/no)? ");
            string risposta = Console.ReadLine();
            while (risposta == "si")
            {
                Console.Write("Indica il numero di posti da disdire: ");
                int postiDisdetti = int.Parse(Console.ReadLine());
                newEvento.DisdiciPosti(postiDisdetti);
                newEvento.StampaPosti();

                Console.Write($"Vuoi disdire dei posti (si/no)? ");
                risposta = Console.ReadLine();

            }
            if (risposta == "no")
            {
                Console.WriteLine("Ok va bene !");
            }*/


        }

    }
}
