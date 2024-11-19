using System.Diagnostics;
using System.Text;

namespace Databinding_with_api
{
    public partial class FormPage : ContentPage
    {
        private readonly string apiUrl = "https://fi.jcaguilar.dev/v1/escuela/persona";

        public PersonaModel Persona { get; set; }

        public FormPage()
        {
            InitializeComponent();
            Persona = new PersonaModel { };
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Persona.nombre = EntryNombre.Text;
            Persona.apellido = EntryApellido.Text;
            Persona.fh_nac = DateFhNac.Date.ToString("yyyy-MM-dd");

            // variables para acceder a el valor de los grupos de botones de radio
            string sexo = null;
            string rol = null;

            // buscar boton radio de sexo seleccionado
            foreach (var view in sexoStackLayout.Children)
            {
                if (view is RadioButton radioButton && radioButton.IsChecked)
                {
                    Persona.sexo = radioButton.Value.ToString();
                    break;
                }
            }

            // buscar boton radio de rol seleccionado
            foreach (var view in rolStackLayout.Children)
            {
                if (view is RadioButton radioButton && radioButton.IsChecked)
                {
                    Persona.id_rol = int.Parse(radioButton.Value.ToString());
                    break;
                }
            }
            // Esto solo sirvio para ver el formato correcto del objeto persona
            DisplayAlert(
                "Info",
                $"Nombre: {Persona.nombre}\n" +
                $"Apellido: {Persona.apellido}\n" +
                $"Fecha de Nacimiento: {Persona.fh_nac:yyyy-MM-dd}\n" +
                $"Sexo: {Persona.sexo}\n" +
                $"Rol: {Persona.id_rol}",
                "OK"
            );
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                // Se realiza el post request para mandar nuestra persona, encapsulamos la informacion en json y se lo mandamos escuchando que respuesta nos da.
                var jsonPersona = System.Text.Json.JsonSerializer.Serialize(Persona);
                using var httpClient = new HttpClient();
                var content = new StringContent(jsonPersona, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiUrl, content);

            
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Exito", "Persona enviada exitosamente!", "OK");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Error", $"Error al mandar persona. Error: {errorContent}", "OK");
                }

                Debug.WriteLine(jsonPersona);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepcion", $"Algo no salio bien: {ex.Message}", "OK");
            }
        }
    }
}
