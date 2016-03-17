using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ontwikkelopdracht_Game
{
    public class InputController
    {
        public static InputController Instance = new InputController();

        public bool IsKeyDown(Key key) => Keyboard.IsKeyDown(key); 

        private InputController()
        {
            
        }
    }
}
