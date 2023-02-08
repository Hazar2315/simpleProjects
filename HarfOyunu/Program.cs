// See https://aka.ms/new-console-template for more information

using HarfOyunu;
using System;
using System.Collections;
using System.Diagnostics;

namespace HarfOyunu
{
    class Program
    {
        private static Kart[,] kartlar = new Kart [4,4];
        static void Main(string[] args)
        {
            Hamle hamle = new Hamle();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var rand=new Random();
            ArrayList letters=new ArrayList();
            letters.Add('A');
            letters.Add('B');
            letters.Add('C');
            letters.Add('D');
            letters.Add('E');
            letters.Add('F');
            letters.Add('G');
            letters.Add('H');
            letters.Add('A');
            letters.Add('B');
            letters.Add('C');
            letters.Add('D');
            letters.Add('E');
            letters.Add('F');
            letters.Add('G');
            letters.Add('H');
            int index;
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    index = (int)rand.NextInt64(letters.Count);

                    kartlar[i, j] = new Kart((Char)letters[index]);
                    letters.RemoveAt(index);
                }
            }
            while (oyunBittiMi() == false)
            {

                oyunTahtasi();
                hamle.setHamle(hamle.getHamle()+1);
                tahminEt();

            }
            Console.WriteLine("Oyun Boyunca Yaptığınız hamle sayısı : " + hamle.getHamle());
            stopwatch.Stop();
            Console.WriteLine($"Oyunu Bitirdiğiniz Süre: {stopwatch.Elapsed}");
            Console.ReadLine();

        }
        public static Boolean oyunBittiMi()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (kartlar[i,j].getTahmin() == false)
                    {
                        return false;

                    }

                }
            }
            return true;

        }

        public static void tahminEt()
        {
            
            Console.WriteLine("Birinci Tahmin (i ve j değerlerini bir boşluklu girin...):");
            int i1;
            i1= Convert.ToInt32(Console.ReadLine());
            i1 = i1 - 1;
            int j1 = Convert.ToInt32(Console.ReadLine());
            j1 = j1 - 1;

            kartlar[i1,j1].setTahmin(true);
            oyunTahtasi();

            Console.WriteLine("İkinci Tahmin (i ve j değerlerini bir boşluklu girin...): ");
            int i2 = Convert.ToInt32(Console.ReadLine());
            i2 = i2 - 1;
            int j2 = Convert.ToInt32(Console.ReadLine());
            j2 = j2 - 1;
            if (kartlar[i1,j1].getDeger() == kartlar[i2,j2].getDeger())
            {
                Console.WriteLine("Doğru Tahmin. Tebrikler! ");
                kartlar[i2,j2].setTahmin(true);

            }
            else
            {
                Console.WriteLine("Yanlış Tahmin...");
                kartlar[i1,j1].setTahmin(false);

            }
            



        }
        public static void oyunTahtasi()
        {
            int kartAdet = 16;
            for (int a = 0; a < 4; a++)
            {
                Console.WriteLine("____________________");
                for (int b = 0; b < 4; b++)
                {
                    Console.Write("|" + kartlar[a, b].getDeger() + "|");
                }
                Console.WriteLine("");
            }


            if (kartAdet == 0)
            {
                Console.WriteLine("Oyun Bitti");
               
            }
            else
            {
                for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("____________________");
                for (int j = 0; j < 4; j++)
                {

                    if (kartlar[i,j].getTahmin())
                    {
                        Console.Write("|" + kartlar[i, j].getDeger() + "|");

                    }
                    else
                    {
                        Console.Write("| |");

                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("____________________");
            }

            



        }

    }
}


