using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FrontEnd
{
    public static class ChessCursors
    {

        public static readonly Cursor whiteCursor = loadCursor("Assets/CursorW.cur");
        public static readonly Cursor blackCursor = loadCursor("Assets/CursorB.cur");

        private static Cursor loadCursor(String path)
        {
            Stream stream = Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream;

            return new Cursor(stream,true);
        }
    }
}
