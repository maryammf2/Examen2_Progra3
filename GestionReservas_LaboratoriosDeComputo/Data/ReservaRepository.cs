using GestionReservas_LaboratoriosDeComputo.Models;

namespace GestionReservas_LaboratoriosDeComputo.Data
{
    public class ReservaRepository
    {
        private static List<Reserva> _reservas = new List<Reserva>();

        public void Agregar(Reserva reserva)
        {
            _reservas.Add(reserva);
        }

        public List<Reserva> ObtenerTodas()
        {
            return _reservas;
        }

        public bool CodigoExiste(string codigo)
        {
            return _reservas.Any(r => r.Codigo == codigo);
        }

    } //class
} //end
