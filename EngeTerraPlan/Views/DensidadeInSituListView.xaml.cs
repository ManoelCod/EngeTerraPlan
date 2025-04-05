using System;
using System.Collections.ObjectModel;
using EngeTerraPlan.ViewModels;
using Microsoft.Maui.Controls;

namespace EngeTerraPlan.Views
{
    public partial class DensidadeInSituListView : ContentPage
    {
        DensidadeInSituListViewModel viewModel;

        public DensidadeInSituListView()
        {
            InitializeComponent();
            BindingContext = viewModel = new DensidadeInSituListViewModel();
            viewModel.LoadItemsCommand.Execute(null);
        }
    }

    // Classe que representa os dados de cada item
    public class DensidadeItem
    {
        public string Codigo { get; set; }
        public string Data { get; set; }
        public string Cliente { get; set; }
        public string Obra { get; set; }
        public string EstacaLocal { get; set; }
        public string GrauCompactacao { get; set; }
    }
}