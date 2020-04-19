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
    class Bullet : DrawableGameComponent
    {    
        //Sets Variables
        public Rectangle boundingBox;
        public Texture2D bulletTexture;   
        public Vector2 bulletPosition;
        public bool isBulletVisible;
        const int SPEED = 10;
        MeteorSpawnManager meteorManager;

        /// <summary>
        /// Default Constructor that takes in a texture2D
        /// </summary>
        /// <param name="newTexture"></param>
        public Bullet(Game game, Texture2D newTexture) : base(game)
        {
            //Sets variables
            bulletTexture = newTexture;
            isBulletVisible = false;
        }

        /// <summary>
        /// Default constructor that takes in a Vector2
        /// </summary>
        /// <param name="game"></param>
        /// <param name="position"></param>
        public Bullet(Game game, Vector2 position) : base(game)
        {
            //Sets variables
            this.bulletPosition = position;
            isBulletVisible = true;
        }

        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            meteorManager = Game.Services.GetService<MeteorSpawnManager>();

            //Updates bullet speed
            bulletPosition.Y -= SPEED;

            //Sets hitbox of bullet
            boundingBox = bulletTexture.Bounds;
            boundingBox.Location = bulletPosition.ToPoint();
          
            //Checks if bullet is offscreen and removes it if it is, otherwise calls the check for collision methond
            if(bulletPosition.Y <= -bulletTexture.Height)
            {
                Game.Components.Remove(this);
            }
            else
            {
                if (meteorManager.IsThereCollision(this))
                {
                    Game.Components.Remove(this);
                }              
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            //Draws the bullet
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.Draw(bulletTexture, bulletPosition, Color.White); 
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Load Content Function
        /// </summary>
        protected override void LoadContent()
        {
            //Loads images used in this class
            bulletTexture = Game.Content.Load<Texture2D>("bullet");
            base.LoadContent();
        }
    }
}
