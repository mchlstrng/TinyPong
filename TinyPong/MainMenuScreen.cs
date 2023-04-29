using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace TinyPong;

public partial class MainMenuScreen : IActiveGameScreen
{
    private readonly TinyPong _tinyPong;
    public SpriteFont SpriteFont { get; set; }

    private List<MenuItem> _menuItems = new List<MenuItem>();

    public MainMenuScreen(TinyPong tinyPong)
    {
        _tinyPong = tinyPong;
    }

    public void LoadContent()
    {
        SpriteFont = _tinyPong.ContentManager.Load<SpriteFont>("menufont");
    }

    public void Draw()
    {

        //draw title text
        //add game title menuitem
        var gameTitleText = "Tiny Pong";
        var gameTitleTextSize = SpriteFont.MeasureString(gameTitleText);
        var gameTitlePosition = new Vector2(GetViewportCenterX() - gameTitleTextSize.X / 2, 100);
        var gameTitleMenuItem = new MenuItem(gameTitleText, gameTitlePosition);

        _tinyPong.SpriteBatch.DrawString(SpriteFont, gameTitleMenuItem.Text, gameTitleMenuItem.Position, gameTitleMenuItem.Color);

        foreach (var menuItem in _menuItems)
        {
            _tinyPong.SpriteBatch.DrawString(SpriteFont, menuItem.Text, menuItem.Position, menuItem.Color);
        }
    }

    public void SetupMenuItems()
    {
        var viewportCenterX = GetViewportCenterX();

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

    private float GetViewportCenterX()
    {
        var viewportCenterX = _tinyPong.Graphics.GraphicsDevice.Viewport.Width / 2f;
        return viewportCenterX;
    }

    public void Update()
    {
        var previousMenuItem = _menuItems.Find(x => x.IsSelected);
        var previousMenuItemIndex = _menuItems.IndexOf(previousMenuItem);
        if (_tinyPong.KeyboardManager.IsKeyPressed(Keys.Up))
        {
            previousMenuItem.IsSelected = false;
            var nextMenuItemIndex = previousMenuItemIndex - 1;
            if (nextMenuItemIndex < 0)
            {
                nextMenuItemIndex = _menuItems.Count - 1;
            }
            _menuItems[nextMenuItemIndex].IsSelected = true;
        }
        else if (_tinyPong.KeyboardManager.IsKeyPressed(Keys.Down))
        {
            previousMenuItem.IsSelected = false;
            var nextMenuItemIndex = previousMenuItemIndex + 1;
            if (nextMenuItemIndex > _menuItems.Count - 1)
            {
                nextMenuItemIndex = 0;
            }
            _menuItems[nextMenuItemIndex].IsSelected = true;
        }

        //start game on enter
        if (_tinyPong.KeyboardManager.IsKeyPressed(Keys.Enter))
        {
            var selectedMenuItem = _menuItems.Find(x => x.IsSelected);
            if (selectedMenuItem.Text == "Play")
            {
                _tinyPong.ActiveGameScreen = _tinyPong.ScreenFactory.CreateScreen(ScreenType.Gameplay);
            }
            else if (selectedMenuItem.Text == "Exit")
            {
                _tinyPong.Exit();
            }
        }
    }
}