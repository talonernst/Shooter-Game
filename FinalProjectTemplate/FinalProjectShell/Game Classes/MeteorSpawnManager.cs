using FinalProjectShell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AllInOneMono
{
    class MeteorSpawnManager : GameComponent
    {
        //Sets variables 
        double speedUpMeteorSpawn, secondsSinceLastMeteor = 0.0;       
        double new_meteor_interval = 3.0;
        Random random;
        GameScene parent;
        Player player;
        MeteorSpawnManager meteorManager;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public MeteorSpawnManager(Game game, GameScene parent) : base(game)
        {
            Game.Services.AddService<MeteorSpawnManager>(this);
            player = Game.Services.GetService<Player>();
            meteorManager = Game.Services.GetService<MeteorSpawnManager>();
            this.parent = parent;
            random = new Random();
        }
       
        /// <summary>
        /// Initalize Function
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
            //Ifs are used to spped up the meteors as the game goes on
            speedUpMeteorSpawn += gameTime.ElapsedGameTime.TotalSeconds;
            if(speedUpMeteorSpawn > 15.0)
            {
                new_meteor_interval -= 0.1;
                speedUpMeteorSpawn = 0.0;
            }
            if (new_meteor_interval < 0.4)
            {
                new_meteor_interval = 0.4;
            }

            //Used to decide when to make a new Meteor spawn at a random location
            secondsSinceLastMeteor += gameTime.ElapsedGameTime.TotalSeconds;
            if(secondsSinceLastMeteor > new_meteor_interval)
            {
                Vector2 location = new Vector2 (random.Next(Game.GraphicsDevice.Viewport.Width),
                                                random.Next(Game.GraphicsDevice.Viewport.Height));
                parent.AddComponent(new Meteor(Game, location));            
                secondsSinceLastMeteor = 0.0;
            }
            if (player.intLivesLeft < 1)
            {
                Game.Components.Remove(this);

            }
            base.Update(gameTime);
        }
        /// <summary>
        /// A function that checks for collision between a bullet and any component that is a meteor
        /// </summary>
        /// <param name="bullet"></param>
        /// <returns></returns>
        public bool IsThereCollision(Bullet bullet)
        {
            foreach (GameComponent component in Game.Components)
            {
                if(component is Meteor meteor)
                {
                    if (bullet.boundingBox.Intersects(meteor.Bounds))
                    {
                        meteor.HandleCollision();
                        return true;
                    }
                }                              
            }
            return false;                
        }
    }
}
