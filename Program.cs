using System;
using System.Collections.Generic;

namespace PalindromeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //example sentences: The racecar is very fast!
            //Mr Owl ate my metal worm. Blah blah. Do geese see God? Was it a car or a cat I saw? Murder for a jar of red rum.
            string controller = "Yes";
            while(!controller.ToLower().Equals("no")){
                string paragraph;
                char letter;

                //get user input
                Console.WriteLine("Enter paragraph to check for palindromes: ");
                paragraph = Console.ReadLine();
                Console.WriteLine("\nEnter letter: ");
                letter = Console.ReadLine().ToCharArray()[0];

                //palindrome word and sentence count output
                Console.WriteLine("\nThere are {0} palindromes in this paragraph.",
                    PalindromeHelper.CountPalindromes(paragraph));
                Console.WriteLine("\nThere are {0} palindrome sentences in this paragraph",
                    PalindromeHelper.CountPalindromeSentences(paragraph));

                //unique word output
                Console.WriteLine("\nUnique words in this paragraph are:");
                foreach(KeyValuePair<string, int> word in PalindromeHelper.UniqueWords(paragraph)){
                    Console.WriteLine("Word: {0} Count: {1}", word.Key, word.Value);
                }

                //words containing letter
                Console.WriteLine("\nAll words containing letter {0}", letter);
                foreach(string s in PalindromeHelper.ContainsLetter(paragraph, letter)){
                    Console.WriteLine("Word: {0}", s);
                }
                
                Console.WriteLine("\nEnter Yes to continue or No to stop:");
                controller = Console.ReadLine();

            }
        }
    }
}
