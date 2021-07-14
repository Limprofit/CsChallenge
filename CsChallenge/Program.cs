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
                // Check for empty file
                if (new FileInfo(filename).Length == 0)
                {
                    Console.WriteLine("File {0} is empty, it will be skipped.", GetFileName(filename));
                    continue;
                }

                (Dictionary<int, int> dict, bool isFileCorrupted) = CreateFreqDict(filename);

                // Skip corrupted file
                if (isFileCorrupted)
                    continue;

                var pair = FindLeastFrequent(dict);

                if (pair.Item2 == 1)
                    Console.WriteLine("File: {0}, Number: {1}, Repeated: {2} time", GetFileName(filename), pair.Item1, pair.Item2);
                else
                    Console.WriteLine("File: {0}, Number: {1}, Repeated: {2} times", GetFileName(filename), pair.Item1, pair.Item2);
            }

            Console.ReadLine();
        }

        // Take a file, open it, and create a dictionary composed of the numbers as keys,
        // and how many times each number occurs as values. Return the dictionary and
        // a boolean indicating if there was an error opening the file
        public static (Dictionary<int, int>, bool) CreateFreqDict(string filename)
        {
            string line;
            int num;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            try
            {
                using StreamReader file = new StreamReader(filename);
            
                // Read every line until EOF
                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        num = Int32.Parse(line);
                        // TryGetValue has a slight edge over HasKey for trying to access unexisting keys.
                        // Since a dictionary is being created from scratch, TryGetValue is slightly more efficient.
                        if (dict.TryGetValue(num, out _))
                            dict[num] += 1;
                        else
                            dict.Add(num, 1);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert '{0}' in file {1}, line will be ignored.", line, GetFileName(filename));
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("'{0}' in file {1} is out of range of the Int32 type, it will be ignored.", line, GetFileName(filename));
                    }
                }

                file.Close();
                return (dict, false);
            }
            catch (IOException)
            {
                Console.WriteLine("Could not open file {0}.", filename);
                return (new Dictionary<int, int>(), true);
            }
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
    
        public static string GetFileName(string file)
        {
            return file[(file.LastIndexOf('\\') + 1)..];
        }
    }
}
