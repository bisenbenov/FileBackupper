using System;
using System.IO;

namespace FileBackupper.Entities
{
    /// <summary>
    /// Сущность для внутренних файлов
    /// </summary>
    public class FileEntity
    {
        public string OriginPath { get; }

        public FileEntity(string originPath)
        {
           OriginPath = originPath;
        }

        public void CloneToFolder(FolderEntity targetFolder)
        {      
            FileStream fromOriginal = File.OpenRead(OriginPath);

            if (!fromOriginal.CanRead)
            {
                throw new Exception($"Невозможно открыть файл {OriginPath} на чтение!");
            }

            string targetPath = Path.Combine(targetFolder.OriginPath, Path.GetFileName(OriginPath));

            try
            {
                FileStream toTarget = File.OpenWrite(targetPath);
                fromOriginal.CopyTo(toTarget);
            }
            catch (Exception)
            {
                throw new Exception($"Невозможно открыть файл {targetPath} для записи!");
            }
        }
    }
}
