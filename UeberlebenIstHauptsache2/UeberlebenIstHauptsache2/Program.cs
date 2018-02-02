using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UeberlebenIstHauptsache2
{
    class Program
    {
            static void Main(string[] args)
            {
                string LevelOrdner = Directory.GetCurrentDirectory() + @"\Level"; //optionaller LEvelordner hier einfügen
                string App = @"C:\Users\Win7\AndroidStudioProjects\UeberlebenIstHAUPTsache2"; //Hier Directory zur App hinzufügen 
                string FesteOrdner = Directory.GetCurrentDirectory()+@"\Festetxt";
                int LevelZahl = 1;
                bool aa = true;
                while (aa)
                {
                    Console.WriteLine("Welches Level?");
                    try
                    {
                        LevelZahl = Convert.ToInt32(Console.ReadLine());
                        if (LevelZahl > -1 && LevelZahl < 17) aa = false;
                    }
                    catch (Exception e) { Console.Clear(); }
                }
                string pathSkizze = LevelOrdner + @"\Level" + LevelZahl + ".txt";
                int wegC = -1, npcC, swordC, shildC, keyC, ZielC, StartC;
                npcC = swordC = shildC = keyC = ZielC = StartC = 0;

                int[] xitem = new int[5];//0-Schwert, 1-Schild, 2-Ziel, 3-Start, 4-Key
                int[] yitem = new int[5];
                int[] smallxitem = new int[5];
                int[] smallyitem = new int[5];
                int[] largexitem = new int[5];
                int[] largeyitem = new int[5];
                int[] xLargexitem = new int[5];
                int[] xLargeyitem = new int[5];
                string[] listeA = File.ReadAllLines(pathSkizze);
                int al = listeA.Length;
                int bl = listeA[0].Length;
                int[] xcords = new int[al * bl];
                int[] ycords = new int[al * bl];
                int[] smallxcords = new int[al * bl];
                int[] smallycords = new int[al * bl];
                int[] largexcords = new int[al * bl];
                int[] largeycords = new int[al * bl];
                int[] xLargexcords = new int[al * bl];
                int[] xLargeycords = new int[al * bl];
                int[] xNPC = new int[al * bl - 2];
                int[] yNPC = new int[al * bl - 2];
                int[] smallxNPC = new int[al * bl - 2];
                int[] smallyNPC = new int[al * bl - 2];
                int[] largexNPC = new int[al * bl - 2];
                int[] largeyNPC = new int[al * bl - 2];
                int[] xLargexNPC = new int[al * bl - 2];
                int[] xLargeyNPC = new int[al * bl - 2];
                int laenge = 10, xcord, ycord, smallxcord, smallycord, largexcord, largeycord, xLargexcord, xLargeycord;
                int xVerschiebung = 550 / bl, yVerschiebung = 800 / al, smallxVerschiebung = 140 / bl, smallyVerschiebung = 200 / al, largexVerschiebung = 960 / bl, largeyVerschiebung = 140 / al, xLargexVerschiebung = 550 / bl, xLargeyVerschiebung = 800 / al;
                for (int Reihe = 0; Reihe < laenge; Reihe++)
                {
                    xcord = 20 + (yVerschiebung * Reihe);           //Berechnung von x koordinate
                    smallxcord = (smallyVerschiebung * Reihe);
                    largexcord = 20 + (largeyVerschiebung * Reihe);
                    xLargexcord = 20 + (xLargeyVerschiebung * Reihe);

                    ycord = 0;
                    for (int Punkt = 0; Punkt < laenge; Punkt++)
                    {
                        ycord = 20 + (xVerschiebung * Punkt);   //Berechnung der y koordinate
                        smallycord = (smallxVerschiebung * Punkt);
                        largeycord = 20 + (largexVerschiebung * Punkt);
                        xLargeycord = 20 + (xLargexVerschiebung * Punkt);
                        switch (listeA[Reihe][Punkt])
                        {////0-Schwert, 1-Schild, 2-Ziel, 3-Start, 4-Key
                            case 'X':
                                wegC++; xcords[wegC] = xcord; ycords[wegC] = ycord;
                                smallxcords[wegC] = smallxcord; smallycords[wegC] = smallycord;
                                largexcords[wegC] = largexcord; largeycords[wegC] = largeycord; break;//wegC
                            case 'K':
                                wegC++; xcords[wegC] = xcord; ycords[wegC] = ycord; xitem[4] = xcord; yitem[4] = ycord; keyC++;
                                smallxcords[wegC] = smallxcord; smallycords[wegC] = smallycord; smallxitem[4] = smallxcord; smallyitem[4] = smallycord;
                                largexcords[wegC] = largexcord; largeycords[wegC] = largeycord; largexitem[4] = largexcord; largeyitem[4] = largeycord; break;//Schlüssel
                            case 'N':
                                wegC++; xcords[wegC] = xcord; ycords[wegC] = ycord; xNPC[npcC] = xcord; yNPC[npcC] = ycord;
                                smallxcords[wegC] = smallxcord; smallycords[wegC] = smallycord; smallxNPC[npcC] = smallxcord; smallyNPC[npcC] = smallycord;
                                largexcords[wegC] = largexcord; largeycords[wegC] = largeycord; largexNPC[npcC] = largexcord; largeyNPC[npcC++] = largeycord; break;//NPC
                            case 'W':
                                wegC++; xcords[wegC] = xcord; ycords[wegC] = ycord; xitem[0] = xcord; yitem[0] = ycord; swordC++;
                                smallxcords[wegC] = smallxcord; smallycords[wegC] = smallycord; smallxitem[0] = smallxcord; smallyitem[0] = smallycord;
                                largexcords[wegC] = largexcord; largeycords[wegC] = largeycord; largexitem[0] = largexcord; largeyitem[0] = largeycord; break;//Schwert
                            case 'D':
                                wegC++; xcords[wegC] = xcord; ycords[wegC] = ycord; xitem[1] = xcord; yitem[1] = ycord; shildC++;
                                smallxcords[wegC] = smallxcord; smallycords[wegC] = smallycord; smallxitem[1] = smallxcord; smallyitem[1] = smallycord;
                                largexcords[wegC] = largexcord; largeycords[wegC] = largeycord; largexitem[1] = largexcord; largeyitem[1] = largeycord; break;//Schild
                            case 'Z':
                                wegC++; xcords[wegC] = xcord; ycords[wegC] = ycord; xitem[2] = xcord; yitem[2] = ycord; ZielC++;
                                smallxcords[wegC] = smallxcord; smallycords[wegC] = smallycord; smallxitem[2] = smallxcord; smallyitem[2] = smallycord;
                                largexcords[wegC] = largexcord; largeycords[wegC] = largeycord; largexitem[2] = largexcord; largeyitem[2] = largeycord; break;//Ziel
                            case 'S':
                                wegC++; xcords[wegC] = xcord; ycords[wegC] = ycord; xitem[3] = xcord; yitem[3] = ycord; StartC++;
                                smallxcords[wegC] = smallxcord; smallycords[wegC] = smallycord; smallxitem[3] = smallxcord; smallyitem[3] = smallycord;
                                largexcords[wegC] = largexcord; largeycords[wegC] = largeycord; largexitem[3] = largexcord; largeyitem[3] = largeycord; break;//Start
                        }
                    }
                }
                wegC++;
                //xml-Datei
                string pathXml = App + @"\app\src\main\res\layout\activity_level" + LevelZahl + ".xml";
                string pathvXml1 = FesteOrdner + @"\xml1.txt";
                string pathvXml2 = FesteOrdner + @"\xml2.txt";
                string pathvXml3 = FesteOrdner + @"\xml3.txt";

                string[] xml1 = File.ReadAllLines(pathvXml1);
                string[] xml2 = File.ReadAllLines(pathvXml2);
                string[] xml3 = File.ReadAllLines(pathvXml3);
                string[] xml = new string[xml1.Length + xml2.Length + xml3.Length + wegC + npcC + swordC + shildC + ZielC + StartC + keyC + 3 + 2];

                int xmlC = 0;
                for (int f = 0; f < xml1.Length; f++)
                    xml[xmlC++] = xml1[f];
                xml[xmlC++] = "tools:context = " + '"' + "com.example.win7.ueberlebenisthauptsache.Level" + LevelZahl + '"' + " >";
                for (int f = 0; f < xml2.Length; f++)
                    xml[xmlC++] = xml2[f];
                xml[xmlC++] = "android:background=" + '"' + "@drawable/mauer" + LevelZahl + '"' + ">";
                for (int f = 0; f < wegC; f++)
                    xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/Weg" + f + '"' + "\n " +
                        "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                        "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                        "android:layout_marginLeft=" + '"' + ycords[f] + "px" + '"' + "\n" +
                           "android:layout_marginStart=" + '"' + ycords[f] + "px" + '"' + "\n" +
                         "android:layout_marginTop=" + '"' + xcords[f] + "px" + '"' + "\n" +
                        "android:contentDescription=" + '"' + "@string/Weg" + '"' + "\n" +
                        "android:src=" + '"' + "@drawable/weg" + LevelZahl + '"' + "/>";
                for (int f = 0; f < npcC; f++)
                    xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/NPC" + f + '"' + "\n" +
                        "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                        "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                        "android:layout_marginLeft=" + '"' + yNPC[f] + "px" + '"' + "\n" +
                         "android:layout_marginStart=" + '"' + yNPC[f] + "px" + '"' + "\n" +
                         "android:layout_marginTop=" + '"' + xNPC[f] + "px" + '"' + "\n" +
                        "android:contentDescription=" + '"' + "@string/NPC" + '"' + "\n" +
                        "android:src=" + '"' + "@drawable/npc_front" + '"' + "/>";
                //0-Schwert, 1-Schild, 2-Ziel, 3-Start, 4-Key
                if (swordC != 0)
                    xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/Sword" + '"' + "\n" +
                            "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                            "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                            "android:layout_marginLeft=" + '"' + yitem[0] + "px" + '"' + "\n" +
                            "android:layout_marginStart=" + '"' + yitem[0] + "px" + '"' + "\n" +
                             "android:layout_marginTop=" + '"' + xitem[0] + "px" + '"' + "\n" +
                            "android:contentDescription=" + '"' + "@string/Sword" + '"' + "\n" +
                            "android:src=" + '"' + "@drawable/sword" + '"' + "/>";
                if (shildC != 0)
                    xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/Shild" + '"' + "\n" +
                           "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                            "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                            "android:layout_marginLeft=" + '"' + yitem[1] + "px" + '"' + "\n" +
                             "android:layout_marginStart=" + '"' + yitem[1] + "px" + '"' + "\n" +
                             "android:layout_marginTop=" + '"' + xitem[1] + "px" + '"' + "\n" +
                            "android:contentDescription=" + '"' + "@string/Shild" + '"' + "\n" +
                           "android:src=" + '"' + "@drawable/shild" + '"' + "/>";
                if (keyC != 0)
                    xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/Door" + '"' + "\n" +
                            "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                            "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                            "android:layout_marginLeft=" + '"' + yitem[2] + "px" + '"' + "\n" +
                             "android:layout_marginStart=" + '"' + yitem[2] + "px" + '"' + "\n" +
                             "android:layout_marginTop=" + '"' + xitem[2] + "px" + '"' + "\n" +
                            "android:contentDescription=" + '"' + "@string/Ziel" + '"' + "\n" +
                           "android:src=" + '"' + "@drawable/door_closed" + '"' + "/>";
                else
                    xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/Door" + '"' + "\n" +
                        "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                        "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                        "android:layout_marginLeft=" + '"' + yitem[2] + "px" + '"' + "\n" +
                         "android:layout_marginStart=" + '"' + yitem[2] + "px" + '"' + "\n" +
                         "android:layout_marginTop=" + '"' + xitem[2] + "px" + '"' + "\n" +
                        "android:contentDescription=" + '"' + "@string/Ziel" + '"' + "\n" +
                       "android:src=" + '"' + "@drawable/door_open" + '"' + "/>";
                xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/Figur" + '"' + "\n" +
                       "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                        "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                        "android:layout_marginLeft=" + '"' + yitem[3] + "px" + '"' + "\n" +
                         "android:layout_marginStart=" + '"' + yitem[3] + "px" + '"' + "\n" +
                         "android:layout_marginTop=" + '"' + xitem[3] + "px" + '"' + "\n" +
                        "android:contentDescription=" + '"' + "@string/Figur" + '"' + "\n" +
                       "android:src=" + '"' + "@drawable/figur_front" + '"' + "/>";
                if (keyC != 0)
                    xml[xmlC++] = "<ImageView\n android:id=" + '"' + "@+id/Key" + '"' + "\n" +
                           "android:layout_width=" + '"' + xVerschiebung + "px" + '"' + "\n " +
                            "android:layout_height=" + '"' + yVerschiebung + "px" + '"' + "\n " +
                            "android:layout_marginLeft=" + '"' + yitem[4] + "px" + '"' + "\n" +
                             "android:layout_marginStart=" + '"' + yitem[4] + "px" + '"' + "\n" +
                             "android:layout_marginTop=" + '"' + xitem[4] + "px" + '"' + "\n" +
                            "android:contentDescription=" + '"' + "@string/Key" + '"' + "\n" +
                           "android:src=" + '"' + "@drawable/key" + '"' + "/>";
                for (int f = 0; f < xml3.Length; f++)
                    xml[xmlC++] = xml3[f];
                xml[xmlC++] = "";








                //Java-Datei

                string pathJava = App + @"\app\src\main\java\com\example\win7\ueberlebenisthauptsache\" + "Level" + LevelZahl + ".java";
                string PathJava1 = FesteOrdner + @"\vor.txt";
                string PathJava2 = FesteOrdner + @"\vor1.txt";
                string PathJava3 = FesteOrdner + @"\vor2.txt";

                string[] vJava1 = File.ReadAllLines(PathJava1);
                string[] vJava2 = File.ReadAllLines(PathJava2);
                string[] vJava3 = File.ReadAllLines(PathJava3);
                int GegIndex = 1;
                //0-Schwert, 1-Schild, 2-Ziel, 3-Start, 4-Key
                string[] Java = new string[vJava1.Length + 1 + vJava2.Length + 1 + vJava3.Length + 7 + wegC + npcC + swordC * 2 + shildC * 2 + keyC * 2 + 1 + 1];
                int JavaC = 0;
                for (int g = 0; g < vJava1.Length; g++)
                    Java[JavaC++] = vJava1[g];
                Java[JavaC++] = "public class " + "Level" + LevelZahl + " extends AppCompatActivity {";
                for (int g = 0; g < vJava2.Length; g++)
                    Java[JavaC++] = vJava2[g];
                Java[JavaC++] = " setContentView(R.layout.activity_" + ("Level" + LevelZahl).ToLower() + ");";
                for (int g = 0; g < vJava3.Length; g++)
                    Java[JavaC++] = vJava3[g];
                Java[JavaC++] = "new Speichern(this).setLaengeX(" + xVerschiebung + ");";
                Java[JavaC++] = "new Speichern(this).setLaengeY(" + yVerschiebung + ");";
                Java[JavaC++] = "Weg=new ImageView[" + wegC + "];";
                Java[JavaC++] = "int [] GegIndex=new int[" + (swordC + shildC + keyC + 1) + "];";
                Java[JavaC++] = "Gegenstande[2]=(ImageView)findViewById(R.id.Door);";
                Java[JavaC++] = "GegIndex[0]=2;";
                Java[JavaC++] = "npc=new ImageView[" + npcC + "];";
                for (int g = 0; g < wegC; g++)
                    Java[JavaC++] = "Weg[" + g + "]=(ImageView)findViewById(R.id.Weg" + g + ");";
                if (swordC == 1)
                {
                    Java[JavaC++] = "Gegenstande[0]=(ImageView)findViewById(R.id.Sword);";
                    Java[JavaC++] = "GegIndex[" + (GegIndex++) + "]=0;";
                }
                if (shildC == 1)
                {
                    Java[JavaC++] = "Gegenstande[1]=(ImageView)findViewById(R.id.Shild);";
                    Java[JavaC++] = "GegIndex[" + (GegIndex++) + "]=1;";
                }
                if (keyC == 1)
                {
                    Java[JavaC++] = "Gegenstande[4]=(ImageView)findViewById(R.id.Key);";
                    Java[JavaC++] = "GegIndex[" + (GegIndex++) + "]=4;";
                }
                for (int g = 0; g < npcC; g++)
                    Java[JavaC++] = "npc[" + g + "]=(ImageView)findViewById(R.id.NPC" + g + ");";
                Java[JavaC++] = "gegenstand=new Gegenstand(Gegenstande,GegIndex,(ImageView)findViewById(R.id.keyanzeige),this," + LevelZahl + ",mediaPlayer);";
                Java[JavaC++] = "}}";

                if (swordC < 2 && npcC != 0 && shildC < 2 && keyC < 2 && ZielC == 1 && StartC == 1)
                {
                    File.Delete(pathXml);
                    File.Delete(pathJava);
                    File.WriteAllLines(pathXml, xml);
                    File.WriteAllLines(pathJava, Java);
                }

            }
        }
    }

