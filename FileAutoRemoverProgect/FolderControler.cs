using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileAutoRemoverProgect
{
    class FolderControler
    {
        public List<FileOptions> FilesOptions { get; private set; }
        
        public FileSystemWatcher FileWatcher;

        public FolderControler(string FolderPath)
        {
            FileWatcher = new FileSystemWatcher(FolderPath);
            FileWatcher.Created +=FileWatcher_Created;
            FileWatcher.Deleted +=FileWatcher_Deleted;
            FilesOptions = LoadFilesOptions();
        }

        void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
 	        foreach (var item in FilesOptions)
	        {
                if (item.State == FileState.Alive)
                {
                    item.PathList.Remove(e.FullPath);
                }
	        }
            SaveFilesOptions();
        }

        void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
 	        //TODO создание нового обьекта файла настроек
            SaveFilesOptions();
        }
        private List<FileOptions> LoadFilesOptions()
        {
            // TODO реализовать чтение настроек файлов
            return new List<FileOptions>();
            
        }
        private void SaveFilesOptions()
        {
            // TODO реализовать запись настроек файлов
        }
        public void Refresh()
        {
            var res = from item in FilesOptions
                      where (item.State == FileState.Alive)
                      & (item.KillingTime< DateTime.Now)
                      select item;
            foreach (var item in res)
            {
                item.ExrcuteEndOfLifeActions();
            }
            SaveFilesOptions();
        }
        
        ~FolderControler()
        {
            SaveFilesOptions();
        }
        
    }
}
