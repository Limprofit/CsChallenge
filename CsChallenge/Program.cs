using System;
using System.IO;
using System.Collections.Generic;

namespace CsChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\src";

            // Iterate over each file in the src folder
            foreach (string filename in Directory.GetFiles(path))
            {
                Dictionary<int, int> dict = CreateFreqDict(filename);

                var pair = FindLeastFrequent(dict);

                Console.WriteLine("File: {0}, Number: {1}, Repeated: {2} times", filename[(filename.LastIndexOf('\\') + 1)..], pair.Item1, pair.Item2);                
            }

            Console.ReadLine();
        }

        // Take a file, open it, and create a dictionary composed of the numbers as keys,
        // and how many times each number occurs as values. Return the dictionary and
        // a boolean indicating if there was an error opening the file
        public static Dictionary<int, int> CreateFreqDict(string filename)
        {
            string line;
            int num;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            StreamReader file = new StreamReader(filename);
            
            // Read every line until EOF
            while ((line = file.ReadLine()) != null)
            {
                num = Int32.Parse(line);

                // Add key to dictionary or increase count
                if (dict.ContainsKey(num))
                    dict[num] += 1;
                else
                    dict.Add(num, 1);
            }

            file.Close();
            return dict;
        }

        // Find the key in a dictionary with the lowest frequency count. 
        // If two keys have the same frequency count, return the smaller of the two keys.
        public static (int, int) FindLeastFrequent(Dictionary<int, int> dict)
        {
            int leastFrequentKey = 0;
            int frequency = 0;
            bool isValueInitialized = false;

            // Iterate over dictionary to find the fewest repeated number
            foreach (KeyValuePair<int, int> pair in dict)
            {
                if (!isValueInitialized)
                {
                    leastFrequentKey = pair.Key;
                    frequency = pair.Value;
                    isValueInitialized = true;
                    continue;
                }

                if (pair.Value < frequency)
                {
                    leastFrequentKey = pair.Key;
                    frequency = pair.Value;
                }
                else if (pair.Value == frequency)
                {
                    if (pair.Key < leastFrequentKey)
                    {
                        leastFrequentKey = pair.Key;
                        frequency = pair.Value;
                    }
                }
            }

            return (leastFrequentKey, frequency);
        }
    }
}
