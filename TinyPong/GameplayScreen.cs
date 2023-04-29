using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TinyPong;

public class GameplayScreen : IActiveGameScreen
{
    private readonly TinyPong _tinyPong;

    public GameplayScreen(TinyPong tinyPong)
    {
        _tinyPong = tinyPong;
    }

    public void Draw()
    {

    }

    public void LoadContent()
    {

    }

    public void SetupMenuItems()
    {

    }

    public void Update()
    {

    }

    public SpriteFont SpriteFont { get; set; }
}