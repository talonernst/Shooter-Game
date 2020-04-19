using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using FinalProjectShell;

namespace AllInOneMono
{
    class Meteor : DrawableGameComponent
    {
        //Sets variables
        Score score;
        SoundEffect explosionSound;
        Player player;
        Texture2D Meteor1, Meteor2; 
        Vector2 rockPosition;
        Rectangle rockRect;
        bool flameSwitch, canLoseLives = true;
        double timeSinceFlameSwap;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="location"></param>
        public Meteor(Game game, Vector2 location) : base(game)
        {
            score = Game.Services.GetService<Score>();
            player = Game.Services.GetService<Player>();
            rockPosition = location;
        }

        /// <summary>
        /// Sets the bounds for each meteor.
        /// </summary>
        public Rectangle Bounds
        { 
            get
            {
                Rectangle bounds = Meteor1.Bounds;
                bounds.Location = rockPosition.ToPoint();
                return bounds;
            }
        }
        
        /// <summary>
        /// Draw function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {            
            //Counter to switch the image of the meteor
            timeSinceFlameSwap += gameTime.ElapsedGameTime.TotalSeconds;
            
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();

            //Changes the image of the meteor depending on the timer
            sb.Draw(flameSwitch ? Meteor1 : Meteor2, rockPosition, Color.White);
            if (timeSinceFlameSwap > 0.3)
            {
                flameSwitch = !flameSwitch;
                timeSinceFlameSwap = 0.0;
            }

            //If the player hits 0 lives, dispose of ship and remove meteors.
            if(player.intLivesLeft < 1)
            {                                            
                player.gameShip.Dispose();
                Game.Components.Remove(this);                           
            }      
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Initalize function
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Update function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {         
            //Sets the hitbox for the meteor
            rockRect = Meteor1.Bounds;
            rockRect.Location = rockPosition.ToPoint();

            //Updates meteor position
            rockPosition.Y += 1.0f;

            //Checks for player colliding with meteor
            if (player.shipRect.Intersects(rockRect) && player.intLivesLeft > 0)
            {
                 //if player has 0 lives sets bool so that lives counter cannot go below 0.                 
                if (player.intLivesLeft < 1)
                {                  
                    canLoseLives = false;                   
                }
                //If the player can still lose lives, removes one life.
                if (canLoseLives == true)
                {
                    player.intLivesLeft--;                  
                }
                //When player still has lives, moves player to starting position.
                if (player.intLivesLeft > 0)
                {
                    player.shipPosition.X = Game.GraphicsDevice.Viewport.Width / 2 - player.gameShip.Width / 2;
                    player.shipPosition.Y = Game.GraphicsDevice.Viewport.Height - player.gameShip.Height * 2;
                }
            }
          
            //Despawns meteor when it goes off screen
            if (rockPosition.Y > Game.GraphicsDevice.Viewport.Height)
            {
                Game.Components.Remove(this);
            }
          
            base.Update(gameTime);
        }

        /// <summary>
        /// Load content function
        /// </summary>
        protected override void LoadContent()
        {
            //Loads things used in this class
            explosionSound = Game.Content.Load<SoundEffect>("explosionSound");
            Meteor1 = Game.Content.Load<Texture2D>("Meteor1");
            Meteor2 = Game.Content.Load<Texture2D>("Meteor2");          
            
            //picks a random spot for new meteor to spawn
            Random random = new Random();
            rockPosition = new Vector2(random.Next(0, GraphicsDevice.Viewport.Width - Meteor1.Width), 0);
            base.LoadContent();
        }

        /// <summary>
        /// Unload Content function
        /// </summary>
        protected override void UnloadContent()
        {          
            base.UnloadContent();
        }

        /// <summary>
        /// Function that is called that removes a meteor if it was hit by a bullet, which is handled in a method in MeteorSpawnManager
        /// </summary>
        public void HandleCollision()
        {
            //Removes the meteor
            Game.Components.Remove(this);
            
            //Updates score
            score.gameScore = score.gameScore + 100;

            //Plays explosion sound
            explosionSound.Play(volume: 0.05f, pitch: 0.0f, pan: 0.0f);
        }
    }
}
