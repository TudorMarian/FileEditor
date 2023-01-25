using FileEditor.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Utils;

namespace FileEditor.ViewModel
{
    public class FileEditorViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _fileContent;
        public string FileContent
        {
            get
            {
                return _fileContent;
            }

            set
            {
                _fileContent = value;
                OnPropertyChanged();
            }
        }
        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand BrowseCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        public FileEditorViewModel()
        {
            BrowseCommand = new DelegateCommand(ExecuteBrowse, (x) => true);
            SaveCommand = new DelegateCommand(ExecuteSave, (x) => true);
        }

        private void ExecuteSave(object obj)
        {
            FileWriter fileWriter = new FileWriter();
            try
            {
                fileWriter.Write(FilePath, FileContent);
            }
            catch (System.Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void ExecuteBrowse(object ob)
        {
            FileBrowser fileBrowser = new FileBrowser();
            FilePath = fileBrowser.Browse();
            try
            {
                FileReader fileReader = new FileReader();
                FileContent = fileReader.Read(FilePath);
            }
            catch (System.Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

    }
}
