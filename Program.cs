namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il nome dell'evento: ");
            string titolo = Console.ReadLine();

            Console.Write("Inserisci la data dell'evento nel seguente formato gg/mm/yyyy: ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.Write("Inserisci il numero di posti totali: ");
            int capienzaMassima = int.Parse(Console.ReadLine());


            Evento newEvento = new Evento(titolo, data, capienzaMassima);

            Console.Write("Quanti posti desideri prenotare?: ");
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
            }


        }

    }
}
