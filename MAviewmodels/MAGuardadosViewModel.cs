using System.Collections.ObjectModel;
using Microsoft.Data.Sqlite;
using SQLite;

namespace MAviewmodels
{
    public class MAGuardadosViewModel : BaseViewModel
    {
        public ObservableCollection<CitaGuardada> CitasGuardadas { get; set; } = new();

        public MAGuardadosViewModel()
        {
            CargarCitasGuardadas();
        }

        private void CargarCitasGuardadas()
        {
            using var db = new SQLiteConnection(DatabasePath);
            db.CreateTable<CitaGuardada>();
            var citas = db.Table<CitaGuardada>().ToList();
            CitasGuardadas.Clear();
            foreach (var cita in citas)
            {
                CitasGuardadas.Add(cita);
            }
        }
    }
}
