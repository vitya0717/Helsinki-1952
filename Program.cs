using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_infoismfor_17maj_fl
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("helsinki.txt");
            List<Olimpia> olimp = new List<Olimpia>();

            foreach (var item in sorok)
            {
                string[] darabok = item.Split(' ');
                olimp.Add(new Olimpia(int.Parse(darabok[0]), darabok[1], darabok[2], darabok[3]));
            }

            Console.WriteLine("3. feladat: \nPontszerző helyezések száma: {0}", olimp.Count);

            int arany = 0, ezüst = 0, bronz = 0;

            foreach (var item in olimp)
            {
                if (item.helyezes == 1)
                {
                    arany++;
                } else if (item.helyezes == 2)
                {
                    ezüst++;
                } else if (item.helyezes == 3)
                {
                    bronz++;
                }

            }
            Console.WriteLine("4.feladat:\nArany: {0}\nEzüst: {1}\nBronz: {2}\nÖsszesen: {3}", arany, ezüst, bronz, arany + ezüst + bronz);

            int ossz_pontszam = 0;
            foreach (var item in olimp)
            {
                if (item.helyezes == 1)
                {
                    ossz_pontszam += 7;
                }
                else if (item.helyezes == 2)
                {
                    ossz_pontszam += 5;
                }
                else if (item.helyezes == 3)
                {
                    ossz_pontszam += 4;
                }
                else if (item.helyezes == 4)
                {
                    ossz_pontszam += 3;
                }
                else if (item.helyezes == 5)
                {
                    ossz_pontszam += 2;
                }
                else if (item.helyezes == 6)
                {
                    ossz_pontszam += 1;
                }
            }
            Console.WriteLine("5.feladat:\nOlimpiai pontok száma: {0}", ossz_pontszam);


            /*Az  úszás  és  a  torna  sportágakban  világversenyeken  mindig  jól  szerepeltek  a  magyar 
            sportolók. Határozza meg és írja ki a minta szerint, hogy az 1952-es nyári olimpián melyik 
            sportágban  szereztek  több  érmet  a  sportolók!  Ha  az  érmek  száma  egyenlő,  akkor  az 
            „Egyenlő volt az érmek száma” felirat jelenjen meg! */

            Olimpia max = olimp[0];
            List<string> sportagak = new List<string>();
            Dictionary<string, int> versenyszamok_ermekkel = new Dictionary<string, int>();
            foreach (var item in olimp)
            {
                if (!sportagak.Contains(item.sportag))
                {
                    sportagak.Add(item.sportag);
                }
            }

            int ermek = 0;
            int ermek_seged = 0;


            for (int i = 1; i < olimp.Count; i++)
            {
                max = olimp[i];

                for (int j = 0; j < sportagak.Count; j++)
                {
                    if (max.sportag == sportagak[j])
                    {
                        ermek++;
                    }
                }
                if (ermek > ermek_seged)
                {
                    ermek_seged = ermek;
                    max = olimp[i];
                }
                ermek = 0;
            }

            Console.WriteLine("{0} sportágban szereztek több érmet.", max.sportag.Replace(max.sportag.Substring(0, 1), max.sportag.Substring(0, 1).ToUpper()));

            /*7. feladat: A  helsinki.txt  állományba  hibásan,  egybeírva  „kajakkenu”  került  a  kajak-kenu 
            sportág neve. Készítsen szöveges állományt helsinki2.txt néven, amelybe helyesen, 
            kötőjellel  kerül  a  sportág  neve!  Az  új  állomány  tartalmazzon  minden  helyezést  a 
            forrásállományból, a sportágak neve elé kerüljön be a megszerzett olimpiai pont is a minta 
            szerint! A sorokban az adatokat szóközzel válassza el egymástól!*/


            List<string> versenyszamok = new List<string>();
            for (int i = 0; i < versenyszamok.Count; i++)
            {
                if (!versenyszamok.Contains(olimp[i].versenyszam))
                {
                    versenyszamok.Add(olimp[i].versenyszam);
                }
            }

            int pontok = 0;

            foreach (var item in olimp)
            
            {
                if (item.helyezes == 1)
                {
                    pontok = 7;
                }
                else if (item.helyezes == 2)
                {
                    pontok = 5;
                }
                else if (item.helyezes == 3)
                {
                    pontok = 4;
                }
                else if (item.helyezes == 4)
                {
                    pontok = 3;
                }
                else if (item.helyezes == 5)
                {
                    pontok = 2;
                }
                else if (item.helyezes == 6)
                {
                    pontok = 1;
                } else
                {
                    pontok = 0;
                }
                if (item.sportag.Contains("kajakkenu"))
                {
                    string helyes = item.helyezes + " " + item.sportolo_vagy_csapat + " " + pontok + " " + "kajak-kenu" + " " + item.versenyszam;
                    File.AppendAllText("helsinki2.txt", helyes + "\n");

                }
                else
                {
                    string helyes = item.helyezes + " "+ item.sportolo_vagy_csapat + " "+pontok + " " + item.sportag + " " + item.versenyszam;
                    File.AppendAllText("helsinki2.txt", helyes + "\n");
                }

            }
    

           
            

            Console.ReadKey();
        }
    }
}
