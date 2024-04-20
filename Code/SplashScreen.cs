using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShoter
{
    static class SplashScreen
    {
        public static Texture2D Background { get; set; }
        static int timeCounter = 0;
        static Color color;
        public static SpriteFont Font { get; set; }
        static Vector2 textPosition = new Vector2(1000, 100);

        public static void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            _spriteBatch.DrawString(Font, "Астероиды!", textPosition, color);
        }

        public static void Update()
        {
            color = Color.FromNonPremultiplied(255, 255, 255, timeCounter % 256);
            timeCounter++;
        }
    }
}
