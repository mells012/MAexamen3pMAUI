using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAviewmodels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "citas.db");

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
