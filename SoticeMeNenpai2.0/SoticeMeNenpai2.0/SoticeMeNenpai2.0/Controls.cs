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
    class MenuButton
    {
        public Texture2D ButtonOver { get; set; }
        public Texture2D ButtonDefault { get; set; }
        public Texture2D ButtonClick { get; set; }
        public Rectangle Bounds { get; set; } // Should work
        public Point Position { get; set; }
        public String Text { get; set; }
        public SpriteFont spriteFont { get; set; }
        public Color FontColor { get; set; }
        public Boolean Active { get; set; }
        private Vector2 StringPosition;
        private Vector2 StringSize;
        private Texture2D CurrentTexture;
        private ButtonState oldState;


        public MenuButton(Point position, String text, SpriteFont spritefont, Color fontColor, Texture2D buttonOver, Texture2D buttonDefault, Texture2D buttonClick)
        {
            ButtonOver = buttonOver;
            ButtonClick = buttonClick;
            ButtonDefault = buttonDefault;
            Position = position;
            Bounds = new Rectangle(Position.X, Position.Y, ButtonDefault.Width, ButtonDefault.Height);
            CurrentTexture = buttonDefault;
            Text = text;
            FontColor = fontColor;
            spriteFont = spritefont;
            Active = true;
        }

        public MenuButton(int X, int Y, String text, SpriteFont spritefont, Color fontColor, Texture2D buttonOver, Texture2D buttonDefault, Texture2D buttonClick)
        {
            ButtonOver = buttonOver;
            ButtonClick = buttonClick;
            ButtonDefault = buttonDefault;
            Position = new Point(X, Y);
            Bounds = new Rectangle(X - (ButtonDefault.Width / 2), Y - (ButtonDefault.Height / 2), ButtonDefault.Width, ButtonDefault.Height);
            CurrentTexture = buttonDefault;
            Text = text;
            FontColor = fontColor;
            spriteFont = spritefont;
            Active = true;
        }

        public Boolean Update() // Returns if clicked
        {
            MouseState mouseState = Mouse.GetState();
            StringSize = spriteFont.MeasureString(Text);
            StringPosition = new Vector2(Bounds.X/2 + StringSize.X / 2, Bounds.Y/2 + StringSize.Y / 2);
            if (Active)
                if (Bounds.Contains(mouseState.X, mouseState.Y))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed) // MouseDown
                    {
                        CurrentTexture = ButtonClick;
                    }
                    else if (mouseState.LeftButton == ButtonState.Released && oldState == ButtonState.Pressed) //Mouse Up
                    {
                        CurrentTexture = ButtonDefault;
                        oldState = mouseState.LeftButton;
                        return true;
                    }
                    else // Mouse Over
                    {
                        CurrentTexture = ButtonOver;

                    }

                }
                else
                {
                    CurrentTexture = ButtonDefault;

                }
            oldState = mouseState.LeftButton;
            return false;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(CurrentTexture, Bounds, Color.White);
            spriteBatch.DrawString(spriteFont, Text, StringPosition, FontColor);
            spriteBatch.End();
        }

    }
}

