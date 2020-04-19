using FinalProjectShell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOneMono
{
    class HighScoreScene : GameScene
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public HighScoreScene(Game game) : base(game)
        {
        }

        /// <summary>
        /// Initalize Function
        /// </summary>
        public override void Initialize()
        {
            //Adds service for ShowHighScoerScene
            this.SceneComponents.Add(new ShowHighScoreScene(Game));
            base.Initialize();
        }

        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //adds service for menu component
            MenuComponent menuComponent = Game.Services.GetService<MenuComponent>();
            if (Enabled)
            {
                //Sends back to main menu when you hit escape
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    ((Game1)Game).HideAllScenes();
                    Game.Services.GetService<StartScene>().Show();
                }
            }
            base.Update(gameTime);
        }
    }
}
