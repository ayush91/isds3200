using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace ZhangProject
{
    class Program
    {

       // public class MultiDimDictList : Dictionary<int, List<int>> { }
       
        static void Main(string[] args)
        {   int user_id;
            int movieid;
            int rating;
            int timestamp;
            int[ , ] overall = new int[100000,4];
            string line;
            //List<int>[] list2 = new List<int>[943];
          //  MultiDimDictList myDicList = new MultiDimDictList();
            List<int[]>[] newlist = new List<int[]>[943];

            int i = 0;
            int j = 0;
            int comparea;
            int compareb = 0;
            int comparekey = 0;
            int findrating;
            int num = 1;
           
            NewClass234 anotherclass = new NewClass234();
            string filename = "u1.base.txt";
            string filename2 = "unknownrating.txt";
            
            StreamReader File1 = new StreamReader(filename);
            StreamWriter File2 = new StreamWriter(filename2);
            try
            {



                while ((line = File1.ReadLine()) != null)
                {


                    string[] line2 = line.Split('\t');
                    user_id = int.Parse(line2[0]);
                    movieid = int.Parse(line2[1]);
                    rating = int.Parse(line2[2]);
                    timestamp = int.Parse(line2[3]);
                    // user_id = anotherclass.converting(user_id);
                    //  movieid = anotherclass.converting(movieid);
                    //  rating = anotherclass.converting(rating);
                    // timestamp = anotherclass.converting(timestamp);

                    //Console.WriteLine(user_id[i] + " " + movieid[i] + " " + rating[i] + " " + timestamp[i]);
                    overall[i, j] = user_id;
                    overall[i, j + 1] = movieid;
                    overall[i, j + 2] = rating;
                    overall[i, j + 3] = timestamp;
                    File2.WriteLine(overall[i, j] + "\t" + overall[i, j + 1] + "\t" + overall[i, j + 2]);
                    //list2[i].Add(movieid);


                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File couldn't be found");
            }

            

            
           //for (i = 0; i < 943; i++ )
           // {
            //   bool comparison = false;
            //    num = 1;
             //   int k = 0;

              

               // for (int k = 1; k <= 1683; k++)
               // {
                    
                    
                    
                 //   if ( overall(i)(k))
                  //  {
                   //     bool fullcompare = false;
                    //    int a = i + 1;

                    //    if ( i == 943)
                     //   {
                           // a = 1;
                      //  }
                       // while( fullcompare == false)
                       // {
                            
                       //     if(myDicList[a].Contains(k))
                         //   {
                           //     fullcompare = true;
                                
                             //   comparekey = k;
                              //  compareb = a;
                                
                                
                            //}
                            //a++;
                            //if ( a == 944)
                            //{
                               // a = 1;
                            //}
                       // }
                        //comparea = i;
                        //findrating = (comparekey - compareb) + comparea;

                       // File2.WriteLine(i + "\t" + comparekey + "\t" + findrating);
                        
                    //}
                    //else
                    //{
                   //     File2.WriteLine(overall[i, j] + "\t" + overall[i, j + 1] + "\t" + overall[i, j + 2]);
                    //}
                }
               
            }


         //  File2.Close();








              //  Console.ReadLine();
            


        }

     
      
   // }

