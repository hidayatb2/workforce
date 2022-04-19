using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class FileManager
    {
        public static string SaveFile(IFormFile file, string webRootPath)
        {
            string extention = Path.GetExtension(file.FileName);
            string uniqueName = Guid.NewGuid() + extention;
            var path = Path.Combine("files", uniqueName);
            using var fs = new FileStream(Path.Combine(webRootPath, path), FileMode.Create);
            fs.CopyTo(fs);
            return "/files/" + uniqueName;
        }
        public static void DeleteFile(String webRootPath, string filePath)
        {
            string path = filePath.Substring(1).Replace('/', '\\');
            string physicalPath = Path.Combine(webRootPath, path);
            if (File.Exists(physicalPath))
            {
                File.Delete(physicalPath);
            }
        }
    }
}
