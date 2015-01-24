using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SoticeMeNenpai
{
    class Combat : Microsoft.Xna.Framework.Game
    {
        Vector2 playerStartPos = new Vector2(700, 350);
        Sprite player = new Sprite();

        Sprite enviroment = new Sprite();

        Vector2 enemyStartPos = new Vector2(100, 50);
        Sprite enemy = new Sprite();


        public Combat(Texture2D playerText, Texture2D enemyText, Texture2D enviromentText)
        {
            player.SetTexture(playerText);
            enviroment.SetTexture(enviromentText);
            enemy.SetTexture(enemyText);

            player.SetPosition(playerStartPos);
            enemy.SetPosition(enemyStartPos);
            enviroment.SetPosition(new Vector2();
        }

        public Sprite getPlayer()
        {
            return player;
        }

        public void CombatUpdate(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
            {
                player.SetPosition(player.GetPosition() + new Vector2(-5,0));
            }
            if (state.IsKeyDown(Keys.D))
            {
                player.SetPosition(player.GetPosition() + new Vector2(5, 0));
            }
        }

        public void CombatDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(player.GetTexture(), player.GetRectangle(), Color.White);
            spriteBatch.Draw(enemy.GetTexture(), enemy.GetRectangle(), Color.White);
            spriteBatch.Draw(enviroment.GetTexture(), enviroment.GetRectangle(), Color.White);
        }
    }
}
