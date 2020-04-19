using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectShell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AllInOneMono
{
    class CreditScene : GameScene
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public CreditScene(Game game) : base(game)
        {
        }

        /// <summary>
        /// Initalize Function
        /// </summary>
        public override void Initialize()
        {
            this.SceneComponents.Add(new ShowCreditScene(Game));
            base.Initialize();
        }

        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Adds menu component to the services
            MenuComponent menuComponent = Game.Services.GetService<MenuComponent>();

            //Sends back to main menu when you hit escape
            if (Enabled)
            {
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
