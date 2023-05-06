using Microsoft.Xna.Framework.Content;

namespace TinyPong;

public class ContentManagerWrapper : IContentManager
{
    private readonly ContentManager _contentManager;

    public ContentManagerWrapper(ContentManager contentManager)
    {
        _contentManager = contentManager;
    }

    public T Load<T>(string assetName)
    {
        return _contentManager.Load<T>(assetName);
    }
}