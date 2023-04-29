using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace TinyPong
{
    public class KeyboardManager
    {
        public KeyboardState CurrentKeyboardState { get; set; }
        public KeyboardState PreviousKeyboardState { get; set; }

        public KeyboardManager()
        {
            CurrentKeyboardState = Keyboard.GetState();
            PreviousKeyboardState = Keyboard.GetState();
        }

        public void Update()
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }   

        public bool IsKeyPressed(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key) && PreviousKeyboardState.IsKeyUp(key);
        }

        public bool IsKeyDown(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key);
        }

    }
}