using System;
using System.Collections;
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
                for (int q = 0; q < 32; q++)
                {
                    Macierz[rozmiar, q] = 0;
                    Macierz[q, rozmiar] = 0;

                }
                rozmiar++;
                Console.WriteLine("Wierzchołek dodany. Jego numer to " + Convert.ToInt32(rozmiar - 1));             
            
        }
        public void usunWierzcholek(int numerWiercholka)
        {              
                for (int q = 0; q < 32; q++)
                {
                    Macierz[numerWiercholka, q] = -1;
                    Macierz[q, numerWiercholka] = -1;
                }
                Console.WriteLine("Wierzchołek usunięty");               
            
        }
        public void dodajKrawedz(int numerPierwszegoWierzcholka, int numerDrugiegoWierzcholka)
        {              
                if (Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] == 0)
                {
                    Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] = 1;
                    Macierz[numerDrugiegoWierzcholka, numerPierwszegoWierzcholka] = 1;
                }
                else
                    Console.WriteLine("Krawędź już istnieje");                   
        }

        public void usunKrawedz(int numerPierwszegoWierzcholka, int numerDrugiegoWierzcholka)
        {

                if (Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] == 1)
                {
                    Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] = 0;
                    Macierz[numerDrugiegoWierzcholka, numerPierwszegoWierzcholka] = 0;
                    Console.WriteLine("Krawędź usunięta");
                }
                else
                    Console.WriteLine("Taka krawędź nie istnieje");                        
        }
        public void policzStopien(int numerWierzcholka)
        {
            int stopien=0;                      
            int i = 0;
            while (i < rozmiar)
            {
                if (Macierz[numerWierzcholka, i] != -1 && Macierz[numerWierzcholka, i] ==1)
                {
                    stopien++;
                }
                i++;
            }
            Console.WriteLine("Stopień równy " + stopien);
        }


        public void maxStopien()
        {
            int stopien = 0;
            int numerWierzcholka = 0;           
            int i = 0;
            int maxStopien=0;
            while (numerWierzcholka < rozmiar)
            {

                while (i < rozmiar)
                {
                    
                    if (Macierz[numerWierzcholka, i] != -1 && Macierz[numerWierzcholka, i] == 1)
                    {
                        stopien++;
                    }
                   
                    i++;
                }
                if (maxStopien < stopien && Macierz[numerWierzcholka, i] != -1)
                    maxStopien = stopien;
                i = 0;
                stopien = 0;
                numerWierzcholka++;
            }
            Console.WriteLine("Max = " + maxStopien);
        }
        public void minStopien()
        {
            int stopien = 0;
            int numerWierzcholka = 0;
            int i = 0;
            int minStopien = 32;
            while (numerWierzcholka < rozmiar)
            {
                stopien = 0;
                while (i < rozmiar)
                {

                    if (Macierz[numerWierzcholka, i] != -1 && Macierz[numerWierzcholka, i] == 1)
                    {
                        stopien++;
                    }
                    i++;
                }
                if (minStopien > stopien && Macierz[numerWierzcholka, i] != -1)
                    minStopien = stopien;
                i = 0;
                numerWierzcholka++;
            }
            Console.WriteLine("Min = " + minStopien);
        }
        public void parzystyNieparzystyStopien()
        {
            int stopien = 0;
            int numerWierzcholka = 0;
            int i = 0;
            int parzyste = 0;
            int nieparzyste = 0;
            while (numerWierzcholka < rozmiar)
            {

                while (i < rozmiar)
                {

                    if (Macierz[numerWierzcholka, i] != -1 && Macierz[numerWierzcholka, i] == 1)
                    {
                        stopien++;
                    }
                    i++;
                }
                if (stopien % 2 == 0 && Macierz[numerWierzcholka, i] != -1)
                    parzyste++;
                else
                    if(stopien % 2 == 1 && Macierz[numerWierzcholka, i] != -1)
                        nieparzyste++;
                i = 0;
                stopien = 0;
                numerWierzcholka++;
            }
            Console.WriteLine("Liczba wierzchołków o parzystym stopniu = " + parzyste + " Liczba wierzchołków o nieparzystym stopniu = " + nieparzyste);
        }
        public void ciagStopniWierzcholkow()
        {
            int stopien = 0;
            int numerWierzcholka = 0;
            int i = 0;
            ArrayList ciagStopni = new ArrayList();

            while (numerWierzcholka < rozmiar)
            {

                while (i < rozmiar)
                {

                    if (Macierz[numerWierzcholka, i] != -1 && Macierz[numerWierzcholka, i] == 1)
                    {
                        stopien++;
                    }
                    i++;
                }
                if(Macierz[numerWierzcholka, i] != -1)
                    ciagStopni.Add(stopien);
               
                i = 0;
                stopien = 0;
                numerWierzcholka++;
            }
            ciagStopni.Sort();
            ciagStopni.Reverse();
            Console.WriteLine("Ciąg stopni wierzchołków to: ");
            foreach (int element in ciagStopni)
            {
                Console.Write(element + " ");
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int numerPierwszegoWierzchołka;
            int numerDrugiegoWierzchołka;

            int caseSwitch = 1;
            Grafy graf = new Grafy();
            
            while (caseSwitch !=0) {
                Console.WriteLine();
                Console.WriteLine("1-Dodaj wierzchołek");
                Console.WriteLine("2-Usuń wierzchołek");
                Console.WriteLine("3-Dodaj krawędź");
                Console.WriteLine("4-Usuń krawędź");
                Console.WriteLine("5-Stopień wierzchołka");
                Console.WriteLine("6-Maksymalny stopień grafu");
                Console.WriteLine("7-Minimalny stopień grafu");
                Console.WriteLine("8-Wszaczenie ilości wierzchołków parzdystego i nie parzystego stopnia");
                Console.WriteLine("9-Wypisanie Ciągu stopni wierzchołków");
                Console.WriteLine("0-Koniec");



                caseSwitch = Convert.ToInt32(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 0:
                        break;
                    case 1:
                        graf.dodajWierzcholek();
                        break;
                    case 2:
                        Console.WriteLine("Podaj wierzchołek do usunięcia");
                        numerPierwszegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                        graf.usunWierzcholek(numerPierwszegoWierzchołka);
                        break;
                    case 3:
                        Console.WriteLine("Podaj pierwszy wierzchołek");
                        numerPierwszegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Podaj drugi wierzchołek");
                        numerDrugiegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                        graf.dodajKrawedz(numerPierwszegoWierzchołka, numerDrugiegoWierzchołka);
                        break;
                    case 4:
                        Console.WriteLine("Podaj pierwszy wierzchołek");
                        numerPierwszegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Podaj drugi wierzchołek");
                        numerDrugiegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                        graf.usunKrawedz(numerPierwszegoWierzchołka, numerDrugiegoWierzchołka);
                        break;
                    case 5:
                        Console.WriteLine("Podaj wierzchołek do obliczenia jego stopnia");
                        numerPierwszegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                        graf.policzStopien(numerPierwszegoWierzchołka);
                        break;
                    case 6:
                        graf.maxStopien();
                        break;
                    case 7:
                        graf.minStopien();
                        break;
                    case 8:
                        graf.parzystyNieparzystyStopien();
                        break;
                    case 9:
                        graf.ciagStopniWierzcholkow();
                        break;
                    default:
                        Console.WriteLine("Zły wybór");
                        break;
                }
            }

        }
    }
}
