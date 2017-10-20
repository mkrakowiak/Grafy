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

        }
    }
}
