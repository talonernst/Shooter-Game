using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOneMono
{
    class HighScoresToFile : GameComponent
    {
        //Sets Variables
        string file = "Highscores.txt";
        Player player;
        Score score;
        public int[] highScoresArray = new int[10];
        bool sortArrayBool = true;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public HighScoresToFile(Game game) : base(game)
        {
            //Adds Services
            Game.Services.AddService<HighScoresToFile>(this);
            player = Game.Services.GetService<Player>();
            score = Game.Services.GetService<Score>();

            //Sets Varables
            int place = 0;
          
                if (File.Exists(file))
                {
                    var lines = File.ReadLines(file);
                    //Refills the array from what was loaded in the file so that no highscores are lost
                    foreach (var line in lines)
                    {
                        string[] lineSplit;
                        lineSplit = line.Split(' ');
                        highScoresArray[place] = Convert.ToInt32(lineSplit[1]);
                        place++;
                    }
                    //Sorts and reverses array so that its in correct order
                    Array.Sort(highScoresArray);
                    Array.Reverse(highScoresArray);              
                }           
        }

        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Checks if players has 0 lives/game is over then makes sure file exists.
            
                if (!File.Exists(file))
                {
                    File.Create(file);
                }
            if(player.intLivesLeft == 0)
            {
                if (sortArrayBool == true)
                {
                    //Checks if the score is greater then the last record in the array, 
                    //and replaces it if it is because if it is then that spot
                    // would be overwritten anyways
                    if (highScoresArray[9] <= score.gameScore)
                    {
                        highScoresArray[9] = score.gameScore;
                    }
                    Array.Sort(highScoresArray);
                    Array.Reverse(highScoresArray);
                    //Writes high score array to file
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        int place = 1;
                        for (int i = 0; i < highScoresArray.Length; i++)
                        {
                            sw.WriteLine($"{place}: {highScoresArray[i]}");
                            place++;
                        }
                    }
                    sortArrayBool = false;
                }
            }                         
                base.Update(gameTime);          
        }
    }
}
