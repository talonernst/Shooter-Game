using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AllInOneMono
{
    public class Background : DrawableGameComponent
    {
        //Sets Variables
        Texture2D gameBackground;
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public Background(Game game) : base(game)
        {
        }

        /// <summary>
        /// Draw function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            //Draws the background
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.Draw(gameBackground,
                  new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
                  new Rectangle(1024, 768, 1920, 1080),
                  Color.White);
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Initalize Function
        /// </summary>
        public override void Initialize()
        {
            DrawOrder = 0;
            base.Initialize();
        }

        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Load Content Function
        /// </summary>
        protected override void LoadContent()
        {
            gameBackground = Game.Content.Load<Texture2D>("spaceBackground");
            base.LoadContent();
        }
    }
}
