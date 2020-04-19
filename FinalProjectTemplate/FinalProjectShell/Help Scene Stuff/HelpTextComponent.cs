using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace FinalProjectShell
{
    class HelpTextComponent : DrawableGameComponent
    {
        //Sets Variables
        SpriteFont font;
        string helpMessage = "This is the help page, to move in the game press the W A S D keys and to shoot press SPACE \n\n " +
            "The objective is to destroy as many meteors as you can before you run out of lives. \n\n" +
            "You get 100 points per meteor destroyed but they get faster as time goes on \n\n" +
            "your scores will be saved on the High Score tab and will be constantly updated as you get higher scores.";
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public HelpTextComponent(Game game) : base(game)
        {
            
        }

        /// <summary>
        /// Initalize Function
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Draw Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
           //Draws the Help string 
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();

            sb.Begin();

            sb.DrawString(font, helpMessage, new Vector2((Game.GraphicsDevice.Viewport.Width - font.MeasureString(helpMessage).X) / 2,
                   (Game.GraphicsDevice.Viewport.Height - font.MeasureString(helpMessage).Y) / 2), Color.White);
            
            sb.End();

            base.Draw(gameTime);
        }
        
        /// <summary>
        /// Load Content Function
        /// </summary>
        protected override void LoadContent()
        {
            //Loads content used in this class
            font = Game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }
    }
}
