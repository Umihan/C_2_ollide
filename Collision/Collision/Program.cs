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
            Random Zufall = new Random();
            // Konstruktor
            public einer()
            {
                do
                {
                    posy = Zufall.Next(0, seite);
                    posx = Zufall.Next(0, seite);

                } while (feld[posx, posy] == 1);
                feld[posx, posy] = 1;

                farbe = (ConsoleColor)(Zufall.Next(Enum.GetNames(typeof(ConsoleColor)).Length));


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
                // Hier die Programmierung der Move Methode
                /*
                 * Die Erstplatzierung der Objekte errfolgt außerhalb dieser Methode.
                 * Hier werden die Objekte verschoben, im Falle einer Kollision (collide) wird die entsprechende Methdoe aufgerufen.
                 * Selbiges selbe gilt für das Löschen (hide) und Zeichnen (show).
                 * Die Abfolge der Methoden entspricht der Programmbeschreibung (hide, show und dann collide).
                 */

                int XAlt = posx; // Die "alten Koordinaten" werden aus der Klasse "einer" übernommen
                int YAlt = posy; 

                int XNeu = 0, YNeu = 0, Richtung = 0; // Evtl. müssen diese Parameter übergeben werden. 

                Random RichtungZahl = new Random();
                Richtung = RichtungZahl.Next(1,4);

                if (Richtung == 1) // Richtung nach rechts (+X)
                {
                    XNeu = XAlt + 1;
                    YNeu = YAlt;
                }
                else if (Richtung == 2) // Richtung nach links (-X)
                {
                    XNeu = XAlt - 1;
                    YNeu = YAlt; 
                }
                else if (Richtung == 3) // Richtung nach oben (+Y)
                {
                    XNeu = XAlt;
                    YNeu = YAlt + 1; 
                }
                else if (Richtung == 4) // Richtung nach unten (-Y)
                {
                    XNeu = XAlt;
                    YNeu = YAlt - 1; 
                } // Ende der If - Bedingung

                posx = XNeu;   // Die "neuen Koordinaten" werden jetzt wieder auf die Position umgespeichert
                posy = YNeu;

                hide();        // Hier wird das Objekt auf der alten Position gelöscht
                show();        // Objekt wird an neuer Stelle gezeichnet  

                if (XNeu == XAlt)
                {
                    if (YNeu == YAlt)
                        collide(); // Hier wird überprüft ob es eine Überschreibung geben würde (dies wird auch dargestellt)  
                } 
            } // Ende der Move Methode 

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
