using System;
using System.IO;

namespace Course {
    class Program {
        static void Main(string[] args) {

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try {
                using (StreamReader sr = File.OpenText(path)) {

                    Dictionary<string, int> VotesCount = new Dictionary<string, int>();

                    while (!sr.EndOfStream) {

                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);

                        if (VotesCount.ContainsKey(name)) {
                            VotesCount[name] += votes;
                        }
                        else {
                            VotesCount[name] = votes;
                        }                        
                    }

                    foreach (var vote in VotesCount) {
                        Console.WriteLine(vote.Key + ": " + vote.Value);
                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}