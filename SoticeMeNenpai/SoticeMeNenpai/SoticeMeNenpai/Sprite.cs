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
    class Sprite
    {
        public Texture2D texture;
        private Vector2 position;

        public Sprite(/*Texture2D text, Vector2 pos*/)
        {
            //texture = text;
            //position = pos;
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public void SetTexture(Texture2D text)
        {
            texture = text;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
    }
}
