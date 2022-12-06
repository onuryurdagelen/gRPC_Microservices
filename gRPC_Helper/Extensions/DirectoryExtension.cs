using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPC_Helper.Extensions
{
    public class DirectoryExtension
    {
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            DirectoryInfo directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());

            return directory;
        }

        public static string GetTxtFilePath()
        {
            // get directory
            DirectoryInfo directoryPath = TryGetSolutionDirectoryInfo();
            // if directory found
            if (directoryPath != null)
            {
                //MessageBox.Show(directory.FullName);
                string filePath = Path.Combine(directoryPath.FullName,
                "settings.txt");
                //MessageBox.Show(filePath);

                string textFile = Path.GetFileName(filePath);

                return textFile;
            }
            return null;
        }

    }

}
