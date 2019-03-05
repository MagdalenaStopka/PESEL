using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPESEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            string PESEL = "";
            Program p = new Program();
            Console.WriteLine("Wprowadź PESEL:");
            PESEL = Console.ReadLine();

            p.SprawdzDlugosc(PESEL);
            p.SprawdzZnaki(PESEL);
            p.SprawdzCyfreKontrolna(PESEL);
            p.DataUrodzenia(PESEL);
            p.SprawdzPlec(PESEL);



            Console.ReadKey();
        }

        public void SprawdzDlugosc(string PESEL)
        {
            int dlugosc = PESEL.Length;
            if (dlugosc != 11)
            {
                throw new FormatException("Podano nieprawidłową liczbę znaków- wpisz 11 cyfr");
            }
            //else
            //    Console.WriteLine("Wprowadzono poprawną ilość znaków");
        }

        public void SprawdzZnaki(string PESEL)
        {
            try
            {
                long cyfry = long.Parse(PESEL);

            }
            catch (FormatException e)
            {
                throw new FormatException("Podany PESEL zawiera znaki, które nie są cyframi", e);
            }
        }

        public string SprawdzPlec(string PESEL)
        {
            char dziesiata = PESEL[9];
            int dziesiata1 = int.Parse(dziesiata.ToString());

            string plec = "";
            if (dziesiata1 % 2 == 0)
            {
                plec = "Kobieta";
            }
            else
            {
                plec = "Mężczyzna";
            }
            Console.WriteLine("Płeć: " + plec);
            return plec;

        }
        public void DataUrodzenia(string PESEL)
        {
            char pierwsza = PESEL[0];
            char druga = PESEL[1];
            char trzecia = PESEL[2];
            char czwarta = PESEL[3];
            char piata = PESEL[4];
            char szosta = PESEL[5];
            char siodma = PESEL[6];
            char osma = PESEL[7];
            char dziewiata = PESEL[8];
            char dziesiata = PESEL[9];
            char jedenasta = PESEL[10];
            int trzecia1 = int.Parse(trzecia.ToString());
            string dataUrodzenia;

            if (trzecia1 == 0 || trzecia1 == 1)
            { // Wypisuje datę urodzenia osób urodzonych w latach 1900-1999
                dataUrodzenia = "19" + pierwsza.ToString() + druga.ToString() + "-" + trzecia.ToString() + czwarta.ToString() + "-" + piata.ToString() + szosta.ToString();
            }
            else
            { // Wypisuje datę urodzenia osób urodzonych w latach 2000-2099
                dataUrodzenia = "20" + pierwsza.ToString() + druga.ToString() + "-" + (trzecia1 - 1).ToString() + czwarta.ToString() + "-" + piata.ToString() + szosta.ToString();
            }
            Console.WriteLine("Data urodzenia to: " + dataUrodzenia);

        }
        public void SprawdzCyfreKontrolna(string PESEL)
        {
            char pierwsza = PESEL[0];
            char druga = PESEL[1];
            char trzecia = PESEL[2];
            char czwarta = PESEL[3];
            char piata = PESEL[4];
            char szosta = PESEL[5];
            char siodma = PESEL[6];
            char osma = PESEL[7];
            char dziewiata = PESEL[8];
            char dziesiata = PESEL[9];
            char jedenasta = PESEL[10];
            int pierwsza1 = int.Parse(pierwsza.ToString());
            int druga1 = int.Parse(druga.ToString());
            int trzecia1 = int.Parse(trzecia.ToString());
            int czwarta1 = int.Parse(czwarta.ToString());
            int piata1 = int.Parse(piata.ToString());
            int szosta1 = int.Parse(szosta.ToString());
            int siodma1 = int.Parse(siodma.ToString());
            int osma1 = int.Parse(osma.ToString());
            int dziewiata1 = int.Parse(dziewiata.ToString());
            int dziesiata1 = int.Parse(dziesiata.ToString());
            int jedenasta1 = int.Parse(jedenasta.ToString());
            //9×a + 7×b + 3×c + 1×d + 9×e + 7×f + 3×g + 1×h + 9×i + 7×j
            //1×a + 3×b + 7×c + 9×d + 1×e + 3×f + 7×g + 9×h + 1×i + 3×j + 1×k - wersja bez dzielenia

            int kontrola = 9 * pierwsza1 + 7 * druga1 + 3 * trzecia1 + 1 * czwarta1 + 9 * piata1 + 7 * szosta1 + 3 * siodma1 + 1 * osma1 + 9 * dziewiata1 + 7 * dziesiata1;
            int cyfraKontrolna = kontrola % 10;

            if (cyfraKontrolna != jedenasta1)
            {
                throw new Exception("Podany PESEL jest błędny- cyfra kontrolna nie zgadza się");
            }
            else
            {
                Console.WriteLine("Podany PESEL jest prawidłowy");
                //DataUrodzenia(PESEL);
            }
        }

    }
}