using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TinyPong;

public class MainMenuScreen
{
    private readonly TinyPong _tinyPong;
    public SpriteFont SpriteFont { get; set; }

    private List<MenuItem> _menuItems = new List<MenuItem>();

    public MainMenuScreen(TinyPong tinyPong)
    {
        _tinyPong = tinyPong;
    }

    public void LoadContent(ContentManager contentManager)
    {
        SpriteFont = contentManager.Load<SpriteFont>("menufont");
    }

    public void Draw()
    {
        foreach (var menuItem in _menuItems)
        {
            _tinyPong.SpriteBatch.DrawString(SpriteFont, menuItem.Text, menuItem.Position, menuItem.Color);
        }
    }

    public void SetupMenuItems()
    {
        var viewportCenterX = _tinyPong.Graphics.GraphicsDevice.Viewport.Width / 2f;

        //add game title menuitem
        var gameTitleText = "Tiny Pong";
        var gameTitleTextSize = SpriteFont.MeasureString(gameTitleText);
        var gameTitlePosition = new Vector2(viewportCenterX - gameTitleTextSize.X / 2, 100);
        var gameTitleMenuItem = new MenuItem(gameTitleText, gameTitlePosition);
        _menuItems.Add(gameTitleMenuItem);

        //add play menuitem
        var playText = "Play";
        var playTextSize = SpriteFont.MeasureString(playText);
        var playPosition = new Vector2(viewportCenterX - playTextSize.X / 2, 200);
        var playMenuItem = new MenuItem(playText, playPosition);
        playMenuItem.IsSelected = true;
        _menuItems.Add(playMenuItem);

        //add exit menuitem
        var exitText = "Exit";
        var exitTextSize = SpriteFont.MeasureString(exitText);
        var exitPosition = new Vector2(viewportCenterX - exitTextSize.X / 2, 250);
        var exitMenuItem = new MenuItem(exitText, exitPosition);
        _menuItems.Add(exitMenuItem);

    }
}