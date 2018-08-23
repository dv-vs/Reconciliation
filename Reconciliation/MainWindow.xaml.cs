using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Reconciliation.Models;

namespace Reconciliation
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

        private void ChooseCatalog(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.AllowNonFileSystemItems = true;
            dialog.Title = "Укажите каталог с файлами загрузки";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BaseExcelCatalog.Text = dialog.FileName;
                var files = Directory.GetFiles(dialog.FileName).Select(x => new FileForImport { Download = true, Filename = x});
                BaseImportFiles.ItemsSource = files;
            }

        }

        private void DownloadFiles(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BaseExcelCatalog.Text))
                MessageBox.Show("Не выбран каталог загрузки");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
