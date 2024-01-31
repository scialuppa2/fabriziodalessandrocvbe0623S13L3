    using System;

namespace esercizioS13L3
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++++ESERCIZIO 1 CONTO CORRENTE++++");

            ContoCorrente mioConto = new ContoCorrente();

            mioConto.ApriConto(1500);
            mioConto.Versamento(500);  
            mioConto.Prelievo(1000); 
            mioConto.ControlloSaldo();  
            Console.ReadLine();

            Console.WriteLine("++++ESERCIZIO 2 CON ARRAY NOMI++++");

            Console.WriteLine("Quanti nomi vuoi inserire (numero):");
            int numeroNomi = int.Parse(Console.ReadLine());
            string[] nomi = new string[numeroNomi];

            for (int i = 0; i < nomi.Length; i++)
            {
                Console.Write("Inserisci il nome #" + (i + 1) + ": ");
                nomi[i] = Console.ReadLine();
            }
            Console.WriteLine("Qual'è il nome che vuoi verificare?:");
            string nome = Console.ReadLine();

            bool presente = false;
            for (int i = 0; i < nomi.Length; i++)
            {
                if (nome == nomi[i])
                {
                    presente = true;
                    break;
                }
            }
            if (presente)
            {
                Console.WriteLine($"Il nome {nome} è presente nella lista");
            }
            else
            {
                Console.WriteLine("Il nome non è presente in lista");
            }
            Console.ReadLine();

            Console.WriteLine("++++ESERCIZIO 3 CON ARRAY NUMERI++++");

            Console.WriteLine("Quanti numeri vuoi inserire (numero):");
            int numeroNumeri = int.Parse(Console.ReadLine());
            int[] numeri = new int[numeroNumeri];
            
            for (int i = 0; i < numeri.Length; i++)
            {
                Console.Write("Inserisci il numero #" + (i + 1) + ": ");
                numeri[i] = int.Parse(Console.ReadLine());
            }
            decimal somma = 0;
            decimal media = 0;
            foreach (int numero in numeri)
            {
                somma += numero;

                media = somma / numeroNumeri;
            }
            Console.WriteLine($"La somma di tutti i numeri è: {somma}");
            Console.WriteLine($"La media di tutti i numeri è: {media}");
            Console.ReadLine();
        }
    }

    public class ContoCorrente
    {
        private bool contoAperto = false;
        private double saldo;

        // Metodo per aprire il conto con un versamento iniziale di almeno 1000 euro
        public void ApriConto(double versamentoIniziale)
        {
            if (!contoAperto && versamentoIniziale >= 1000)
            {
                contoAperto = true;
                saldo += versamentoIniziale;
                Console.WriteLine("Conto aperto con successo. Saldo iniziale: " + saldo + " euro.");
            }
            else
            {
                Console.WriteLine($"Impossibile aprire il conto con {versamentoIniziale} euro. Assicurati di avere almeno 1000 euro iniziali.");
            }
        }

        // Metodo per effettuare un versamento
        public void Versamento(double importo)
        {
            if (contoAperto)
            {
                saldo += importo;
                Console.WriteLine("Versamento di " + importo + " euro effettuato. Nuovo saldo: " + saldo + " euro.");
            }
            else
            {
                Console.WriteLine("Errore: Il conto non è aperto. Aprire il conto prima di effettuare un versamento.");
            }
        }

        // Metodo per effettuare un prelievo
        public void Prelievo(double importo)
        {
            if (contoAperto && saldo >= importo)
            {
                saldo -= importo;
                Console.WriteLine("Prelievo di " + importo + " euro effettuato. Nuovo saldo: " + saldo + " euro.");
            }
            else if (!contoAperto)
            {
                Console.WriteLine("Errore: Il conto non è aperto. Aprire il conto prima di effettuare un prelievo.");
            }
            else
            {
                Console.WriteLine("Errore: Saldo insufficiente per il prelievo di " + importo + " euro.");
            }
        }

        // Metodo per controllare il saldo
        public void ControlloSaldo()
        {
            if (contoAperto)
            {
                Console.WriteLine("Il saldo attuale è: " + saldo + " euro.");
            }
            else
            {
                Console.WriteLine("Errore: Il conto non è aperto. Aprire il conto prima di controllare il saldo.");
            }
        }
    }

   
}