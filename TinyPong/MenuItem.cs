using Microsoft.Xna.Framework;

namespace TinyPong;

internal class MenuItem
{
    public string Text { get; set; }
    public Vector2 Position { get; set; }
    
    //color property returns yellow if isselected
    public Color Color
    {
        get
        {
            if (IsSelected)
            {
                return Color.Yellow;
            }
            else
            {
                return Color.White;
            }
        }
    }

    public bool IsSelected { get; set; }

    public MenuItem(string text, Vector2 position)
    {
        Text = text;
        Position = position;
        IsSelected = false;
    }
}