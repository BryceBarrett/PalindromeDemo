using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PalindromeDemo
{
    static class PalindromeHelper
    {
        public static List<string> ContainsLetter(string paragraph, char findLetter){
            List<string> wordsWithLetter = new List<string>();
            
            string[] words = paragraph.Split(" ");

            foreach (var word in words)
            {
                string cleanWord = Regex.Replace(word, "[^a-zA-Z]", "").ToLower();
                if(cleanWord.Equals(" ") || wordsWithLetter.Contains(cleanWord)) continue;

                if(cleanWord.Contains(findLetter)) wordsWithLetter.Add(cleanWord);
            }

            return wordsWithLetter;
        }
        public static Dictionary<string, int> UniqueWords(string paragraph){
            Dictionary<string, int> uWords = new Dictionary<string, int>();

            string[] words = paragraph.Split(" ");

            foreach (var word in words)
            {
                string cleanWord = Regex.Replace(word, "[^a-zA-Z]", "").ToLower();
                if(cleanWord.Equals("")) continue;

                if(uWords.ContainsKey(cleanWord)){
                    uWords[cleanWord] += 1;
                }else{
                    uWords.Add(cleanWord, 1);
                }
            }

            return uWords;
        }

        public static int CountPalindromeSentences(string paragraph){
            string[] sentences = paragraph.Split(new char[]{'.', '!', '?'});

            int palCount = 0;
            foreach (var sentence in sentences)
            {
                if(IsPalindrome(sentence) == true) palCount++;
            }
            return palCount;
        }

        public static int CountPalindromes(string paragraph){
            string[] words = paragraph.Split(" ");

            int palCount = 0;
            foreach (var word in words)
            {
                if(IsPalindrome(word) == true) palCount++;
            }
            return palCount;
        }

        private static bool IsPalindrome(string word)
        {
            //remove all special chars/punctuation
            string cleanWord = Regex.Replace(word, "[^a-zA-Z]", "").ToLower();

            //one letter word can't be palindrome
            if(cleanWord.Length < 2) return false;

            //reverse word for comparison
            char[] reverseWord= cleanWord.ToCharArray();
            Array.Reverse(reverseWord);

            return cleanWord.Equals(new String(reverseWord)) ? true : false;
        }
    }
}