using System;
using System.IO;
using System.Collections.Generic;

namespace CsChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"src\");
            string line;
            int num;
            int minKey = 0;
            int minVal = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            // Iterate over every file in the src folder
            foreach (string filename in Directory.GetFiles(path))
            {
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

                    // Storing key and val as a starting points for min looking
                    minKey = num;
                    minVal = dict[minKey];
                }

                // Iterate over dictionary to find the fewest repeated number
                foreach (KeyValuePair<int, int> pair in dict)
                {
                    if (pair.Value < minVal)
                    {
                        minKey = pair.Key;
                        minVal = pair.Value;
                    }
                    else if (pair.Value == minVal)
                    {
                        if (pair.Key < minKey)
                        {
                            minKey = pair.Key;
                            minVal = pair.Value;
                        }
                    }
                }

                Console.WriteLine("File: {0}, Number: {1}, Repeated: {2} times", filename[(filename.LastIndexOf('\\') + 1)..], minKey, minVal);

                // Cleanup
                file.Close();
                dict.Clear();
            }

            Console.ReadLine();
        }
    }
}
