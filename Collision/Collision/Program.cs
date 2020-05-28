using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 *  Es muss der Dateipfad von der config.ini angepasst werden
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

        // enthält den Pfad der config.ini Datei, Achtung der Dateipfad muss angepasst werden!!!!
        static string DateiPfad = @"C:\Users\Isaak\Desktop\4_ CollideB\Collision\";
        static string DateiName = "config.ini";
        static string VollstaendigerPfad = DateiPfad + DateiName;

        class einer
        {
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;
            // Konstruktor

            Random random_position = new Random();
            Random random_farbe = new Random();

            /// <summary>
            /// Hier soll ein neues Objekt initialisiert werden, und zwar muss eine freie Position im Feld zufällig gewählt werden, an dem dieses Objekt seine Startposition hat.Ebenso wird eine Zufallsfarbe (ConsoleColor) für das Objekt gewählt.
            /// </summary>
            public einer()
            {

                int posx = 0;
                int posy = 0;

                bool positionfrei = false;


                //Objekte werden mit einer zeitverzögerung erstellt
                System.Threading.Thread.Sleep(20);


                //die Eigenschaft "farbe" wird initialisiert
                farbe = (ConsoleColor)random_farbe.Next(0, 16);


                //Finden einer freien Position
                do
                {
                    posx = random_position.Next(1, seite);
                    posy = random_position.Next(1, seite);

                    if (feld[posx, posy] == 0)
                    {
                        positionfrei = true;
                    }
                }
                while (positionfrei == false);

                this.posx = posx;
                this.posy = posy;

                feld[posx, posy] = 1;
            }


            //Private Methoden
            void show()
            {
                Console.SetCursorPosition(this.posx, this.posy);
                Console.ForegroundColor = this.farbe;
                Console.Write("*");


            }
            void hide()
            {
                Console.SetCursorPosition(this.posx, this.posy);

                Console.Write(" ");


            }
            void collide()
            {
                Console.SetCursorPosition(this.posx, this.posy);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                this.Move();
            }
            //Öffentliche Methoden
            public void Move()
            {
            }






        }


        static void Main(string[] args)
        {
            Console.WindowWidth = seite * 2;
            Console.WindowHeight = seite;
            Console.Clear();
            Random ZG = new Random();
            int Anzahl = ZG.Next(1, 6);
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

            SaveConfig(Anzahl);
            LoadConfig(ref Anzahl);
        }


        //Hier wird die Standard-Konfigurationsdatei config.ini erstellt oder geändert und die Anzahl
        //eingetragen. Sollte die Datei nicht erstellt werden können, wird ein Rückgabewert false retourniert.
        //Ansonsten ist der Rückgabewert true.
        static bool SaveConfig(int Anzahl)
        {
            bool confErstellt;

            //Erstellt und beschreibt die config.ini Datei
            using (StreamWriter sw = new StreamWriter(VollstaendigerPfad))
            {
                sw.WriteLine("{0};", Anzahl);
            }

            //Kontrolliert ob die config.ini Datei erstellt wurde
            confErstellt = File.Exists(VollstaendigerPfad);

            return confErstellt;
        }

        //Hier wird die Standard-Konfigurationsdatei config.ini ausgelesen und die Anzahl zurückgegeben.
        //Sollte die Datei nicht existieren oder keine Anzahl enthalten, wird in Anzahl der Wert 0 und 
        //ein Rückgabewert false retourniert. Ansonsten ist der Rückgabewert true.
        static bool LoadConfig(ref int Anzahl)
        {
            bool confGelesen = true;

            //Alles was in der config.ini steht
            string config = "";
            //wird benötigt um die config.ini Datei Zeile für Zeile auszulesen
            string line = "";

            //Kontrolliert ob es die Config Datei gibt
            if (File.Exists(VollstaendigerPfad))
            {
                //Liest die config.ini aus und speichert es in config
                using (StreamReader sr = new StreamReader(VollstaendigerPfad))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        config += line;
                    }
                }
                //splitet den Inhalt der config.ini bei';'
                string[] ArraySplitConfig = config.Split(';');

                //Kontrolliert ob etwas geschrieben wurde
                if (ArraySplitConfig[0] != "")
                {
                    Anzahl = Convert.ToInt16(ArraySplitConfig[0]);
                }

                else
                {
                    Anzahl = 0;
                    confGelesen = false;
                }

            }
            else
            {
                Anzahl = 0;
                confGelesen = false;
            }
            return confGelesen;
        }
    }
}
