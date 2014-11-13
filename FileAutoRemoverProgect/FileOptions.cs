using System;
using System.Collections.Generic;
using System.IO;
namespace FileAutoRemoverProgect
{
    [Serializable]
    class FileOptions
    {
      
        #region public_declarations
        public DateTime CreationDate { get; private set; }
        public List<string> PathList { get; set; }
        public EndOfFilesLifeOption EndOfLifeOption { get; set; }
        public DateTime KillingTime { get; set; }
        public FileState State { get; private set; }
        #endregion

        #region Constructors

        public FileOptions(List<string> pathList, 
            EndOfFilesLifeOption endOfLife, DateTime killingTime)
        {
            EndOfLifeOption = endOfLife;
            PathList = new List<string>();
            PathList.AddRange(pathList);
            CreationDate = DateTime.Now;
            KillingTime = killingTime;
            State = FileState.Alive;
        }
        public FileOptions(string path, EndOfFilesLifeOption endOfLife, DateTime killingTime)
            : this(new List<string>(), endOfLife, killingTime)
        {
            PathList.Add(path);
        }

        public FileOptions(string path, EndOfFilesLifeOption endOfLife, TimeSpan killingTimeSpan)
            : this(path, endOfLife, DateTime.Now + killingTimeSpan)
        {

        }
        public FileOptions(List<string> pathList, 
            EndOfFilesLifeOption endOfLife, TimeSpan killingTimeSpan)
            : this(pathList, endOfLife, DateTime.Now + killingTimeSpan)
        {

        } 
        #endregion
        public void ExecuteDeletations()
        {
            switch (EndOfLifeOption)
            {
                case EndOfFilesLifeOption.Nothing:
                    
                    break;
                case EndOfFilesLifeOption.Delete:
                    Delete();
                    State = FileState.Deleted;
                    break;
                case EndOfFilesLifeOption.Archive:
                    ToArchive();
                    State = FileState.Archivated;
                    break;
                case EndOfFilesLifeOption.Ask:
                    //TODO вызов окна диалога выбора действия над файлами
                    break;
            }
            if (EndOfLifeOption != EndOfFilesLifeOption.Nothing)
            {
                //TODO Вывод оповещения
            }
        }
        private void ToArchive()
        {
            //TODO Архивация файлов
            Delete();
        }
        private void Delete()
        {
            foreach (var item in PathList)
            {
                try
                {
                    File.Delete(item);
                }
                catch  (DirectoryNotFoundException ex)
                {
                    //TODO сообщение об отсутствии файла
                }
                catch (Exception ex)
                {
                    //TODO сообщение об ошибке
                }
                
            }
        }
    }
}
