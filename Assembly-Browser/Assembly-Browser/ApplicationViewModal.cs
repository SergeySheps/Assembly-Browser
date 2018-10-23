using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assebly_Browser_Library;
using Assebly_Browser_Library.Models;

namespace Assembly_Browser
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService dialogService;
        private AssemblyLoader assemblyLoader;
        private List<Namespace> namespaces;
        private RelayCommand openCommand;
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
                return openCommand ??
                       (openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               if (dialogService.OpenFileDialog())
                               {
                                   Namespaces = assemblyLoader.GetAssemblyInformation(dialogService.FilePath);
                               }
                           }
                           catch (Exception ex)
                           {
                               dialogService.ShowMessage(ex.Message);
                           }
                       }));
            }
        }


        public List<Namespace> Namespaces
        {
            get => namespaces;
            set
            {
                namespaces = value;
                NamespacesToString();
                OnPropertyChanged();
            }
        }

        public ApplicationViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            assemblyLoader = new AssemblyLoader();
        }

        private void NamespacesToString()
        {
            string res = "";
            foreach (var ns in namespaces)
            {
                res += $"{ns.Name}:\n";
                foreach (var dataType in ns.DataTypes)
                {
                    res += $"  {dataType.Name}:\n";
                    foreach (var field in dataType.Fields)
                    {
                        res += $"    Field: {field.Type} {field.Name}\n";
                    }

                    foreach (var property in dataType.Properties)
                    {
                        res += $"    Property: {property.Type} {property.Name}\n";
                    }

                    foreach (var method in dataType.Methods)
                    {
                        res += $"    Method: {method.Signature}\n";
                    }
                }
            }

            OutputString = res;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
