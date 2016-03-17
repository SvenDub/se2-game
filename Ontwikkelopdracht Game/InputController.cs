using System.Windows.Input;

namespace Ontwikkelopdracht_Game
{
    public class InputController
    {
        public static InputController Instance = new InputController();

        protected InputController()
        {
        }

        public virtual bool IsKeyDown(Key key) => Keyboard.IsKeyDown(key);
    }
}