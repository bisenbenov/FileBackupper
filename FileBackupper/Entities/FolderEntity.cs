using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileBackupper.Entities
{
    /// <summary>
    /// Сущность для внутренних папок
    /// </summary>
    public class FolderEntity
    {
        public string OriginPath { get; }

        public FolderEntity(string originPath)
        {
            OriginPath = originPath;
        }

        public bool IsFolderExists()
        {
            return Directory.Exists(OriginPath);
        }

        public void CreatFolder()
        {
            Directory.CreateDirectory(OriginPath);
        }

        private List<FolderEntity> GetFolders()
        {
            return Directory.GetDirectories(OriginPath)
                .Select(path => new FolderEntity(path)).ToList();
        }

        private List<FileEntity> GetFiles()
        {
            return Directory.GetFiles(OriginPath)
                .Select(path => new FileEntity(path)).ToList();
        }

        private void CloneInnerFiles(FolderEntity targetFolder)
        {
            GetFiles().ForEach(file => file.CloneToFolder(targetFolder));
        }

        private void CloneInnerFolders(FolderEntity targetFolder)
        {
            GetFolders().ForEach(folder =>
            {
                var innerTargetFolder = new FolderEntity(Path.Combine(targetFolder.OriginPath, Path.GetFileName(folder.OriginPath)));
                folder.CloneInnerToFolder(innerTargetFolder);
            });
        }

        public void CloneInnerToFolder(FolderEntity targetFolder)
        {
            if (!Directory.Exists(OriginPath))
            {
                throw new DirectoryNotFoundException($"Невозможно открыть папку {OriginPath}!");
            }

            if (!targetFolder.IsFolderExists())
                targetFolder.CreatFolder();

            CloneInnerFiles(targetFolder);
            CloneInnerFolders(targetFolder);
        }
    }
}
