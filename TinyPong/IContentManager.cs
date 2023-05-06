namespace TinyPong;

public interface IContentManager
{
    T Load<T>(string assetName);
}