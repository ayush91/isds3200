using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace MovieRecommendationSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Program test = new Program();

                Dictionary<int, Dictionary<int, int>> trainUserRatings = new Dictionary<int, Dictionary<int, int>>();
                string outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                string fileName = "train.text";
                string textFilePath = new Uri(Path.Combine(outputDir, "traindata\\" + fileName)).LocalPath;
                trainUserRatings = test.retrieveTrainRating(textFilePath);

                Dictionary<int, SortedDictionary<int, int>> testUserRatings = new Dictionary<int, SortedDictionary<int, int>>();

                fileName = "test5.txt";
                textFilePath = new Uri(Path.Combine(outputDir, "testdata\\" + fileName)).LocalPath;
                testUserRatings = test.retrieveTestRating(textFilePath);
                Console.WriteLine("Result for Test 5");
                test.cosineSimilarity(trainUserRatings, testUserRatings, 200, 0);
                test.pearsonCorelation(trainUserRatings, testUserRatings, 25, 0);
                test.adjustedCosineSimilarity(trainUserRatings, testUserRatings, 0, 0);

                fileName = "test10.txt";
                textFilePath = new Uri(Path.Combine(outputDir, "testdata\\" + fileName)).LocalPath;
                testUserRatings = test.retrieveTestRating(textFilePath);
                Console.WriteLine("Result for Test 10");
                test.cosineSimilarity(trainUserRatings, testUserRatings, 200, 100);
                test.pearsonCorelation(trainUserRatings, testUserRatings, 35, 100);
                test.adjustedCosineSimilarity(trainUserRatings, testUserRatings, 0, 100);

                fileName = "test20.txt";
                textFilePath = new Uri(Path.Combine(outputDir, "testdata\\" + fileName)).LocalPath;
                testUserRatings = test.retrieveTestRating(textFilePath);
                Console.WriteLine("Result for Test 20");
                test.cosineSimilarity(trainUserRatings, testUserRatings, 200, 200);
                test.pearsonCorelation(trainUserRatings, testUserRatings, 45, 200);
                test.adjustedCosineSimilarity(trainUserRatings, testUserRatings, 0, 200);

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write(e.StackTrace);
            }

        }

        public Dictionary<int, Dictionary<int, int>> retrieveTrainRating(string filePath)
        {
            Dictionary<int, Dictionary<int, int>> userRatings = new Dictionary<int, Dictionary<int, int>>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line = String.Empty;
                    int userCounter = 0;
                    int movieCounter = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Dictionary<int, int> movieRatings = new Dictionary<int, int>();
                        userCounter++;
                        string[] ratings = line.Split('\t');
                        foreach (string rating in ratings)
                        {
                            movieRatings.Add(++movieCounter, int.Parse(rating));
                        }

                        //Console.WriteLine("Training Data -> No of movies per user: " + movieRatings.Count);

                        userRatings.Add(userCounter, movieRatings);
                        movieCounter = 0;
                    }

                    //Console.WriteLine("Training Data -> No of users: " + userRatings.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return userRatings;
        }

        public Dictionary<int, Dictionary<int, int>> retrieveTrainRatingWithUserMean(string filePath)
        {
            Dictionary<int, Dictionary<int, int>> userRatings = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, ArrayList> userRatedOneMovie = new Dictionary<int, ArrayList>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line = String.Empty;
                    int userCounter = 0, movieCounter = 0, ratedMovieCounter, globalUserCounter = 0;
                    int totalRating, movieRating, globalRating = 0;
                    double meanRating = 0;
                    double gMean = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        ArrayList zeroRatingList = new ArrayList();
                        Dictionary<int, int> movieRatingsDict = new Dictionary<int, int>();
                        userCounter++;
                        string[] ratings = line.Split('\t');
                        totalRating = 0; ratedMovieCounter = 0;

                        foreach (string rating in ratings)
                        {
                            movieRating = int.Parse(rating);
                            ++movieCounter;

                            if (movieRating == 0)
                            {
                                zeroRatingList.Add(movieCounter);
                            }
                            else
                            {
                                totalRating += movieRating;
                                ratedMovieCounter++;
                            }
                            movieRatingsDict.Add(movieCounter, movieRating);
                        }

                        meanRating = (double)totalRating / ratedMovieCounter;
                        globalRating += totalRating;
                        globalUserCounter += ratedMovieCounter;

                        foreach (int movieId in zeroRatingList)
                        {
                            movieRatingsDict[movieId] = Convert.ToInt32(Math.Round(meanRating));
                        }

                        userRatings.Add(userCounter, movieRatingsDict);
                        movieCounter = 0;
                    }

                    gMean = (double)globalRating / globalUserCounter;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return userRatings;
        }

        public Dictionary<int, SortedDictionary<int, int>> retrieveTestRating(String filePath)
        {
            Dictionary<int, SortedDictionary<int, int>> testUserRatings = new Dictionary<int, SortedDictionary<int, int>>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = string.Empty;
                    int user = 0;
                    SortedDictionary<int, int> testMovieRatings = new SortedDictionary<int, int>();

                    // This loop reads till the end of the file.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Splits the tuple "U M R" into string array.
                        string[] umrValue = line.Split(' ');

                        // If the current user value differs from the new user value, add all the movie ratings 
                        // for current user into the dictionary. 
                        if (user != int.Parse(umrValue[0]))
                        {
                            if (testMovieRatings.Count != 0)
                            {
                                testUserRatings.Add(user, testMovieRatings);
                                //Console.WriteLine("Test Data -> No of movies per user: " + testMovieRatings.Count);
                                testMovieRatings = null;
                            }

                            user = int.Parse(umrValue[0]);
                            //Console.WriteLine("user value: " + user);

                            if (testMovieRatings == null)
                            {
                                testMovieRatings = new SortedDictionary<int, int>();
                            }
                        }

                        testMovieRatings.Add(int.Parse(umrValue[1]), int.Parse(umrValue[2]));
                    }

                    testUserRatings.Add(user, testMovieRatings);
                    //Console.WriteLine("Test Data -> No of users: " + testUserRatings.Count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }

            return testUserRatings;
        }

        #region User Based Collaborative Algos.

        public void cosineSimilarity(Dictionary<int, Dictionary<int, int>> trainingUserData, Dictionary<int, SortedDictionary<int, int>> testUserData, int kSimilarUsers, int addUserCount)
        {
            try
            {
                double similarityValue = 0, num = 0, den = 0;
                int innerProduct, vecLen1, vecLen2, coratedMovieCounter, swCounter;
                double predRatings = 0, totalSW, meanSW;
                double totalRating, meanRating = 0;
                const int m = 2;

                Dictionary<int, int> trainMovieRatings = null;

                SortedDictionary<int, int> testMovieRatings = null;

                // This dictionary holds values of test user and cosine similarity value with all training data users.
                Dictionary<int, Dictionary<int, double>> predRatingsPerUser = new Dictionary<int, Dictionary<int, double>>();

                Dictionary<int, double> tempSWValues = new Dictionary<int, double>();

                ArrayList nanMovieList = new ArrayList();

                int userID = 0, coratedMoviesLimit = 3;

                int type = 0;
                if (addUserCount == 0)
                {
                    type = 5;
                    coratedMoviesLimit = 2;

                }
                else if (addUserCount == 100)
                {
                    type = 10;
                    coratedMoviesLimit = 3;
                }
                else if (addUserCount == 200)
                {
                    type = 20;
                    coratedMoviesLimit = 4;
                }

                #region Loop to iterate through all test user.
                for (int i = 1; i <= testUserData.Count; i++)
                {
                    // Get test user id.
                    userID = trainingUserData.Count + addUserCount + i;

                    // Get single test user's movie ranting.
                    testMovieRatings = testUserData[userID];

                    // This dictionary holds values of train user and cosine similarity value with test user.
                    Dictionary<int, double> swValuesPerUser = new Dictionary<int, double>();

                    // 
                    List<int> unratedMoviesList = new List<int>();

                    //
                    List<int> ratedMoviesList = new List<int>();

                    #region This code differentiate between ranked and unranked movies.
                    totalRating = 0;
                    foreach (int key in testMovieRatings.Keys)
                    {
                        if (testMovieRatings[key] != 0)
                        {
                            ratedMoviesList.Add(key);
                            totalRating += testMovieRatings[key];
                        }
                        else
                        {
                            unratedMoviesList.Add(key);
                        }
                    }
                    #endregion

                    meanRating = totalRating / ratedMoviesList.Count;

                    for (int j = 1; j <= trainingUserData.Count; j++)
                    {
                        // Get single train user's movie ranting.
                        trainMovieRatings = trainingUserData[j];
                        coratedMovieCounter = retrieveCoratedMovieCount(ratedMoviesList, trainMovieRatings);

                        if (coratedMovieCounter < coratedMoviesLimit)
                        {
                            continue;
                        }

                        #region Below code calculates similarity weight between test user "i" and train user "j".
                        innerProduct = 0; vecLen1 = 0; vecLen2 = 0;
                        foreach (int movieId in ratedMoviesList)
                        {
                            if (trainMovieRatings[movieId] != 0)
                            {
                                innerProduct = innerProduct + (testMovieRatings[movieId] * trainMovieRatings[movieId]);
                                vecLen1 = vecLen1 + Convert.ToInt32(Math.Pow(testMovieRatings[movieId], 2));
                                vecLen2 = vecLen2 + Convert.ToInt32(Math.Pow(trainMovieRatings[movieId], 2));
                            }
                        }

                        if (vecLen1 == 0 || vecLen2 == 0)
                        {
                            continue;
                        }

                        den = Math.Sqrt(vecLen1) * Math.Sqrt(vecLen2);
                        //similarityValue = ((double)coratedMovieCounter / (coratedMovieCounter + m)) * (innerProduct / den);
                        similarityValue = (innerProduct / den);

                        if (Double.IsNaN(similarityValue))
                        {
                            continue;
                        }

                        swValuesPerUser.Add(j, similarityValue);
                        #endregion

                    }

                    // Sort the similarity weight per user to get most similar user at top.
                    swValuesPerUser = sort(swValuesPerUser);


                    totalSW = 0; meanSW = 0;
                    foreach (int key in swValuesPerUser.Keys)
                    {
                        totalSW += swValuesPerUser[key];
                    }

                    meanSW = totalSW / swValuesPerUser.Count;

                    tempSWValues.Clear();
                    foreach (int key in swValuesPerUser.Keys)
                    {
                        if (meanSW >= swValuesPerUser[key])
                        {
                            break;
                        }
                        tempSWValues.Add(key, swValuesPerUser[key]);
                    }
                    swValuesPerUser = tempSWValues;


                    // Below code selects most similar user, k = 10 
                    swCounter = 0;
                    tempSWValues.Clear();
                    foreach (int keys in swValuesPerUser.Keys)
                    {
                        if (swCounter >= kSimilarUsers)
                        {
                            break;
                        }
                        tempSWValues.Add(keys, swValuesPerUser[keys]);
                        swCounter++;
                    }

                    swValuesPerUser = tempSWValues;


                    #region Predict rating for test user.

                    Dictionary<int, double> predRatingsPerMovie = new Dictionary<int, double>();
                    foreach (int movieId in unratedMoviesList)
                    {

                        //Below code iterate thru k user whose similarity weight is high with current test user and predict the rating for movies.
                        num = 0; den = 0;
                        foreach (int trnUserId in swValuesPerUser.Keys)
                        {
                            trainMovieRatings = trainingUserData[trnUserId];

                            if (trainMovieRatings[movieId] != 0)
                            {
                                num = num + (swValuesPerUser[trnUserId] * trainMovieRatings[movieId]);
                                den = den + swValuesPerUser[trnUserId];
                            }
                        }
                        predRatings = num / den;
                        if (Double.IsNaN(predRatings))
                        {
                            predRatings = meanRating;
                        }

                        //predRatingsPerMovie.Add(movieId, Math.Round(predRatings));
                        predRatingsPerMovie.Add(movieId, predRatings);
                    }

                    predRatingsPerUser.Add(userID, predRatingsPerMovie);
                    #endregion
                }
                #endregion

                // Below statement call func to write predicted rating for unrated movies per test user.
                this.writeRatingsToFile(predRatingsPerUser, type);
            }
            catch (Exception e)
            {
                Console.WriteLine("CS_MESSAGE: " + e.Message);
                Console.WriteLine("CS_INNER EXCEPTION: " + e.Source);
            }
        }


        public void pearsonCorelation(Dictionary<int, Dictionary<int, int>> trainingUserData, Dictionary<int, SortedDictionary<int, int>> testUserData, int kSimilarUsers, int addUserCount)
        {
            try
            {
                #region Declare and Initialize Variables.

                // Stores the data retrieved from training data set.
                Dictionary<int, int> trainMovieRatings = null;

                // Stores the data retrieved from test data set.
                SortedDictionary<int, int> testMovieRatings = null;

                Dictionary<int, List<int>> ratedMoviesDict = new Dictionary<int, List<int>>();

                Dictionary<int, List<int>> unRatedMoviesDict = new Dictionary<int, List<int>>();

                Dictionary<int, Dictionary<int, double>> predRatingsPerUser = new Dictionary<int, Dictionary<int, double>>();

                Dictionary<int, double> tempPCCoeff = new Dictionary<int, double>();

                double num, den, predRating, innerProduct, vecLen1, vecLen2;

                int i, j, ratedMovieCounter, coratedMovieCounter = 0, pccCounter;

                double totalTrainRatings, totalTestRatings;

                Dictionary<int, double> avgRatingTestUser = new Dictionary<int, double>();

                double[,] avgRatingTrainUser = new double[100, 200];

                // This is variable for holding similarity weight.
                double pcCoeff = 0;

                const int m = 2;

                //Dictionary<int, double> iufTrainList = new Dictionary<int, double>();

                int userID = 0;
                #endregion

                for (i = 0; i < testUserData.Count; i++)
                {
                    userID = trainingUserData.Count + addUserCount + i + 1;

                    //Fetch movie list for a test user.
                    testMovieRatings = testUserData[userID];

                    // Stores test user's unrated movie list.
                    List<int> unratedMovieList = new List<int>();

                    // Stores test user's rated movie list.
                    List<int> ratedMovieList = new List<int>();

                    //iufTrainList = inverseUserFreq(trainingUserData);

                    #region This code differentiate between ranked and unranked movies.
                    totalTestRatings = 0;
                    foreach (int movieId in testMovieRatings.Keys)
                    {
                        if (testMovieRatings[movieId] != 0)
                        {
                            ratedMovieList.Add(movieId);
                            totalTestRatings += testMovieRatings[movieId];// *iufTrainList[movieId];
                        }
                        else
                        {
                            unratedMovieList.Add(movieId);
                        }
                    }
                    avgRatingTestUser.Add(userID, (double)totalTestRatings / ratedMovieList.Count);
                    #endregion

                    Dictionary<int, double> pcCoeffDict = new Dictionary<int, double>();
                    tempPCCoeff.Clear();
                    for (j = 1; j <= trainingUserData.Count; j++)
                    {
                        trainMovieRatings = trainingUserData[j];
                        coratedMovieCounter = retrieveCoratedMovieCount(ratedMovieList, trainMovieRatings);
                        if (coratedMovieCounter < 3)
                        {
                            continue;
                        }

                        #region Below code find the avg of test user rated movies which is also co-rated by train user.
                        totalTrainRatings = 0;
                        ratedMovieCounter = 0;
                        foreach (int movieId in ratedMovieList)
                        {
                            totalTrainRatings += trainMovieRatings[movieId]; // * iufTrainList[movieId];
                            ratedMovieCounter++;
                        }

                        avgRatingTrainUser[i, j - 1] = (double)totalTrainRatings / ratedMovieCounter;
                        #endregion

                        #region Below code calculates similarity weight between test user "i" and train user "j".
                        innerProduct = 0; vecLen1 = 0; vecLen2 = 0;
                        foreach (int movieID in ratedMovieList)
                        {

                            if (trainMovieRatings[movieID] == 0)
                            {
                                continue;
                            }
                            /*innerProduct = innerProduct +
                                    ((testMovieRatings[movieID] * iufTrainList[movieID]) - avgRatingTestUser[userID]) * ((trainMovieRatings[movieID] * iufTrainList[movieID]) - avgRatingTrainUser[i, j - 1]);*/
                            innerProduct = innerProduct +
        ((testMovieRatings[movieID] * 1) - avgRatingTestUser[userID]) * ((trainMovieRatings[movieID] * 1) - avgRatingTrainUser[i, j - 1]);
                            /*vecLen1 = vecLen1 + Math.Pow(((testMovieRatings[movieID] * iufTrainList[movieID]) - avgRatingTestUser[userID]), 2);
                            vecLen2 = vecLen2 + Math.Pow(((trainMovieRatings[movieID] * iufTrainList[movieID]) - avgRatingTrainUser[i, j - 1]), 2);*/
                            vecLen1 = vecLen1 + Math.Pow(((testMovieRatings[movieID] * 1) - avgRatingTestUser[userID]), 2);
                            vecLen2 = vecLen2 + Math.Pow(((trainMovieRatings[movieID] * 1) - avgRatingTrainUser[i, j - 1]), 2);

                        }

                        if (vecLen1 == 0 || vecLen2 == 0)
                        {
                            continue;
                        }

                        pcCoeff = innerProduct / (vecLen1 * vecLen2);
                        pcCoeff = ((double)coratedMovieCounter / (coratedMovieCounter + m)) * pcCoeff;

                        pcCoeffDict.Add(j, Math.Abs(pcCoeff));

                        pcCoeffDict = caseAmplification(pcCoeffDict);
                        tempPCCoeff.Add(j, pcCoeff);

                        #endregion
                    }

                    pcCoeffDict = sort(pcCoeffDict);

                    foreach (int userId in tempPCCoeff.Keys)
                    {
                        pcCoeffDict[userId] = tempPCCoeff[userId];
                    }


                    // Below code selects most similar user, k = kSimilarUsers 
                    pccCounter = 0;
                    tempPCCoeff.Clear();
                    foreach (int userId in pcCoeffDict.Keys)
                    {
                        if (pccCounter >= kSimilarUsers)
                        {
                            break;
                        }
                        tempPCCoeff.Add(userId, pcCoeffDict[userId]);
                        pccCounter++;
                    }

                    pcCoeffDict = tempPCCoeff;

                    Dictionary<int, double> predRatingsPerMovie = new Dictionary<int, double>();
                    //int firstMovie = 0;
                    foreach (int movieId in unratedMovieList)
                    {
                        /*if (firstMovie == 0)
                        {
                            firstMovie++;
                            continue;
                        }*/
                        num = 0; den = 0; predRating = 0;
                        foreach (int userId in pcCoeffDict.Keys)
                        {
                            if (trainMovieRatings[movieId] == 0)
                            {
                                continue;
                            }
                            trainMovieRatings = trainingUserData[userId];
                            num += pcCoeffDict[userId] * (trainMovieRatings[movieId] - avgRatingTrainUser[i, userId - 1]);
                            den += Math.Abs(pcCoeffDict[userId]);
                        }
                        //predRating = Math.Round(avgRatingTestUser[userID] + (num / den));
                        predRating = avgRatingTestUser[userID] + (num / den);
                        if (predRating > 5)
                        {
                            predRating = 5;
                        }
                        if (Double.IsNaN(predRating) || predRating == 0)
                        {
                            predRating = Math.Round(avgRatingTestUser[userID]);
                        }
                        if (predRating < 0)
                        {
                            predRating = 1;
                        }

                        predRatingsPerMovie.Add(movieId, predRating);
                    }

                    predRatingsPerUser.Add(userID, predRatingsPerMovie);
                }

                int type = 0;
                if (addUserCount == 0)
                {
                    type = 55;
                }
                else if (addUserCount == 100)
                {
                    type = 100;
                }
                else if (addUserCount == 200)
                {
                    type = 200;
                }

                this.writeRatingsToFile(predRatingsPerUser, type);
            }
            catch (Exception e)
            {
                Console.WriteLine("PC_MESSAGE: " + e.Message);
                Console.WriteLine("PC_INNER EXCEPTION: " + e.InnerException);
            }
        }

        #endregion

        #region Item Based Collaborative Algos.

        public void adjustedCosineSimilarity(Dictionary<int, Dictionary<int, int>> trainingUserData, Dictionary<int, SortedDictionary<int, int>> testUserData, int kSimilarUsers, int addUserCount)
        {
            try
            {
                // Stores the data retrieved from training data set.
                Dictionary<int, int> trainMovieRatings = null;

                // Stores the data retrieved from test data set.
                SortedDictionary<int, int> testMovieRatings = null;

                Dictionary<int, Dictionary<int, double>> predRatingsPerUser = new Dictionary<int, Dictionary<int, double>>();

                double num, den, predRating, innerProduct, vecLen1, vecLen2, adjSimWeight;

                int i, j, totalTrainRatings, totalTestRatings, ratedMovieCounter;

                Dictionary<int, double> avgRatingTestUser = new Dictionary<int, double>();

                Dictionary<int, double> avgRatingTrainUser = new Dictionary<int, double>();

                for (j = 1; j <= trainingUserData.Count; j++)
                {
                    trainMovieRatings = trainingUserData[j];
                    totalTrainRatings = 0; ratedMovieCounter = 0;
                    foreach (int movieId in trainMovieRatings.Keys)
                    {
                        if (trainMovieRatings[movieId] == 0)
                        {
                            continue;
                        }

                        totalTrainRatings += trainMovieRatings[movieId];
                        ratedMovieCounter++;
                    }
                    avgRatingTrainUser.Add(j, (double)totalTrainRatings / ratedMovieCounter);
                }

                int userID = 0;
                for (i = 1; i <= testUserData.Count; i++)
                {
                    userID = trainingUserData.Count + addUserCount + i;

                    //Fetch movie list for a test user.
                    testMovieRatings = testUserData[userID];

                    // Stores test user's unrated movie list.
                    List<int> unratedMovieList = new List<int>();

                    // Stores test user's rated movie list.
                    List<int> ratedMovieList = new List<int>();

                    #region This code differentiate between ranked and unranked movies. Also to calculate avg test user mean for rated movies.
                    totalTestRatings = 0; ratedMovieCounter = 0;
                    foreach (int movieId in testMovieRatings.Keys)
                    {
                        if (testMovieRatings[movieId] != 0)
                        {
                            ratedMovieList.Add(movieId);
                            totalTestRatings += testMovieRatings[movieId];
                            ratedMovieCounter++;
                        }
                        else
                        {
                            unratedMovieList.Add(movieId);
                        }
                    }
                    avgRatingTestUser.Add(userID, (double)totalTestRatings / ratedMovieCounter);
                    #endregion

                    Dictionary<int, Dictionary<int, double>> adjWUnRatedMovie = new Dictionary<int, Dictionary<int, double>>();
                    foreach (int urMovieId in unratedMovieList)
                    {
                        Dictionary<int, double> adjWRatedMovie = new Dictionary<int, double>();
                        foreach (int rMovieId in ratedMovieList)
                        {
                            innerProduct = 0; vecLen1 = 0; vecLen2 = 0; adjSimWeight = 0; den = 0;
                            for (j = 1; j <= trainingUserData.Count; j++)
                            {
                                trainMovieRatings = trainingUserData[j];
                                if (trainMovieRatings[rMovieId] == 0 || trainMovieRatings[urMovieId] == 0)
                                {
                                    continue;
                                }
                                /*
                                innerProduct += (trainMovieRatings[rMovieId] - avgRatingTrainUser[j]) * (trainMovieRatings[urMovieId] - avgRatingTrainUser[j]);
                                vecLen1 += Math.Pow((trainMovieRatings[urMovieId] - avgRatingTrainUser[j]), 2);
                                vecLen2 += Math.Pow((trainMovieRatings[urMovieId] - avgRatingTrainUser[j]), 2);
                                */

                                innerProduct += (trainMovieRatings[rMovieId] * trainMovieRatings[urMovieId]);
                                vecLen1 += Math.Pow(trainMovieRatings[rMovieId], 2);
                                vecLen2 += Math.Pow(trainMovieRatings[urMovieId], 2);
                            }

                            den = Math.Sqrt(vecLen1) * Math.Sqrt(vecLen2);
                            if (den == 0)
                            {
                                continue;
                            }
                            adjSimWeight = innerProduct / den;
                            adjWRatedMovie.Add(rMovieId, adjSimWeight);
                        }
                        //Sort the adjusted similartity weight for k similar movies.
                        //adjWRatedMovie = sort(adjWRatedMovie);

                        adjWUnRatedMovie.Add(urMovieId, adjWRatedMovie);
                    }

                    Dictionary<int, double> predRatingsPerMovie = new Dictionary<int, double>();
                    foreach (int urMovieId in unratedMovieList)
                    {
                        num = 0; den = 0; predRating = 0;
                        foreach (int rMovieId in adjWUnRatedMovie[urMovieId].Keys)
                        {

                            num += adjWUnRatedMovie[urMovieId][rMovieId] * testMovieRatings[rMovieId];
                            den += Math.Abs(adjWUnRatedMovie[urMovieId][rMovieId]);
                        }

                        //predRating = Math.Round(num / den);
                        predRating = num / den;
                        if (Double.IsNaN(predRating))
                        {
                            predRating = Math.Round(avgRatingTestUser[userID]);
                        }

                        predRatingsPerMovie.Add(urMovieId, predRating);
                    }

                    predRatingsPerUser.Add(userID, predRatingsPerMovie);
                }

                int type = 0;
                if (addUserCount == 0)
                {
                    type = 555;
                }
                else if (addUserCount == 100)
                {
                    type = 1000;
                }
                else if (addUserCount == 200)
                {
                    type = 2000;
                }

                this.writeRatingsToFile(predRatingsPerUser, type);
            }
            catch (Exception e)
            {
                Console.WriteLine("IB_MESSAGE: " + e.Message);
                Console.WriteLine("IB_INNER EXCEPTION: " + e.InnerException);
            }

        }
        #endregion

        public int retrieveCoratedMovieCount(List<int> movieList, Dictionary<int, int> trainingMovieData)
        {
            int totalRatings = 0;

            //Calculate total number of explicit ratings given to movies in training data.
            foreach (int movieId in movieList)
            {
                if (trainingMovieData[movieId] != 0)
                {
                    totalRatings++;
                }
            }

            return totalRatings;
        }

        public void writeRatingsToFile(Dictionary<int, Dictionary<int, double>> predRatingsPerUser, int type)
        {
            string folderName = @"C:\Temp";
            string filePath = folderName + @"\result" + type + ".txt";
            Dictionary<int, double> predRatingPerMovie = null;
            Directory.CreateDirectory(folderName);

            using (FileStream fs = File.Create(filePath))
            {
                foreach (int userId in predRatingsPerUser.Keys)
                {
                    predRatingPerMovie = predRatingsPerUser[userId];
                    string line = string.Empty;
                    foreach (int movieId in predRatingPerMovie.Keys)
                    {
                        line = userId + " " + movieId + " " + predRatingPerMovie[movieId] + "\n";
                        fs.Write(Encoding.ASCII.GetBytes(line), 0, line.Length);
                    }
                }
            }

        }

        public Dictionary<int, double> sort(Dictionary<int, double> smValues)
        {
            Dictionary<int, double> tempDict = new Dictionary<int, double>();
            foreach (int keys in smValues.OrderByDescending(dict => dict.Value).Select(dict => dict.Key))
            {
                tempDict.Add(keys, smValues[keys]);
            }

            return tempDict;
        }

        public Dictionary<int, double> inverseUserFreq(Dictionary<int, Dictionary<int, int>> userRatingDict)
        {
            double logBase = 0, iufPerMovie = 0;
            int ratedMovieCounter = 0, totalUsers = userRatingDict.Count, ratingValue = 0, totalUsersRatedMovie = 0;
            Dictionary<int, int> ratingPerMovies = null;
            Dictionary<int, int> countForMovies = new Dictionary<int, int>();
            Dictionary<int, double> iufList = new Dictionary<int, double>();

            foreach (int user in userRatingDict.Keys)
            {
                ratingPerMovies = userRatingDict[user];
                foreach (int movie in ratingPerMovies.Keys)
                {
                    ratedMovieCounter = 0;
                    if (ratingPerMovies[movie] != 0)
                    {
                        if (countForMovies.TryGetValue(movie, out ratedMovieCounter))
                        {
                            ratedMovieCounter++;
                            countForMovies[movie] = ratedMovieCounter;
                            continue;
                        }
                        else
                        {
                            ratedMovieCounter++;
                        }
                        countForMovies.Add(movie, ratedMovieCounter);
                    }
                }
            }

            //logBase = ratedMovieCounter / ratingPerMovies.Count;
            logBase = 2;

            foreach (int movieId in countForMovies.Keys)
            {

                if (countForMovies[movieId] == 0)
                {
                    totalUsersRatedMovie = 1;
                }
                totalUsersRatedMovie = countForMovies[movieId];
                iufPerMovie = Math.Log(200 / totalUsersRatedMovie, logBase);
                iufList.Add(movieId, iufPerMovie);
            }

            return iufList;
        }

        public Dictionary<int, double> caseAmplification(Dictionary<int, double> simWeight)
        {

            double gamma = 2.5;
            Dictionary<int, double> caSimWeight = new Dictionary<int, double>();

            foreach (int userId in simWeight.Keys)
            {
                caSimWeight.Add(userId, Math.Pow(simWeight[userId], gamma));
            }

            return caSimWeight;
        }

        public double jaccardSimilarity(Dictionary<int, int> trainMovieRatingDict, List<int> ratedMovieList)
        {
            double jSValue = 0;
            int trainMovieCounter = 0;
            double num = 0, den = 0;

            foreach (int movieId in trainMovieRatingDict.Keys)
            {
                if (trainMovieRatingDict[movieId] != 0)
                {
                    trainMovieCounter++;
                }
            }

            num = retrieveCoratedMovieCount(ratedMovieList, trainMovieRatingDict);
            den = trainMovieCounter + ratedMovieList.Count;
            jSValue = num / den;

            return jSValue;
        }
    }
}
