using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TinyPong
{
    public interface IActiveGameScreen
    {
        void Draw();
        void LoadContent();
        void SetupMenuItems();
        void Update();

        SpriteFont SpriteFont { get; set; }
    }
}
