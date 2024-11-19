using System.ComponentModel;

namespace Databinding_with_api
{
    public class PersonaModel : INotifyPropertyChanged
    {
        private string _nombre;
        private string _apellido;
        private string _fh_nac;
        private string _sexo;
        private int _rol;

        public string nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(nombre));
                }
            }
        }

        public string apellido
        {
            get => _apellido;
            set
            {
                if (_apellido != value)
                {
                    _apellido = value;
                    OnPropertyChanged(nameof(apellido));
                }
            }
        }
        public string sexo
        {
            get => _sexo;
            set
            {
                if (_sexo != value)
                {
                    _sexo = value;
                    OnPropertyChanged(nameof(sexo));
                }
            }
        }

        public string fh_nac
        {
            get => _fh_nac;
            set
            {
                if (_fh_nac != value)
                {
                    _fh_nac = value;
                    OnPropertyChanged(nameof(fh_nac));
                }
            }
        }

      

        public int id_rol
        {
            get => _rol;
            set
            {
                if (_rol != value)
                {
                    _rol = value;
                    OnPropertyChanged(nameof(id_rol));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
