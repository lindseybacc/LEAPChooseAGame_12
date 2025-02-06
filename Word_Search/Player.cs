using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Word_Search
{
    // this class will contain the name of player and the number of words left to find (as their "score")
    class Player
    {
        public string playerName { get; private set; }
        private int wordsLeft = 5; // hardcoded total of 5 words because we know this is how many words there are in word search



        // constructor to initialize the player name and the number of words left to solve
        public Player(string player)
        {
            playerName = player;
            wordsLeft = 5;
        }

        // method to get words left to solve
        public int getWordsLeft()
        {
           return wordsLeft;
        }

        // method to decrement the words left to solve
        public void decrementWordsLeft()
        {
            wordsLeft--;
        }

    }
}
