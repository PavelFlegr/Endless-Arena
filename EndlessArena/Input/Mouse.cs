using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndlessArena.Utilities;
using System.Windows.Input;
using System.Windows;

namespace EndlessArena.Input
{
    class Mouse
    {
        static Window window = Application.Current.MainWindow;
        static Mouse()
        {
            // System.Windows.Input.Mouse.AddMouseDownHandler(Application.Current.MainWindow)
        }

        static public Vec2 Position
        {
            get
            {

                Point topLeft = System.Windows.Input.Mouse.GetPosition(window);
                return new Vec2(topLeft.X - SystemParameters.PrimaryScreenWidth/2, topLeft.Y - SystemParameters.PrimaryScreenHeight/2);
            }
        }
    }
}
