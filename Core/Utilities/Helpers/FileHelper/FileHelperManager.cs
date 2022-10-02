using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelperService
    {
        public void Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if(file.Length>0)
            {
                if(Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString()+extension;

                using (var fileStream = File.Create(root + guid))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return guid;
                }

            }
            return null;
        }
    }
}
