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
        int[,] MacierzWagi;
        int rozmiar = 0;
        public Grafy()
        {
            Macierz = new int[32, 32];
            MacierzWagi = new int[32, 32];
            for (int q = 0; q < 32; q++)
            {
                for (int k = 0; k < 32; k++)
                {
                    Macierz[q, k] = -1;
                    MacierzWagi[q, k] = 0;

                }


            }


        }
        public void transpozycja()
        {
            int[,] transpozycjaTmp;
            transpozycjaTmp = new int[rozmiar, rozmiar];
            for (int q = 0; q < rozmiar; q++)
            {
                for (int k = 0; k < rozmiar; k++)
                {
                    transpozycjaTmp[q, k] = Macierz[k, q];
                    Macierz[k, q] = 0;
                }

            }
            for (int q = 0; q < rozmiar; q++)
            {
                for (int k = 0; k < rozmiar; k++)
                {
                    Macierz[q, k] = transpozycjaTmp[q, k];
                }

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

        public void dodajWage(int numerPierwszegoWierzcholka, int numerDrugiegoWierzcholka, int waga)
        {
            if (Macierz[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] == 1)
            {
                MacierzWagi[numerPierwszegoWierzcholka, numerDrugiegoWierzcholka] = waga;
                MacierzWagi[numerDrugiegoWierzcholka, numerPierwszegoWierzcholka] = waga;
            }
            else
                Console.WriteLine("Krawędź nie istnieje");

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
        public int policzStopien(int numerWierzcholka)
        {
            int stopien = 0;
            int i = 0;
            while (i < rozmiar)
            {
                if (Macierz[numerWierzcholka, i] != -1 && Macierz[numerWierzcholka, i] == 1)
                {
                    stopien++;
                }
                i++;
            }
            return stopien;
            // Console.WriteLine("Stopień równy " + stopien);
        }


        public void maxStopien()
        {
            int stopien = 0;
            int numerWierzcholka = 0;
            int i = 0;
            int maxStopien = 0;
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
        public int minStopien()
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
            return minStopien;
            //  Console.WriteLine("Min = " + minStopien);
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
                    if (stopien % 2 == 1 && Macierz[numerWierzcholka, i] != -1)
                    nieparzyste++;
                i = 0;
                stopien = 0;
                numerWierzcholka++;
            }
            Console.WriteLine("Liczba wierzchołków o parzystym stopniu = " + parzyste + " Liczba wierzchołków o nieparzystym stopniu = " + nieparzyste);
        }
        public ArrayList ciagStopniWierzcholkow()
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
                if (Macierz[numerWierzcholka, i] != -1)
                    ciagStopni.Add(stopien);

                i = 0;
                stopien = 0;
                numerWierzcholka++;
            }
            ciagStopni.Sort();
            ciagStopni.Reverse();

            //Console.WriteLine("Ciąg stopni wierzchołków to: ");
            foreach (int element in ciagStopni)
            {
                //2Console.Write(element + " ");
            }
            return ciagStopni;


        }

        public void podgrafIzomorficzny()
        {

            int[,] matrixIloczyn = new int[rozmiar, rozmiar];
            bool jest = false;
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    int w = 0;
                    for (int k = 0; k < rozmiar; k++)
                    {
                        if (Macierz[i, k] != -1 && Macierz[k, j] != -1)
                        {
                            w += Macierz[i, k] * Macierz[k, j];
                        }




                    }
                    if (Macierz[i, j] == -1)
                        matrixIloczyn[i, j] = -1;
                    else
                        matrixIloczyn[i, j] = w;
                    if (matrixIloczyn[i, j] != 0 && Macierz[i, j] == 1)
                    {
                        jest = true;
                    }

                }

            }
            Console.WriteLine(jest);
        }
        public void sprCiagGrafowy()
        {
            ArrayList ciagStopni = new ArrayList();
            int suma = 0;
            char i = 'n';
            int q = 0;
            while (i != 't')
            {
                Console.WriteLine("Podaj stopeń");
                ciagStopni.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Koniec?");
                i = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            foreach (int element in ciagStopni)
            {
                suma = suma + element;
            }
            ciagStopni.Sort();
            ciagStopni.Reverse();
            if (suma % 2 == 0 && (int)ciagStopni[0] < ciagStopni.Count)
            {
                ciagStopni.Sort();
                ciagStopni.Reverse();
                while ((int)ciagStopni[0] > 0)
                {

                    q = (int)ciagStopni[0];
                    ciagStopni.RemoveAt(0);

                    while (q != 0)
                    {
                        ciagStopni[q - 1] = (int)ciagStopni[q - 1] - 1;
                        q--;

                    }
                    ciagStopni.Sort();
                    ciagStopni.Reverse();
                }


                bool ok = true;
                foreach (int element in ciagStopni)
                {
                    if (element != 0)
                        ok = false;
                }
                if (ok == false)
                    Console.WriteLine("Ciąg nie jest grafowy");
                else
                    Console.WriteLine("Ciąg jest grafowy");


            }
            else
                Console.WriteLine("Ciąg liczb naturalnych nie jest ciągiem grafowym ");
        }
        public void jordan()
        {
            ArrayList odblokowane = new ArrayList();

            int pomRozmiar = rozmiar;

            int q = 0;

            while (pomRozmiar > 2)
            {
                for (int w = 0; w < rozmiar; w++)
                {
                    if (this.policzStopien(w) == 1)
                        odblokowane.Add(w);

                }
                foreach (int licznik in odblokowane)
                {
                    this.usunWierzcholek(licznik);
                    pomRozmiar--;
                }
                odblokowane.Clear();
                q++;
            }
            for (q = 0; q < rozmiar; q++)
            {
                if (Macierz[q, q] != -1)
                    Console.WriteLine("numer " + q);
            }

        }

        public void cykl()
        {

            int i = 0;
            int w = 0;
            bool cykl = false;
            int q = 0;
            bool kolejny = false;
            int poczatek;
            int stareI = 0;
            bool sprawdzenie = false;
            ArrayList odwiedzone = new ArrayList();
            while (w < rozmiar && cykl == false)
            {

                poczatek = w;
                odwiedzone.Clear();
                odwiedzone.Add(poczatek);
                sprawdzenie = false;
                i = w;

                while (i < rozmiar && cykl == false && sprawdzenie == false)
                {
                    stareI = i;

                    if (Macierz[i, i] != -1)
                    {

                        while (kolejny == false && q < rozmiar)
                        {
                            Console.WriteLine("q=" + q);
                            if (Macierz[i, q] == 1 && (odwiedzone.Contains(q) == false || (odwiedzone.Count > this.minStopien() && q == poczatek)))
                            {

                                kolejny = true;
                                odwiedzone.Add(q);
                                i = q;
                                if (q == poczatek && odwiedzone.Count > this.minStopien())
                                {
                                    cykl = true;
                                }

                            }
                            if (q == rozmiar)
                                i++;
                            q++;


                        }
                        kolejny = false;
                        if (i == stareI)
                            sprawdzenie = true;
                        q = w;

                    }


                }
                w++;
            }

            foreach (int element in odwiedzone)
            {
                // Console.Write("-> " + element);

            }
        }
        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.Write("    {0}", obj);
            Console.WriteLine();
        }

        //zwracania zrzuconych ze stosus
        public ArrayList dfs(int poczatek = 0, int licznikSkladowych = 1)
        {
            ArrayList odwiedzone = new ArrayList();
            ArrayList listaWyrzuconychZeStosu = new ArrayList();
            int aktualnyWierzcholek = poczatek;
            Stack myStack = new Stack();
            myStack.Push(poczatek);
            // odwiedzone.Add(0);
            bool dalej = true;
            bool jesliSlepy = false;
            int q = poczatek;

            Console.WriteLine("Składowa" + licznikSkladowych);
            while (myStack.Count != 0)
            {

                if (jesliSlepy)
                {
                    aktualnyWierzcholek = (int)myStack.Peek();
                    jesliSlepy = false;
                }
                else
                {
                    odwiedzone.Add(q);
                    aktualnyWierzcholek = q;
                }
                q = 0;
                dalej = true;
                while (dalej)
                {
                    if (Macierz[aktualnyWierzcholek, q] == 1 && odwiedzone.Contains(q) == false)
                    {
                        myStack.Push(q);
                        dalej = false;
                        // Console.WriteLine("{0},{1}", aktualnyWierzcholek, myStack.Peek());
                    }
                    else
                        if (q == rozmiar - 1)
                    {
                        listaWyrzuconychZeStosu.Add(myStack.Pop());
                        jesliSlepy = true;
                        dalej = false;
                    }
                    if (dalej == true)
                        q++;

                }

            }
            Console.WriteLine();
            return listaWyrzuconychZeStosu;
        }
        public void czySpojny()
        {
            bool nieJestSpojny = false;
            ArrayList odwiedzone = new ArrayList();
            odwiedzone = this.dfs();
            ArrayList tmp = new ArrayList();
            int licznikSkladowa = 1;
            foreach (int element in odwiedzone)
            {
                Console.WriteLine("{0}", element);
            }
            for (int i = 0; i < rozmiar; i++)
            {
                if (odwiedzone.Contains(i) == false)
                {
                    licznikSkladowa++;
                    nieJestSpojny = true;
                    tmp = this.dfs(i, licznikSkladowa);

                    foreach (int element in tmp)
                    {
                        odwiedzone.Add(element);
                        Console.WriteLine("{0}", element);
                    }
                }
            }
            if (nieJestSpojny)
                Console.WriteLine("Graf nie jest spójny");
            else
                Console.WriteLine("Graf jest spójny");
        }

        public void kosaraju()
        {
            ArrayList listaWyrzuconychZeStosu = new ArrayList();
            listaWyrzuconychZeStosu = this.dfs();
            this.transpozycja();
            while (listaWyrzuconychZeStosu.Count == 0)
            {

            }

        }


        public void kruskal()
        {
            int min = 1000000;
            int numerPierwszego = -1;
            int numerDrugiego = -1;
            int[,] Owiedzone;
            ArrayList odwiedzoneLista = new ArrayList();
            Owiedzone = new int[rozmiar, rozmiar];
            // Owiedzone[0, 0] = 1;
            while (odwiedzoneLista.Count != rozmiar - 2)
            {
                for (int q = 0; q < rozmiar; q++)
                {
                    for (int k = 0; k < rozmiar; k++)
                    {
                        if (min >= MacierzWagi[q, k] && Owiedzone[q, k] == 0 && q != k && Macierz[q, k] == 1)
                        {
                            min = MacierzWagi[q, k];
                            numerPierwszego = q;
                            numerDrugiego = k;
                            odwiedzoneLista.Add(numerDrugiego);
                            Console.WriteLine(min);
                        }
                    }

                }
                Console.WriteLine("{0},{1}", numerPierwszego, numerDrugiego);
                Owiedzone[numerPierwszego, numerDrugiego] = 1;
                Owiedzone[numerDrugiego, numerPierwszego] = 1;
                MacierzWagi[numerPierwszego, numerDrugiego] = 10000;
                MacierzWagi[numerDrugiego, numerPierwszego] = 10000;


            }


        }

        public void Dijkstra(int wierzcholek=0)
        {
            int[,] Tabela;
            Tabela = new int[this.rozmiar, this.rozmiar];
            ArrayList odwiedzoneLista = new ArrayList();
            int min = 90000000;
            
            for (int i = 0; i < rozmiar; i++)
            {
                for (int q = 0; q < rozmiar; q++)
                {
                    if (i == 0)
                    {
                        if (q == wierzcholek)
                        {
                            Tabela[i, q] = 0;
                        }
                        else
                        if (this.Macierz[wierzcholek, q] == 1)
                            Tabela[i, q] = this.MacierzWagi[wierzcholek, q];
                        else
                            Tabela[i, q] = 100000;

                    }
                    else
                    {
                        if (this.Macierz[(int)odwiedzoneLista[odwiedzoneLista.Count-1], q] == 1)
                        {
                            if (this.MacierzWagi[(int)odwiedzoneLista[odwiedzoneLista.Count - 1], q] + Tabela[i - 1, (int)odwiedzoneLista[odwiedzoneLista.Count - 1]] < Tabela[i - 1, q])
                            {
                                Tabela[i, q] = this.MacierzWagi[(int)odwiedzoneLista[odwiedzoneLista.Count - 1], q] + Tabela[i - 1, (int)odwiedzoneLista[odwiedzoneLista.Count - 1]];
                            }
                            else
                                
                            
                                Tabela[i, q] = Tabela[i - 1, q];
                            
                            
                        }
                        else
                            Tabela[i, q] = Tabela[i - 1, q];
                    }

                }
                int pom=-1;
                for (int k = 0; k < rozmiar; k++)
                {
                    
                        if (Tabela[i, k] < min && odwiedzoneLista.Contains(k)==false && k!=wierzcholek)
                    {


                        min = Tabela[i, k];
                        pom = k;
                    }
                }
                odwiedzoneLista.Add(pom);
                min = 900000000;
                for(int p=0;p<rozmiar;p++)
                {
                    Console.Write("{0} ", Tabela[i, p]);
                }
                Console.WriteLine();
            }

        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                int numerPierwszegoWierzchołka;
                int numerDrugiegoWierzchołka;
                int waga;
                int caseSwitch = 1;
                Grafy graf = new Grafy();

                while (caseSwitch != 0)
                {
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
                    Console.WriteLine("10-Sprawdź czy ciąg liczb naturalnych jest ciągiem grafowym");
                    Console.WriteLine("11-Sprawdź czy graf zawiera podgraf izomorwiczny do C3");
                    Console.WriteLine("12-Algorytm Jordana");
                    Console.WriteLine("13-Szukanie cylku");
                    Console.WriteLine("14-Test case");
                    Console.WriteLine("16-DFS");
                    Console.WriteLine("17-DFS-test case");
                    Console.WriteLine("18-DFS-test case2(tablica)");
                    Console.WriteLine("19-Sprawdź czy graf jest spójny");
                    Console.WriteLine("20-test case Spr czy graf jest spójny");
                    Console.WriteLine("25-test case Dijkstra");
                    Console.WriteLine("26-Dijkstra");
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
                        case 10:
                            graf.sprCiagGrafowy();
                            break;
                        case 11:
                            graf.podgrafIzomorficzny();
                            break;
                        case 12:
                            graf.jordan();
                            break;
                        case 13:
                            graf.cykl();
                            break;

                        case 14:
                            for (int i = 0; i < 22; i++)
                            {
                                graf.dodajWierzcholek();
                            }
                            graf.dodajKrawedz(0, 1);
                            graf.dodajKrawedz(0, 2);
                            graf.dodajKrawedz(1, 2);
                            graf.dodajKrawedz(1, 6);

                            graf.dodajKrawedz(6, 5);
                            graf.dodajKrawedz(5, 4);
                            graf.dodajKrawedz(3, 4);
                            graf.dodajKrawedz(6, 3);
                            graf.dodajKrawedz(6, 4);
                            graf.dodajKrawedz(5, 3);
                            graf.dodajKrawedz(2, 7);
                            graf.dodajKrawedz(7, 8);
                            graf.dodajKrawedz(8, 9);
                            graf.dodajKrawedz(9, 10);
                            graf.dodajKrawedz(7, 10);
                            graf.dodajKrawedz(7, 9);
                            graf.dodajKrawedz(10, 8);

                            graf.dodajKrawedz(0, 11);
                            graf.dodajKrawedz(11, 12);
                            graf.dodajKrawedz(12, 13);
                            graf.dodajKrawedz(13, 11);
                            graf.dodajKrawedz(13, 14);
                            graf.dodajKrawedz(14, 15);
                            graf.dodajKrawedz(15, 16);
                            graf.dodajKrawedz(16, 17);
                            graf.dodajKrawedz(17, 14);
                            graf.dodajKrawedz(16, 14);
                            graf.dodajKrawedz(15, 17);
                            graf.dodajKrawedz(12, 18);
                            graf.dodajKrawedz(18, 19);
                            graf.dodajKrawedz(19, 20);
                            graf.dodajKrawedz(20, 21);
                            graf.dodajKrawedz(21, 18);
                            graf.dodajKrawedz(18, 20);
                            graf.dodajKrawedz(21, 19);

                            break;
                        case 15:
                            for (int q = 0; q < 7; q++)
                                graf.dodajWierzcholek();
                            graf.dodajKrawedz(0, 1);
                            graf.dodajKrawedz(2, 0);
                            graf.dodajKrawedz(3, 0);
                            graf.dodajKrawedz(1, 4);
                            graf.dodajKrawedz(1, 5);
                            graf.dodajKrawedz(5, 6);




                            break;
                        case 16:
                            graf.dfs();
                            break;
                        case 17:
                            for (int q = 0; q < 6; q++)
                                graf.dodajWierzcholek();
                            graf.dodajKrawedz(0, 1);
                            graf.dodajKrawedz(1, 2);
                            graf.dodajKrawedz(2, 5);
                            graf.dodajKrawedz(1, 3);
                            graf.dodajKrawedz(3, 4);

                            break;
                        case 18:
                            for (int q = 0; q < 9; q++)
                                graf.dodajWierzcholek();
                            graf.dodajKrawedz(0, 1);
                            graf.dodajKrawedz(0, 3);
                            graf.dodajKrawedz(3, 7);
                            graf.dodajKrawedz(7, 1);
                            graf.dodajKrawedz(0, 7);
                            graf.dodajKrawedz(7, 2);
                            graf.dodajKrawedz(7, 4);
                            graf.dodajKrawedz(7, 5);
                            graf.dodajKrawedz(4, 5);
                            graf.dodajKrawedz(5, 8);
                            graf.dodajKrawedz(8, 6);
                            graf.dodajKrawedz(6, 5);


                            break;
                        case 19:
                            graf.czySpojny();
                            break;
                        case 20:
                            for (int q = 0; q < 10; q++)
                                graf.dodajWierzcholek();
                            graf.dodajKrawedz(0, 4);
                            graf.dodajKrawedz(4, 1);
                            graf.dodajKrawedz(1, 2);
                            graf.dodajKrawedz(2, 3);
                            graf.dodajKrawedz(3, 1);
                            graf.dodajKrawedz(6, 5);
                            graf.dodajKrawedz(5, 7);
                            graf.dodajKrawedz(7, 6);

                            graf.dodajKrawedz(8, 9);



                            break;
                        case 21:
                            graf.kosaraju();
                            break;

                        case 22:
                            Console.WriteLine("Podaj pierwszy wierzchołek");
                            numerPierwszegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Podaj drugi wierzchołek");
                            numerDrugiegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Podaj wage");
                            waga = Convert.ToInt32(Console.ReadLine());
                            graf.dodajWage(numerPierwszegoWierzchołka, numerDrugiegoWierzchołka, waga);
                            break;
                        case 23:
                            graf.kruskal();
                            break;
                        case 24:
                            for (int q = 0; q < 5; q++)
                                graf.dodajWierzcholek();
                            graf.dodajKrawedz(0, 1);
                            graf.dodajKrawedz(0, 2);
                            graf.dodajKrawedz(2, 3);
                            graf.dodajKrawedz(3, 4);

                            graf.dodajWage(0, 1, 5);
                            graf.dodajWage(0, 2, 6);

                            graf.dodajWage(2, 3, 7);
                            graf.dodajWage(3, 4, 4);

                            break;
                    case 25:
                        for (int q = 0; q < 6; q++)
                            graf.dodajWierzcholek();
                        graf.dodajKrawedz(0, 3);
                        graf.dodajKrawedz(0, 2);
                        graf.dodajKrawedz(0, 4);
                        graf.dodajKrawedz(3, 4);
                        graf.dodajKrawedz(3, 2);
                        graf.dodajKrawedz(2, 4);
                        graf.dodajKrawedz(2, 1);
                        graf.dodajKrawedz(1, 5);
                        graf.dodajKrawedz(5, 4);
                        graf.dodajKrawedz(4, 1);

                        graf.dodajWage(0, 3,2);
                        graf.dodajWage(0, 2,2);
                        graf.dodajWage(0, 4,1);
                        graf.dodajWage(3, 4,2);
                        graf.dodajWage(3, 2,1);
                        graf.dodajWage(2, 4,1);
                        graf.dodajWage(2, 1,1);
                        graf.dodajWage(1, 5,1);
                        graf.dodajWage(5, 4,4);
                        graf.dodajWage(4, 1,3);
                        break;
                    case 26:
                        Console.WriteLine("Podaj wierzchołek do liczenia odległości");
                        numerPierwszegoWierzchołka = Convert.ToInt32(Console.ReadLine());
                        graf.Dijkstra(numerPierwszegoWierzchołka);
                        break;
                        default:
                            Console.WriteLine("Zły wybór");
                            break;

                    }
                }

            }
        }


    }
