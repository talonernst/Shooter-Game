using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AllInOneMono
{
    /// <summary>
    /// This class controls everything for the ship, collision, drawing, updating 
    /// </summary>
    class Player : DrawableGameComponent
    {        
        //Sets variables
        public int intLivesLeft = 3, bulletSpeed = 10;    
        SpriteFont font;        
        public Texture2D gameShip;
        private const float PLAYER_MOVEMENT = 5f;    
        public Vector2 shipPosition;    
        public Rectangle shipRect;
        private KeyboardState currentState, previousState;          
        const int BULLET_SIZE = 12;
                
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public Player(Game game) : base(game)
        {         
            Game.Services.AddService<Player>(this);            
        }

        /// <summary>
        /// Draw Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {          
            //Sets spritebatch and draws the ship
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();      
            sb.Begin();

            //Draws the ship
            sb.Draw(gameShip, shipPosition, Color.White);
            
            //Draws the lives counter
            sb.DrawString(font, "Lives left: " + intLivesLeft, Vector2.Zero, Color.White);
                      
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Initalize Function
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
       
        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Does different things depending on what button was hit as long as the player has at least one life.
            if (intLivesLeft > 0)
            {
                currentState = Keyboard.GetState();
                if (currentState.IsKeyDown(Keys.Space) && previousState.IsKeyUp(Keys.Space))
                {
                    ShootBullets();
                }            
                if (currentState.IsKeyDown(Keys.W))
                {
                    shipPosition.Y -= PLAYER_MOVEMENT;
                }
                if (currentState.IsKeyDown(Keys.S))
                {
                    shipPosition.Y += PLAYER_MOVEMENT;
                }
                if (currentState.IsKeyDown(Keys.A))
                {
                    shipPosition.X -= PLAYER_MOVEMENT;
                }
                if (currentState.IsKeyDown(Keys.D))
                {
                    shipPosition.X += PLAYER_MOVEMENT;
                }

                //Sets the previous key as the current key
                previousState = currentState;
            }
            
            //Makes sure ship cannot go off screen
            shipPosition.Y = MathHelper.Clamp(shipPosition.Y, 0, Game.GraphicsDevice.Viewport.Height - gameShip.Height);
            shipPosition.X = MathHelper.Clamp(shipPosition.X, 0, Game.GraphicsDevice.Viewport.Width - gameShip.Width);

            //Sets shipRect variable which will be used for the ships collision
            shipRect = gameShip.Bounds;
            shipRect.Location = shipPosition.ToPoint();   
            
            base.Update(gameTime);
        }

        /// <summary>
        /// Load Content Function
        /// </summary>
        protected override void LoadContent()
        {
            //Loads the things used in this class     
            font = Game.Content.Load<SpriteFont>("font");
            gameShip = Game.Content.Load<Texture2D>("ship");

            //Sets the default position of the ship for when the game begins
            int xPosition = Game.GraphicsDevice.Viewport.Width / 2 - gameShip.Width / 2;
            int yPosition = Game.GraphicsDevice.Viewport.Height - gameShip.Height * 2;
            shipPosition = new Vector2(xPosition, yPosition);     
            
            base.LoadContent();
        }

        /// <summary>
        /// Unload Content Function
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }


        /// <summary>
        /// Function used to generate the location of a bullet and send it to the bullet class
        /// the 25 and 10 are used to spawn the bullet at the front of the ship instead of in the middle of it
        /// <summary>     
        public void ShootBullets()
        {       
            Vector2 position = new Vector2(shipPosition.X + 25 - BULLET_SIZE / 2, shipPosition.Y + 10);
            Game.Components.Add(new Bullet(Game, position));                                               
        }
    }
}


