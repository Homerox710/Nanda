using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace Nanda.iOS
{
    class FileAccess
    {
        public static string GetLocalFilePath(string filename) //El resultado de cada plataforma es diferente
        {
            string path = System.Environment.GetFolderPath(
            System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}