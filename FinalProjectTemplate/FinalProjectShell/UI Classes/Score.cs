using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AllInOneMono
{
    public class Score : DrawableGameComponent
    {
        //Sets Variables
        SpriteFont font;
        public int gameScore = 0;
        

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public Score(Game game) : base(game)
        {
            Game.Services.AddService<Score>(this);
        }
       
        /// <summary>
        /// Draw Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            //Draws the score
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.DrawString(font,"Score: " + gameScore.ToString(), new Vector2(Game.GraphicsDevice.Viewport.Width - font.MeasureString(gameScore.ToString()).X - 50, 0), Color.White);
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Load Content Function
        /// </summary>
        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }

        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
