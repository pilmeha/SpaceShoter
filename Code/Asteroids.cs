using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShoter
{
    internal class Asteroids
    {
        public static int Width, Height;
        public static Random Rnd = new Random();

        //можно ли сделать сет приватным
        public static SpriteBatch SpriteBatch { get; private set; }
        static Star[] Stars;
        public static StarShip StarShip { get; set; }


        public static int GetIntRnd(int min, int max)
        {
            return Rnd.Next(min, max);
        }

        public static void Init(SpriteBatch spriteBatch, int width, int height)
        {
            Asteroids.Width = width;
            Asteroids.Height = height;
            Asteroids.SpriteBatch = spriteBatch;
            Stars = new Star[50];
            for (int i = 0; i < Stars.Length; i++)
                Stars[i] = new Star(new Vector2(-Asteroids.GetIntRnd(1, 10), 0));
            StarShip = new StarShip(new Vector2(0, Height / 2 - 20));
        }

        public static void Draw()
        {
            foreach (Star star in Stars)
            {
                star.Draw();
            }
            StarShip.Draw();
        }

        public static void Update()
        {
            foreach (Star star in Stars)
                star.Update();
        }

    }

    class Star
    {
        //можно ли тут писать с большой буквы переменные
        Vector2 Pos;
        Vector2 Dir;
        Color Color;

        //можно ли сделать сет приватным
        public static Texture2D Texture2D { get; set; }
        
        public Star(Vector2 pos, Vector2 dir)
        {
            this.Pos = pos;
            this.Dir = dir;
        }

        public Star(Vector2 dir)
        {
            this.Dir = dir;
            RandomSet();
        }

        public void Update()
        {
            Pos += Dir;
            if (Pos.X < 0)
                RandomSet();
        }

        public void RandomSet()
        {
            Pos = new Vector2(Asteroids.GetIntRnd(Asteroids.Width, Asteroids.Width + 300), Asteroids.GetIntRnd(0, Asteroids.Height));
            Color = Color.FromNonPremultiplied(Asteroids.GetIntRnd(0, 256), Asteroids.GetIntRnd(0, 256), Asteroids.GetIntRnd(0, 256), Asteroids.GetIntRnd(0, 256));
        }

        public void Draw()
        {
            Asteroids.SpriteBatch.Draw(Texture2D, Pos, Color);
        }
    }

    class StarShip
    {
        //можно ли тут писать с большой буквы переменные
        Vector2 pos;
        Color color = Color.White;
        public int Speed { get; set; } = 5;
        //можно ли сделать сет приватным
        public static Texture2D Texture2D { get; set; }

        public StarShip(Vector2 pos)
        {
            this.pos = pos;
        }

        public void Up()
        {
            if (this.pos.Y > 0) 
                this.pos.Y -= Speed;
        }

        public void Down()
        {
            if (this.pos.Y < Asteroids.Height - Texture2D.Height) 
                this.pos.Y += Speed;
        }

        public void Right()
        {
            if (this.pos.X < Asteroids.Width - Texture2D.Width) 
                this.pos.X += Speed;
        }

        public void Left()
        {
            if (this.pos.X > 0) 
                this.pos.X -= Speed;
        }

        public void Draw()
        {
            Asteroids.SpriteBatch.Draw(Texture2D, pos, color);
        }
    }
}
