using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOneMono;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace FinalProjectShell
{
    public class ActionScene : GameScene
    {
        

        public ActionScene (Game game): base(game)
        {
            
        }

        public override void Initialize()
        {
            // create and add any components that belong to this scene

            this.AddComponent(new Player(Game));
            this.AddComponent(new MeteorSpawnManager(Game, this));            
            this.AddComponent(new Score(Game));            
            this.AddComponent(new GameOver(Game));
            this.AddComponent(new HighScoresToFile(Game));

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            MenuComponent menuComponent = Game.Services.GetService<MenuComponent>();
            if (Enabled )
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    
                    ((Game1)Game).HideAllScenes();
                   
                    Game.Services.GetService<StartScene>().Show();
                    MediaPlayer.Play(menuComponent.mainMenuMusic);
                   
                }
            }
            base.Update(gameTime);
        }     
    }
}
