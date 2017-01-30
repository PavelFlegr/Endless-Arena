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
        static Mouse()
        {
            // System.Windows.Input.Mouse.AddMouseDownHandler(Application.Current.MainWindow)
        }

        static public Vec2 Position
        {
            get
            {
                Window window = Application.Current.MainWindow;
                Point topLeft = System.Windows.Input.Mouse.GetPosition(window);
                return new Vec2(topLeft.X - SystemParameters.VirtualScreenWidth/2, topLeft.Y - SystemParameters.VirtualScreenHeight/2);
            }
        }
    }
}
