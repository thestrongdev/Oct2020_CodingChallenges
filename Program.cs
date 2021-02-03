using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Markup;

namespace CodingChallenges
{
    class Program
    {
        static void Main(string[] args)
        {

            // var tempList = new List<int>(someArray);
            // return tempList.ToArray();
            // char[] newChar = theString.ToCharArray();
            //List<char> distinct = new List<char>();
            // string joined = string.Join<string>("", newString);

            
            //Write a function that accepts a string and an n and returns a cipher by rolling each character forward (n > 0) or backward (n < 0) n times.
            //Note: Think of the letters as a connected loop, so rolling a backwards once will yield z, and rolling z forward once will yield a. 
            //If you roll 26 times in either direction, you should end up back where you started.
      

            static string rollCipher (string toRoll, int n)
            {
                toRoll = toRoll.ToLower();
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                int toRollStartIndex = alphabet.IndexOf(toRoll);
                int toRollLength = toRoll.Length;
                int toRollFinalIndex = toRollLength + toRollStartIndex-1;
                int tilEnd = 25 - toRollFinalIndex;
                int indexOfNewAlph = n + toRollFinalIndex;
                double indexofNewAlphDub = Convert.ToDouble(indexOfNewAlph);
                double stringRep = 0;
                
                if (n>tilEnd)
                {
                    stringRep = indexOfNewAlph / 26;//need to make this round up!!


                    for (int i = 0; i < stringRep; i++)
                    {
                        alphabet += alphabet;
                    }
                }
              
                //how far off are we from the end of string?


                if (alphabet.Contains(toRoll) && n > 0 && n<tilEnd)
                {
                    toRoll = alphabet.Substring(toRollStartIndex + n, toRoll.Length);
                }
                else if (alphabet.Contains(toRoll) && n < 0 && (Math.Abs(n)) < toRollStartIndex)
                {
                    toRoll = alphabet.Substring(toRollStartIndex + n, toRoll.Length);
                } 

                return toRoll;
            }

            string test = "lMnoP";
            string test1 = "wxyZ";

            Console.WriteLine(rollCipher(test, 3)); //should output opqrs

            Console.WriteLine(rollCipher(test, -3)); //should output ijklm

            Console.WriteLine(rollCipher(test, 26)); //should output lmnop

            Console.WriteLine(rollCipher(test, -26)); //should output lmnop

            Console.WriteLine(rollCipher(test1, 2)); //should output yzab

            //write a method that returns a string containing 1s and 0s based on the string
            //if any characters in the string are 1s, change to 0 and vice versa.
            //if not a 1 or 0, ignore
            //string returned should ONLY be multiples of 8, if not remove the numbers in excess
            //I had to use the char encodings to pull what a 0 or 1 was in a char array

            /*
            static string ateBinary(string randochars)
            {
                char[] newChar = randochars.ToCharArray();

                int countAte = newChar.Length / 8;

                List<string> newString = new List<string>();

                for (int i=0; i<countAte*8; i++)
                {
                    if (newChar[i]==49)
                    {
                        newString.Add("0");
                    }
                    else if (newChar[i] ==48)
                    {
                        newString.Add("1");
                    }
                    else
                    {
                        newString.Add(newChar[i].ToString());
                    }
                }

                string joined = string.Join<string>("", newString);

                return joined;

            }

            string test = "00hey1837whats90100";

            Console.WriteLine(ateBinary(test)); //expect output of 11hey0837whats91
            */

            //write a function that returns the number of sock pairs he has
            //a sock pair has two of the same letter
            //socks are represented in an unordered sequence (string)
            //we can have multiple pairs of the same sock

            /*
            static int sockPairs(string socks)
            {

                char[] newChar = socks.ToCharArray();
                int count = 0;
                int matches = 0;
                List<char> distinct = new List<char>();

                //how can we only count the matches once?
                //if we get an i that we've gotten in the past, ignore it...put all distinct  i's in a different list

                for (int i = 0; i<newChar.Length-1; i++)
                {

                    for (int j=0; j<newChar.Length-1; j++)
                    {
                        
                        if (newChar[i] == newChar[j] && !(distinct.Contains(newChar[i])))
                        {
                            count++;

                            if (count>1 && count%2 == 0)
                            {
                                matches++;
                            }
                        }
                    }
                    distinct.Add(newChar[i]);
                    count = 0;
                }
                return matches;
            }

            string test = "huthitcogiccbaubhc"; //hh, tt, cc, ii, bb, cc, uu

            Console.WriteLine(sockPairs(test)); //expect output of 7
            */

            //function that takes an array of names and returns an array where only the 
            //first letter of each name is capitalized

            /*
            static string[] capArray(string[] someArray)
            {
                var tempList = new List<string>(someArray);

                for (int i =0; i<tempList.Count; i++)
                {
                    tempList[i] = tempList[i].Replace(tempList[i], tempList[i].Substring(0, 1).ToUpper() + tempList[i].Substring(1, tempList[i].Length - 1).ToLower());
                }

                return tempList.ToArray();
            }

            string[] anArray = { "heLLO", "hOw", "candaCE", "hAtE", "JOB" };

            string[] newArray = capArray(anArray);

            foreach (string item in newArray)
            {
                Console.WriteLine(item);
            }
            */

            //function that takes in a string and returns 
            //string with first and last characters switched EXCEPT WHEN...
            //1) length of string is less than two - return "Incompatible"
            //2) argument is not a string - return "Incompatible"
            //3) the first and last characters are the same, return "Two's a pair"

            //should've utilized first/last/substring string functions!!

            /*

                static string theSwitch (string theString)
                {
                    char[] newChar = theString.ToCharArray();

                    char last = newChar[newChar.Length - 1];
                    char first = newChar[0];
                    string output = "";

                    if ((last == first) && (newChar.Length>1))
                    {
                        output = "Two's a pair";
                    }
                    else if (newChar.Length < 2)
                    {
                        output = "Incompatible";
                    }
                    else
                    {

                        newChar[0] = last;
                        newChar[newChar.Length - 1] = first;
                        output = string.Join("", newChar);

                    }

                    return output;

                }

                string test = "Candace";
                string test1 = "c";
                string test3 = "candycanc";

                Console.WriteLine(theSwitch(test));
                Console.WriteLine(theSwitch(test1));
                Console.WriteLine(theSwitch(test3));
              */

            //takes array and outputs the biggest number of the following:
            //sum of positive integers, 
            //absolute value of the sum of negative integers, 
            //total number of 0s

            /*
            static int majorSum (int [] someArray)
            {
                int negSum = 0;
                int posSum = 0;
                int zeroCnt = 0;

                foreach (int item in someArray)
                {
                    if (item<0)
                    {
                        negSum += item;
                    } else if (item == 0)
                    {
                        zeroCnt += 1;
                    }
                    else if (item>0)
                    {
                        posSum += item;
                    }
                }

                negSum *= -1;

                int[] newArray = { negSum, posSum, zeroCnt };

                return newArray.Max();
            }

            int[] myArray = { -1, -5, 0, 0, 0, 0, 5, 6, 7, -19 };

            Console.WriteLine(majorSum(myArray));
            */

            //output a list of numbers after the smallest number is removed

            /*
            static int [] removeSmallest (int [] someArray)
            {
                Array.Sort(someArray);
                var tempList = new List<int>(someArray);
                tempList.RemoveAt(0);
                return tempList.ToArray();

            }
            */


            //create a function that takes a string, removes all "special" 
            //characters (!, @, #, $, %, ^, &, \, *, (, )) and returns new string
            //non alphanumeric numbers allowed are dashes, underscores and spaces

            /*
            string someString = "#$ laksjf--_;208(*&#$9'\'( %%";


            static string removeChar (string userString)
            {
                
                char[] newChar = userString.ToCharArray();
                string newString = "";

                foreach (char item in newChar)
                { 

                    if (char.IsLetterOrDigit(item) || char.IsWhiteSpace(item) || 
                        item.Equals("-") || item.Equals("_")) { 

                        newString += item;
                    }
                }

                return newString;
            }
            */

            /*char[] newChar = someString.ToCharArray();

            foreach (char item in newChar)
            {
                Console.WriteLine(item);
            }
            */

            //Create a function that takes an array of numbers and 
            //returns the sum of the two lowest positive numbers.

            /*
            int[] random = { -4, 10, 4, 87, -45, 1, 8, 10 };

            static int twoSmall (int [] someArray)
            {
                Array.Sort(someArray);

                int sumSmall = 0;

                int secLoopCount = 0;

                foreach (int item in someArray)
                {
                    if (item > 0 && secLoopCount<2)
                    {
                        secLoopCount += 1;
                        sumSmall += item;
                    }
                }

                return sumSmall;

                //return someArray.Where(x => x >= 0).OrderBy(x => x).Take(2).Sum();
            }

            Console.WriteLine(twoSmall(random));
            */

            //you can also use the sort function but remember it sorts in ascending order
            //you'll have to use a reverse method to 

            //create a function that takes an array of positive and negative numbers. Return an array where the first element 
            //is the count of positive numbers and the second element is the sum of negative numbers.

            /*
            int[] someArray = { -3, 4, -5, 3, 5, 7, 8, 9, -3, -6, -10 }; //6 positives, 5 negatives

            static int [] countPosNeg (int[] thisArray)
            {
                int posCount=0;
                int negCount=0;
                int[] countArray = new int [2];

                foreach (int item in thisArray)
                {
                    if (item < 0)
                    {
                        negCount += 1;
                    }
                    else
                    {
                        posCount += 1;
                    }
                }

                countArray[0] = posCount;
                countArray[1] = negCount;

                return countArray;
            }

            int[] newArray = countPosNeg(someArray);

            foreach (int item in newArray)
            {
                Console.WriteLine(item);
            }
            */

            //Is a word an isogram? An isogram is a word that has no repeating letters, consecutive or nonconsecutive.
            //Create a function that takes a string and returns either true or false depending on whether or not it's an "isogram".

            /*static bool isogram (string userInput)
            {
                userInput = userInput.ToLower();

                char[] characters = userInput.ToCharArray();

                List<string> isIsogram = new List<string>();

                string charToString;

                foreach (char item in characters)
                {
                    charToString = item.ToString();
                    isIsogram.Add(charToString);
                }

                List<string> distinct = isIsogram.Distinct().ToList();
                
                string newWord = string.Join("", distinct);
                bool iso;

                if (newWord == userInput)
                {
                    iso = true;
                }
                else
                {
                    iso = false;
                }
                return iso;    
            }

            Console.WriteLine("Please input a word to determine if it's an isogram:");
            string userInput = Console.ReadLine();

            Console.WriteLine(isogram(userInput));
            */


            //Given a string, create a function to reverse the case. All lower-cased letters should be upper-cased, and vice versa.

            /*
            Console.WriteLine("Please enter a string of letters");
            string userInput = Console.ReadLine();

            static string reverse (string someString)
            {
                char[] characters = someString.ToCharArray();
                List<string> revChar = new List<string>();
                string revString = "";

                foreach (char item in characters){

                    string newChar = item.ToString();

                    if (char.IsLower(item))
                    {
                        newChar = newChar.ToUpper();
                    }
                    else if (char.IsUpper(item))
                    {
                        newChar = newChar.ToLower();
                    }

                    revChar.Add(newChar);
                    revString = String.Join("", revChar);
                }

                return revString;
            }

            string revTest = reverse(userInput);
            Console.WriteLine(revTest);
            */




        }
    }
}
