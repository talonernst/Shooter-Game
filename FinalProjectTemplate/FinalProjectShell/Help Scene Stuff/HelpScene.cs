using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProjectShell
{
    public class HelpScene : GameScene
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="game"></param>
        public HelpScene(Game game): base(game)
        {
            
        }

        /// <summary>
        /// Initalize Function
        /// </summary>
        public override void Initialize()
        {        
            this.SceneComponents.Add(new HelpTextComponent(Game));
            this.Hide();
            base.Initialize();
        }

        /// <summary>
        /// Update Function
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if( Enabled)
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
