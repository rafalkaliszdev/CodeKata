using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata {
    class Program {
        static void Main(string[] args) {
        }
    }

    public static class Gaderypoluki {
        public static Tuple<string, int[]> Encode(string key, string encodedText) {
            key = key.ToLower(); //if case isn't changed, the key doesn't work
            
            if ((key.Length % 2) == 1) 
                throw new ArgumentException("The number of letters in the encryption key must be even.");
            
            for (var a = 0; a < key.Length; ++a) {
                for (var b = 0; b < key.Length; ++b) {
                    if (a == b) {
                        continue;
                    }
                    else if (key[a] == key[b]) {
                        throw new ArgumentException("The encryption key is invalid. Each letter in the entire key must be unique.");
                    }
                }
            }
            
            //initializes Set with pairs
            SortedSet<Tuple<char, char>> tempCollection = new SortedSet<Tuple<char, char>>();
            {
                char first, second;
                Tuple<char, char> pairedCharacters;
                for (var a = 0; a < key.Length; a = a + 2) {
                    first = key[a];
                    second = key[a + 1];

                    pairedCharacters = new Tuple<char, char>(first, second);
                    tempCollection.Add(pairedCharacters);
                }
            }

            var tupleCounter = 0;               //foreach tuple of set of six
            var changesCounter = 0;             //whenever change occurs, it taps the counter
            var array = new int[key.Length/2];  //array which stores number of replacements
            var tempString = new StringBuilder(encodedText); //obligatory because can't change a string's character value throught index

            //foreach below changes all occurrences mentioned in Encryption Key
            //so, for 12 letters (6 pairs) in Key, it will iterate 6x times
            foreach (Tuple<char, char> pair in tempCollection) {
                changesCounter = 0; //reset counter

                //for loop below goes throught a whole encodedText 
                //for 200 character string it will iterate 200x
                for (var a = 0; a < tempString.Length; ++a) {
                    if (tempString[a] == pair.Item1) {  //if there is 'g'...
                        tempString[a] = pair.Item2;     //...replace it with 'a'
                        ++changesCounter; //notices every replacementsorted set
                        continue;
                    }
                    if (tempString[a] == pair.Item2) {
                        tempString[a] = pair.Item1;
                        ++changesCounter; //notices every replacement
                        continue;
                    }
                }
                array[tupleCounter] = changesCounter; //if string is done, adds a number of replacements to array
                ++tupleCounter; //and goes to next Tuple
            }
            encodedText = tempString.ToString(); //back to normal string
            return new Tuple<string, int[]>(encodedText, array);
        }
    }
}
