using System.Windows.Input;
using SQLite;

namespace MAviewmodels
{
    public class MADetallesViewModel : BaseViewModel
    {
        public string QuoteText { get; set; }
        public string Author { get; set; }
        public ICommand GuardarCommand { get; }

        public MADetallesViewModel()
        {
            GuardarCommand = new Command(GuardarCita);
        }

        private void GuardarCita()
        {
            using var db = new SQLiteConnection(DatabasePath);
            db.CreateTable<CitaGuardada>();
            var cita = new CitaGuardada
            {
                QuoteText = QuoteText,
                Author = Author
            };
            db.Insert(cita);
        }
    }

    public class CitaGuardada
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string QuoteText { get; set; }
        public string Author { get; set; }
    }
}
