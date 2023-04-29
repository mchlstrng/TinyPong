using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TinyPong
{
    internal class Paddle
    {
        public Vector2 Position { get; set; }
        public int Speed { get; set; }
        public Texture2D Texture { get; set; }

        public Paddle(PlayerType playerType)
        {
            Speed = 5;
            if (playerType == PlayerType.HumanP1)
            {
                Position = new Vector2(10, 10);
            }
            else if (playerType == PlayerType.HumanP2)
            {
                Position = new Vector2(770, 10);
            }
            else
            {
                Position = new Vector2(770, 10);
            }
        }



        //draw the paddle
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }


    }
}