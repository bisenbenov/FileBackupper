using FileBackupper.Entities;
using System;
using System.IO;

namespace FileBackupper
{
    public class FileBackupper
    {
        private ConfigurationData _configData;

        public FileBackupper(ConfigurationData configData)
        {
            _configData = configData;
        }

        public void StartBackup()
        {
            FolderEntity origin = new FolderEntity(_configData.OriginPath);
            FolderEntity target = new FolderEntity(_configData.TargetPath);

            origin.CloneInnerToFolder(target);
        }
    }
}
