using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 * 
 * 
 * 
 * 2020 TFO-Meran
 */

namespace ConsoleApplication1
{
    class Program
    {
        const int seite = 50;
        static int[,] feld = new int[seite, seite];

        class einer
        {
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;
            // Konstruktor
            public einer()
            {
            }
            //Private Methoden
            void show()
            {
            }
            void hide()
            {
            }
            void collide()
            {
            }
            //Öffentliche Methoden
            public void Move()
            {
            }

        }
        static bool SaveConfig(int Anzahl)
        {
            var Path = @"C:\Users\Melvi\OneDrive\Desktop\COLLIDE\C_2_ollide\config.ini";
            string Text = Convert.ToString(Anzahl);
            File.WriteAllText(Path, Text);

            if (File.Exists(Path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool LoadConfig(ref int Anzahl)
        {
            var Path = @"C:\Users\Melvi\OneDrive\Desktop\COLLIDE\C_2_ollide\config.ini";
            string Text = File.ReadAllText(Path);
            Anzahl = Convert.ToInt32(Text); 
            if (File.Exists(Path) & Anzahl > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WindowWidth = seite*2;
            Console.WindowHeight = seite;
            Console.Clear();
            Random ZG = new Random();
            int Anzahl=ZG.Next(1,6);
            einer[] meineEiner = new einer[Anzahl];
            for (int i = 0; i < Anzahl; i++)
            {
                meineEiner[i] = new einer();
            }
            Console.CursorVisible = false;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < Anzahl; j++)
                {
                    meineEiner[j].Move();
                }
                System.Threading.Thread.Sleep(10);

            }
        }
    }
}
