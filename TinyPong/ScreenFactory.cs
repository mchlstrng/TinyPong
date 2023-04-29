using System;
using TinyPong.Exceptions;

namespace TinyPong;

/// <summary>
/// The screen factory is responsible for creating the game screens.
/// </summary>
public class ScreenFactory : IScreenFactory
{
    private readonly TinyPong _tinyPong;

    public ScreenFactory(TinyPong tinyPong)
    {
        _tinyPong = tinyPong ?? throw new ArgumentNullException(nameof(tinyPong));
    }

    public IActiveGameScreen CreateScreen(ScreenType screenType)
    {
        switch (screenType)
        {
            case ScreenType.MainMenu:
                var mainMenuScreen = new MainMenuScreen(_tinyPong);
                mainMenuScreen.LoadContent();
                return mainMenuScreen;
            case ScreenType.Gameplay:
            {
                var gameplayGameScreen = new GameplayScreen(_tinyPong);
                gameplayGameScreen.LoadContent();
                return gameplayGameScreen;
            }
            default:
                throw new InvalidScreenTypeException("could not determine game screen to create");
        }
    }
}