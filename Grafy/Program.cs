using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    class Grafy
    {
        int[,] Macierz;
        int rozmiar=0;
        public Grafy()
        {
            Macierz = new int[32, 32];
            for (int q = 0; q < 32; q++)
            {
                for (int k = 0; k < 32; k++)
                    Macierz[q, k] = -1;

            }

        }
        public void dodajWierzcholek()
        {
            
            int i=1;
            
       
            Console.WriteLine("Dodać wierzchołek?");
            i = Convert.ToInt32(Console.ReadLine());
            while (i == 1)
            {

                for (int q = 0; q < 32; q++)
                {
                    Macierz[rozmiar, q] = 0;
                    Macierz[q, rozmiar] = 0;

                }
                rozmiar++;
                Console.WriteLine("Dodać wierzchołek?");
                i = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void usunWierzcholek()
        {

            int i = 1;
            int numerWiercholka;

            Console.WriteLine("Usunąć wierzchołek?");
            i = Convert.ToInt32(Console.ReadLine());
            while (i == 1)
            {
                Console.WriteLine("Podaj numer wierzchołka");
                numerWiercholka = Convert.ToInt32(Console.ReadLine());
                for (int q = 0; q < 32; q++)
                {
                    Macierz[numerWiercholka, q] = -1;
                    Macierz[q, numerWiercholka] = -1;

                }
                
                Console.WriteLine("Usunąć wierzchołek?");
                i = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void dodajKrawedz()
        {
            int i;
            int numerPierwszegoWierzcholka;
            int numerDrugiegoWierzcholka;
            Console.WriteLine("Dodać krawędź?");
            i = Convert.ToInt32(Console.ReadLine());
            while (i == 1)
            {
                Console.WriteLine("Podaj pierwszy wierzchołek z którego ma wychodzić krawędź");
                numerPierwszegoWierzcholka = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj drugi wierzchołek do którego ma wchodzić krawędź");
                numerDrugiegoWierzcholka = Convert.ToInt32(Console.ReadLine());
                if(numerPierwszegoWierzcholka == -1 || numerDrugiegoWierzcholka == -1)
                if (Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] == 0)
                {
                    Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] = 1;
                    Macierz[numerDrugiegoWierzcholka, numerPierwszegoWierzcholka] = 1;
                }
                else
                    Console.WriteLine("Krawędź już istnieje");
                Console.WriteLine("Dodać krawędź?");
                i = Convert.ToInt32(Console.ReadLine());
            }

        }

        public void usunKrawedz()
        {
            int i;
            int numerPierwszegoWierzcholka;
            int numerDrugiegoWierzcholka;
            Console.WriteLine("Usuniąć krawędź?");
            i = Convert.ToInt32(Console.ReadLine());
            while (i == 1)
            {
                Console.WriteLine("Podaj pierwszy wierzchołek z którego usunąć krawędź");
                numerPierwszegoWierzcholka = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj drugi wierzchołek z którego usunąć krawędź");
                numerDrugiegoWierzcholka = Convert.ToInt32(Console.ReadLine());
                if (Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] == 0)
                {
                    Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] = 0;
                    Macierz[numerDrugiegoWierzcholka, numerPierwszegoWierzcholka] = 0;
                }
                else
                    Console.WriteLine("Taka krawędź nie istnieje");
                
                Console.WriteLine("Usuniąć krawędź?");
                i = Convert.ToInt32(Console.ReadLine());
            }

        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            Grafy graf = new Grafy();
            graf.dodajWierzcholek();
            graf.usunWierzcholek();
            graf.dodajKrawedz();
            graf.usunKrawedz();

        }
    }
}
