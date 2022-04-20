using BaseDeDatosLocales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseDeDatosLocales.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioPage : ContentPage
    {
        public FormularioPage()
        {
            InitializeComponent();
        }

        private async void Insertar(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            string edad = txtedad.Text;

            Persona persona = new Persona()
            {
                Id = 0,
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad
            };
            try
            {
                int resul = await App.DataBase.Agregar(persona);

                if (resul != 0)
                {
                    await DisplayAlert("Insertar", "Exitoo", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
            


        }

        private void Actualizar(object sender, EventArgs e)
        {

        }

        private void Eliminar(object sender, EventArgs e)
        {

        }

        private async void BuscarUno(object sender, EventArgs e)
        {
            Persona persona = new Persona
            {
                Id = Convert.ToInt32(txtId.Text)
            };
          Persona personaEncontrada=  await App.DataBase.BuscarUno(persona);

            txtnombre.Text = personaEncontrada.Nombre;
            txtapellido.Text = personaEncontrada.Apellido;
            txtedad.Text = personaEncontrada.Edad;
        }
        
        private void BuscarTodo(object sender, EventArgs e)
        {

        }
    }
}