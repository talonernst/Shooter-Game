using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOneMono
{
    class ShowHighScoreScene : DrawableGameComponent
    {
        //Sets variables
        SpriteFont font;

        string file = "Highscores.txt";

        HighScoresToFile highScores;

        int[] newHighScoresArray;       
        int[] placingsArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //Used to offset strings
        const int stringOffset = 100;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public ShowHighScoreScene(Game game) : base(game)
        {
            //Sets Variables
            highScores = Game.Services.GetService<HighScoresToFile>();
            newHighScoresArray = highScores.highScoresArray;
            if (File.Exists(file))
            {
                //Sets array to what is in the file
                int place = 0;
                var lines = File.ReadLines(file);
                foreach (var line in lines)
                {
                    string[] lineSplit;
                    lineSplit = line.Split(' ');
                    newHighScoresArray[place] = Convert.ToInt32(lineSplit[1]);
                    place++;
                    //Sorts array and reverses so that its in the right order
                    Array.Sort(newHighScoresArray);
                    Array.Reverse(newHighScoresArray);
                }
            }                  
        }

        /// <summary>
        /// Draw Function
        /// the 50, 130, and 35 are used to offset the strings being drawn
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();

            //Sets string builders for the placings and the actual scores
            StringBuilder scores = new StringBuilder();
            StringBuilder placings = new StringBuilder();

            //Draws the highscores label at the top
            sb.DrawString(font, "Highscores", new Vector2((Game.GraphicsDevice.Viewport.Width / 2 - 50),
                       (Game.GraphicsDevice.Viewport.Height / 2) - 130), Color.White);

            //For loop that lasts the length of the score array
            for(int i = 0; i < placingsArray.Length; i++)
            {
                //makes a new line on string builder with next variable in array, for the placings on the left
                placings.AppendLine(placingsArray[i].ToString());

                //Draws the placings on the screen
                sb.DrawString(font, placings, new Vector2((Game.GraphicsDevice.Viewport.Width / 2 - 35),
                 (Game.GraphicsDevice.Viewport.Height / 2) - stringOffset), Color.White);

                //makes a new line on string builder with next score in array.
                scores.AppendLine(newHighScoresArray[i].ToString());

                //Draws the scores on the screen
                sb.DrawString(font, scores, new Vector2((Game.GraphicsDevice.Viewport.Width / 2),
                    (Game.GraphicsDevice.Viewport.Height / 2) - stringOffset), Color.White);
            }                       
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Load Content Function
        /// </summary>
        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("Fonts/hilightFont");
            base.LoadContent();
        }
    }
}
