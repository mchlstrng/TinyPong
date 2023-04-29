namespace TinyPong
{
    public interface IScreenFactory
    {
        IActiveGameScreen CreateScreen(ScreenType screenType);
    }
}