using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace FileAutoRemoverProgect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

  
        private void FolderPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            if (System.IO.Directory.Exists(ArchivePath.Text))
            {
                dialog.SelectedPath = ((System.Windows.Controls.TextBox)sender).Text;
            }
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ((System.Windows.Controls.TextBox)sender).Text = dialog.SelectedPath;
            } 
        }

        private void FileStandartLifetime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int i;
            if (!int.TryParse(e.Text, out i))
            {
                e.Handled = true;
            }
        }

        private void FileStandartLifetime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FileStandartLifetime.Text == "0" || FileStandartLifetime.Text == "")
            {
                FileStandartLifetime.Text = "1";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(FileStandartLifetime.Text);
            if (CbDaysOrHours.SelectedIndex == 0)
            {
                PorjectSettings.SaveSettings(FolderPath.Text, ArchivePath.Text,
               new TimeSpan(i,0,0), (EndOfFilesLifeOption)ComboEndOfLife.SelectedIndex);
            }
            else if (CbDaysOrHours.SelectedIndex == 1)
            {
                PorjectSettings.SaveSettings(FolderPath.Text, ArchivePath.Text,
               new TimeSpan(i, 0, 0, 0), (EndOfFilesLifeOption)ComboEndOfLife.SelectedIndex);
            }
           
        }

        private void BtDefault_Click(object sender, RoutedEventArgs e)
        {
            PorjectSettings.Default();
            GetSettings();

        }
        
        private void GetSettings()
        {
            if (PorjectSettings.StandartFilesLifeTimeSpan.Hours != 0)
            {
                CbDaysOrHours.SelectedIndex = 1;
                FileStandartLifetime.Text =
                    PorjectSettings.StandartFilesLifeTimeSpan.TotalHours.ToString();
            }
            else
            {
                CbDaysOrHours.SelectedIndex = 0;
                FileStandartLifetime.Text =
                    PorjectSettings.StandartFilesLifeTimeSpan.TotalDays.ToString();
            }
            FolderPath.Text = PorjectSettings.FolderPath;
            ArchivePath.Text = PorjectSettings.ArchivePath;
            ComboEndOfLife.SelectedIndex = (int)PorjectSettings.StandartEndOfLifeOption;
        }
    }
}
