using System;


namespace FileAutoRemoverProgect
{
    public static class Settings
    {
        public static string FolderPath { get; set; }
        public static string ArchivePath { get; set; }
        public static TimeSpan StandartFilesLifeTimeSpan { get; set; }
        public static EndOfFilesLifeOption StandartEndOfLifeOption { get; set; }

        public static void SaveSettings(string folderPath, string archivePath, 
            TimeSpan lifeTimeSpan, EndOfFilesLifeOption endOfLifeOption)
        {
            FolderPath = folderPath;
            ArchivePath = archivePath;
            StandartFilesLifeTimeSpan = lifeTimeSpan;
            StandartEndOfLifeOption = endOfLifeOption;
            SaveSettings();
        }
        public static void SaveSettings()
        {
            //TODO реализовать сохранение настроек(возможно в реестре)

        }
        public static void LoadSettings()
        {
            //TODO реализовать загрузку настроек
        }
        public static void Default()
        {
            FolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Directory\";
            ArchivePath = AppDomain.CurrentDomain.BaseDirectory + @"\Archive\";
            StandartEndOfLifeOption = EndOfFilesLifeOption.Archive;
            StandartFilesLifeTimeSpan = new TimeSpan(14, 0, 0, 0);
        }
    }
}
