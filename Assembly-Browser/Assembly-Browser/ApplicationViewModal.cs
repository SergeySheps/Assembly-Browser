using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Assembly_Browser
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService dialogService;
        private RelayCommand _openCommand;
        private string outputString;

        public string OutputString
        {
            get => outputString;
            set
            {
                if (outputString != value)
                {
                    outputString = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                       (_openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               if (dialogService.OpenFileDialog())
                               {
                                   
                               }
                           }
                           catch (Exception ex)
                           {
                               dialogService.ShowMessage(ex.Message);
                           }
                       }));
            }
        }

        public ApplicationViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
