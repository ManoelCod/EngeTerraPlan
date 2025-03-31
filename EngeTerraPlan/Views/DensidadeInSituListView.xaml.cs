using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace EngeTerraPlan.Views
{
    public partial class DensidadeInSituListView : ContentPage
    {
        public ObservableCollection<DensidadeItem> DensidadeItems { get; set; }

        public DensidadeInSituListView()
        {
            InitializeComponent();
            BindingContext = this; // Define o contexto de dados
            LoadDensidadeItems(); // Carrega os itens
        }

        private void LoadDensidadeItems()
        {
            try
            {
                // Inicializa os dados
                DensidadeItems = new ObservableCollection<DensidadeItem>
                {
                    new DensidadeItem { Codigo = "457889", Data = "25/03/2030", Cliente = "Martis LTDA", Obra = "Boulevard", EstacaLocal = "23", GrauCompactacao = "98%" },
                    new DensidadeItem { Codigo = "457890", Data = "26/03/2030", Cliente = "Construtora X", Obra = "Projeto Y", EstacaLocal = "45", GrauCompactacao = "95%" }
                
                };

                // Atualiza o BindingContext
                OnPropertyChanged(nameof(DensidadeItems));

                // Mensagem de verificação
                System.Diagnostics.Debug.WriteLine($"Itens carregados: {DensidadeItems.Count}");
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar os itens: {ex.Message}");
                DisplayAlert("Erro", "Não foi possível carregar os itens.", "OK");
            }
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