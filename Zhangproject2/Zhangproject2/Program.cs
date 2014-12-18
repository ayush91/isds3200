using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Zhangproject2
{
    class Program
    {
        Dictionary<int, Dictionary<int, double>> Recommendations;
        public Program()
        {
            
        }
        static void Main(string[] args)
        {
            
            Program new1 = new Program();
            new1.firststep();
            new1.task2();
            new1.MeanSquareError();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            new1.firststep();

            new1.secondstep();
            new1.MeanSquareError();
            Console.ReadLine();
            



          
        }



        public void firststep()  // to create the unknownrating file with only user)id and movie id
        {
            int user_id;
            int movieid;
            int rating;
            int timestamp;
            string line;
            try
            {


                string filename = "u1.test";
                string filename2 = "u1.test.unknownrating";

                StreamReader File1 = new StreamReader(filename);
                StreamWriter File2 = new StreamWriter(filename2);

                while ((line = File1.ReadLine()) != null)
                {


                    string[] line2 = line.Split('\t');
                    user_id = int.Parse(line2[0]);
                    movieid = int.Parse(line2[1]);
                    rating = int.Parse(line2[2]);
                    timestamp = int.Parse(line2[3]);

                    File2.WriteLine(user_id + "\t" + movieid);
                }
                File2.Close();
            }
            catch( FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            
                
        }

        public void secondstep()  // to predict the rating
        {
            int file1userid;
            int file1movieid;
            int file1ratingid;
            int timestamp;
            int file2userid;
            int file2movie;
            int i = 0;
            string line;
            string line3;
            try
            {


                string filename = "u1.base";
                string filename2 = "u1.test.unknownrating";
                string filename3 = "u1.test.prediction";

                StreamReader File1 = new StreamReader(filename);
                StreamReader File2 = new StreamReader(filename2);
                StreamWriter writing = new StreamWriter(filename3);
                Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();
                Dictionary<int,double> dict2 = new Dictionary<int,double>();
                double totalrating = 0;
                int totalratingnumber = 0;
                while ((line = File1.ReadLine()) != null)
                {


                    string[] line2 = line.Split('\t');
                    file1userid = int.Parse(line2[0]);
                    file1movieid = int.Parse(line2[1]);
                    file1ratingid = int.Parse(line2[2]);
                    timestamp = int.Parse(line2[3]);

                    if (!dict.ContainsKey(file1userid))
                    {
                        dict.Add(file1userid, new Dictionary<int,int>());
                    }

                    dict[file1userid][file1movieid] = file1ratingid;
                }
                for (int movies = 0; movies < 1682; movies++ )
                {
                    for( int users = 0; users < 943; users++)
                    {
                        if ( !dict[users+1].ContainsKey(movies+1))
                        {

                        }
                        else
                        {
                            totalrating += dict[users + 1][movies + 1];
                            totalratingnumber++;
                        }
                    }
                    dict2.Add(movies, totalrating / totalratingnumber);
                    
                }
                double value = 0;
                
                    while ((line3 = File2.ReadLine()) != null)
                    {
                        string[] line4 = line3.Split('\t');
                        file2userid = int.Parse(line4[0]);
                        file2movie = int.Parse(line4[1]);

                        if ( dict2.ContainsKey(file2movie))
                        {
                            value = dict2[file2movie];
                            writing.WriteLine(file2userid + "\t" + file2movie + "\t" + value);
                        }
                        else
                        {
                            writing.WriteLine(file2userid + "\t" + file2movie + "\t" + -1);
                        }
                    }
                    writing.Close();

                
            }
            catch ( FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }


        public void task2()
        {
            int u1baseuserid;
            int u1basemovieid;
            int u1baseratingid;
            int u1basetimestamp;
            int u1testunknownuserid;
            int u1testunknownmovieid;
            string line;
            string line1;
            Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, int> unknownratingdict = new Dictionary<int, int>();
            string filename = "u1.base";
            string filename2 = "u1.test.unknownrating";
            string filename3 = "u1.test.prediction";
            StreamReader File1 = new StreamReader(filename);
            StreamReader File2 = new StreamReader(filename2);
            StreamWriter File3 = new StreamWriter(filename3);
            int counter = 0;
            int firstusersecondmovie = 3;
            double a, b, c = 0;
            try
            {
                while ((line = File1.ReadLine()) != null)
                {
                    string[] line2 = line.Split('\t');
                    u1baseuserid = int.Parse(line2[0]);
                    u1basemovieid = int.Parse(line2[1]);
                    u1baseratingid = int.Parse(line2[2]);
                    u1basetimestamp = int.Parse(line2[3]);

                    if (!dict.ContainsKey(u1baseuserid))
                    {
                        dict.Add(u1baseuserid, new Dictionary<int, int>());
                    }
                    dict[u1baseuserid][u1basemovieid] = u1baseratingid;


                }



                int seconduserfinally;
                while ((line1 = File2.ReadLine()) != null)
                {
                    string[] line3 = line1.Split('\t');
                    u1testunknownuserid = int.Parse(line3[0]);
                    u1testunknownmovieid = int.Parse(line3[1]);
                    counter = u1testunknownmovieid + 1;
                    int number;
                    bool red = true; 
                    int another = 0;
                        while (red == true)
                        {
                            if (!dict[u1testunknownuserid].ContainsKey(counter))
                            {
                                if (counter > 1683)
                                {
                                counter = 1;
                                red = false;
                                }
                                if ( another > 2000)
                                {
                                    red = false;
                                    number = 3;
                                }
                            

                            }
                            another++;
                            counter++;
                        }
                        counter--;
                        

                        if (dict[u1testunknownuserid].ContainsKey(counter))
                        {



                            firstusersecondmovie = dict[u1testunknownuserid][counter];
                        }
                        else
                        {
                            firstusersecondmovie = 1;
                        }

                        int seconduser = u1testunknownuserid + 1;
                        if (seconduser > 943)
                        {
                            seconduser = 1;
                        }
                        seconduserfinally = 1;
                        if (red == true)
                        {
                            bool check = true;
                            while (check == true)
                            {

                                int k = seconduser;
                                int timer = 0;

                                while (k < 943 && check == true)
                                {

                                    if (dict[k].ContainsKey(u1testunknownmovieid))
                                    {
                                        seconduserfinally = k;
                                        check = false;

                                    }

                                    if (timer > 2000)
                                    {
                                        check = false;
                                    }
                                    if (k > 944)
                                    {
                                        k = 1;
                                    }
                                    k++;
                                    timer++;
                                }
                            }
                        }
                    
                    if (red == false)
                    {
                        a = 8;
                        b = 1;
                        b = b - a;
                        b = Math.Abs(a);
                        c = b * 0.5;

                    }
                    else
                    {


                        a = dict[seconduserfinally][u1testunknownmovieid];
                        b = dict[u1testunknownuserid][counter];
                        b = b - a;
                        b = Math.Abs(a);
                        c = b + firstusersecondmovie;
                    }
                        File3.WriteLine(u1testunknownuserid + "\t" + u1testunknownmovieid + "\t" + c);
                        

                    

                   
                   

                }
                File3.Close();

            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Task 2 is not working right");
            }

        }
        public void MeanSquareError()
        {
            int u1testuserid;
            int u1testmovieid;
            int u1testratingid;
            int u1testtimestamp;
            int u1predictionuserid;
            int u1predictionmovieid;
            double u1predictionratingid;
            double divider = 0;
            double totaldifference;
            double predictionminususer = 0;
            double comparea;
            double compareb;
            string line;
            string line1;
            double mse;
            double mfc;
            double mfctest;
            double timer = 0;
            Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, Dictionary<int, double>> dict2 = new Dictionary<int, Dictionary<int, double>>();
            List<int> testing = new List<int>();
            string filename = "u1.test";
            string filename2 = "u1.test.prediction";
            StreamReader File1 = new StreamReader(filename);
            StreamReader File2 = new StreamReader(filename2);

            try
            {
                while ((line = File1.ReadLine()) != null)
                {
                    string[] line2 = line.Split('\t');
                    u1testuserid = int.Parse(line2[0]);
                    u1testmovieid = int.Parse(line2[1]);
                    u1testratingid = int.Parse(line2[2]);
                    u1testtimestamp = int.Parse(line2[3]);

                    if (!dict.ContainsKey(u1testuserid))
                    {
                        dict.Add(u1testuserid, new Dictionary<int, int>());
                    }

                    dict[u1testuserid][u1testmovieid] = u1testratingid;
                    if (!testing.Contains(u1testmovieid))
                    {
                        testing.Add(u1testmovieid);
                    }
                }
                while ((line1 = File2.ReadLine()) != null)
                {
                    string[] line3 = line1.Split('\t');
                    u1predictionuserid = int.Parse(line3[0]);
                    u1predictionmovieid = int.Parse(line3[1]);
                    u1predictionratingid = double.Parse(line3[2]);

                    if (!dict2.ContainsKey(u1predictionuserid))
                    {
                        dict2.Add(u1predictionuserid, new Dictionary<int, double>());
                    }
                    dict2[u1predictionuserid][u1predictionmovieid] = u1predictionratingid;
                }
                int users2 = dict.Keys.Max();
                int movies2 = testing.Max();
                

                // WHYYYYYYY getting an error in if statement
            // fInally it works
                for (int movies = 1; movies < movies2; movies++)
                {
                    for (int users = 1; users < users2; users++)
                    {
                        if (dict.ContainsKey(users))
                        {
                            if (!dict[users].ContainsKey(movies))
                            {

                            }
                            else
                            {
                                
                                comparea = dict[users][movies];
                                
                                compareb = dict2[users][movies];
                                totaldifference = compareb - comparea;
                                mfctest = Math.Abs(totaldifference);
                                if ( mfctest >= 2)
                                {
                                    timer++;
                                }
                                predictionminususer += totaldifference * totaldifference;
                                divider++;

                            }
                        }


                    }
                }
                
                    mse = predictionminususer / divider;
                    mse = 1 / mse;
                    mfc =  timer / divider;
                    Console.WriteLine(" MSE is " + mse);
                    Console.WriteLine(" MFC is " + mfc);

                
            }
            catch (FileNotFoundException ex)
            {

                Console.WriteLine(" Input wrong file look Mean Square Error");
            }



        }





    }
}