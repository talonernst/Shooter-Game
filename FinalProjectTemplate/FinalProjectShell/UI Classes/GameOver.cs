using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOneMono
{
    class GameOver : DrawableGameComponent
    {
        //Sets Variables
        Player player;
        SpriteFont font;
        string gameOver = "GAME OVER, PRESS ESC TO RETURN TO MENU";

        //Default Constructor
        public GameOver(Game game) : base(game)
        {
            player = Game.Services.GetService<Player>();
        }

        /// <summary>
        /// Draw Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();

                //If players lives are 0, display game over screen
                if(player.intLivesLeft < 1)
                {              
                    sb.DrawString(font, gameOver, new Vector2((Game.GraphicsDevice.Viewport.Width - font.MeasureString(gameOver).X) / 2,
                    (Game.GraphicsDevice.Viewport.Height - font.MeasureString(gameOver).Y) / 2), Color.White);
                }
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Load Content Function
        /// </summary>
        protected override void LoadContent()
        {
            //Loads thing used in this class
            font = Game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }
    }
}
