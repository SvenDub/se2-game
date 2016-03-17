using System.Collections.Generic;
using System.Windows.Input;
using Ontwikkelopdracht_Game;

namespace Tests
{
    public class MockInputController : InputController
    {
        public List<Key> OverriddenKeys = new List<Key>();

        public override bool IsKeyDown(Key key) => Keyboard.IsKeyDown(key) || OverriddenKeys.Contains(key);
    }
}