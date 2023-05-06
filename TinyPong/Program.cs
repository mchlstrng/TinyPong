
using Microsoft.Xna.Framework.Content;
using TinyPong;

using var game = new TinyPong.TinyPong();

game.ActiveGameScreen = new MainMenuScreen(game);
game.KeyboardManager = new KeyboardManager();
game.ScreenFactory = new ScreenFactory(game);
game.ContentManager = new ContentManagerWrapper(game.Content);

game.Run();
