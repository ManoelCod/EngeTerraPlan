using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace EngeTerraPlan.ViewModels
{
    public class DensidadeInSituViewModel : BaseViewModel
    {
        private string _data;
        private string _estaca;
        private string _camada;
        private string _profundidadeFuro;
        private string _espessuraCamada;
        private string _posicaoSelecionada;

        // Propriedades com notificações de mudança (Binding)
        public string Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        public string Estaca
        {
            get => _estaca;
            set => SetProperty(ref _estaca, value);
        }

        public string Camada
        {
            get => _camada;
            set => SetProperty(ref _camada, value);
        }

        public string ProfundidadeFuro
        {
            get => _profundidadeFuro;
            set => SetProperty(ref _profundidadeFuro, value);
        }

        public string EspessuraCamada
        {
            get => _espessuraCamada;
            set => SetProperty(ref _espessuraCamada, value);
        }
        public string PosicaoSelecionada
        {
            get => _posicaoSelecionada;
            set => SetProperty(ref _posicaoSelecionada, value);
        }

        // comandos para alternar formulario

        private bool _mostrarFormulario1 = true;
        public bool MostrarFormulario1
        {
            get => _mostrarFormulario1;
            set => SetProperty(ref _mostrarFormulario1, value);
        }

        private bool _mostrarFormulario2 = false;
        public bool MostrarFormulario2
        {
            get => _mostrarFormulario2;
            set => SetProperty(ref _mostrarFormulario2, value);
        }

        // Comando para o botão "Avançar e voltar"
        public Command AvancarCommand { get; }
        public Command VoltarCommand { get; }

        // Construtor
        public DensidadeInSituViewModel()
        {
            AvancarCommand = new Command(ExibirFormulario2);
            VoltarCommand = new Command(ExibirFormulario1);
        }

        private void ExibirFormulario2()
        {
            MostrarFormulario1 = false;
            MostrarFormulario2 = true;
        }

        private void ExibirFormulario1()
        {
            MostrarFormulario1 = true;
            MostrarFormulario2 = false;
        }

        // Função executada ao pressionar o botão "Avançar"
        private void ExecutarAvancar()
        {
            if (string.IsNullOrWhiteSpace(Data) ||
                string.IsNullOrWhiteSpace(Estaca) ||
                string.IsNullOrWhiteSpace(Camada))
            {
                // Exemplo de validação
                App.Current.MainPage.DisplayAlert("Erro", "Preencha todos os campos obrigatórios.", "OK");
                return;
            }

            // Simular navegação ou lógica de processamento
            App.Current.MainPage.DisplayAlert("Sucesso", "Dados enviados com sucesso!", "OK");
        }
    }
}
