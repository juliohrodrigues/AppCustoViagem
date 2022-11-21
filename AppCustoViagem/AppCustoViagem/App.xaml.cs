using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCustoViagem.View;
using AppCustoViagem.Model;

using System.Threading;
using System.Collections.Generic;
using System.Globalization;
using AppCustoViagem;

namespace AppCustoViagem
{
    public partial class App : Application
    {
        public List<Pedagio> ArrayPedagios = new List<Pedagio>();
        public List<Viagem> ArrayViagem = new List<Viagem>();

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            InitializeComponent();

            MainPage = new NavigationPage(new DadosViagem());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}