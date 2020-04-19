using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AllInOneMono
{
    class ShowCreditScene : DrawableGameComponent
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public ShowCreditScene(Game game) : base(game)
        {
        }

        //Sets Varaibles
        SpriteFont font;
        string credits = "Created by Talon Ernst for Game programming Final Assignemt \n\n" +
            "All images and sounds are from OpenGameArt.org \n\n" +
                " bullet class and shooting had help from https://www.youtube.com/user/Gamerdad81";


        /// <summary>
        /// Draw Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            //Draws the credits string
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.DrawString(font,
                        credits,
                        new Vector2((GraphicsDevice.Viewport.Width - font.MeasureString(credits).X) / 2,
                                    (GraphicsDevice.Viewport.Height - font.MeasureString(credits).Y) / 2),
                        Color.White);
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
