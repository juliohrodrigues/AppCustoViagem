using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCustoViagem.Model;
using AppCustoViagem;

namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPedagios : ContentPage
    {

        App PropriedadesApp;


        public ListaPedagios()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;

            lst_lista_pedagios.ItemsSource = PropriedadesApp.ArrayPedagios;
        }

        private async void MenuItem_Remover_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem i = sender as MenuItem;

                Pedagio pedagio_selecionado = (Pedagio)i.BindingContext;

                bool confirm = await DisplayAlert("Tem certeza?", "Remover Pedágio?", "Sim", "Não");

                if (confirm)
                {
                    PropriedadesApp.ArrayPedagios.RemoveAll(item => (item.Id == pedagio_selecionado.Id));

                    lst_lista_pedagios.ItemsSource = new List<Pedagio>();
                    lst_lista_pedagios.ItemsSource = PropriedadesApp.ArrayPedagios;
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void MenuItem_Editar_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem i = sender as MenuItem;

                Pedagio pedagio_selecionado = (Pedagio)i.BindingContext;

                string digitado = await DisplayPromptAsync(
                    "informe o Valor", "Novo Valor", "OK", "Cancelar", "R$ "
                );



                //PropriedadesApp.ArrayPedagios.RemoveAll(item => (item.Id == pedagio_selecionado.Id));

                lst_lista_pedagios.ItemsSource = new List<Pedagio>();
                lst_lista_pedagios.ItemsSource = PropriedadesApp.ArrayPedagios;


            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void ToolbarItem_Somar_Clicked(object sender, EventArgs e)
        {
            try
            {
                double soma_pedagios = PropriedadesApp.ArrayPedagios.Sum(i => i.Valor);

                string mensagem = string.Format(
                    "Valor total dos pedágios é {0}",
                    soma_pedagios.ToString("C")
                );

                DisplayAlert("Ops", mensagem, "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }

        }
    }
}