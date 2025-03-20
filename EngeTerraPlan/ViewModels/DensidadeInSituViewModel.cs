using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace EngeTerraPlan.ViewModels
{
    public class DensidadeInSituViewModel : BaseViewModel
    {
        // Propriedades para bindings simples (não precisam de SetProperty)
        public double Antes { get; set; }
        public double Depois { get; set; }
        public double Diferenca { get; set; }
        public double PesoFunil { get; set; }
        public double PesoFuro { get; set; }
        public double DensidadeAreia { get; set; }
        public double VolumeFuro { get; set; }
        public double Umidade { get; set; }
        public double TaraRecipiente { get; set; }
        public double PesoSoloUmido { get; set; }

        // Propriedades que requerem notificações explícitas
        private string _data;
        public string Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        private string _estaca;
        public string Estaca
        {
            get => _estaca;
            set => SetProperty(ref _estaca, value);
        }

        private string _camada;
        public string Camada
        {
            get => _camada;
            set => SetProperty(ref _camada, value);
        }

        private string _profundidadeFuro;
        public string ProfundidadeFuro
        {
            get => _profundidadeFuro;
            set => SetProperty(ref _profundidadeFuro, value);
        }

        private string _espessuraCamada;
        public string EspessuraCamada
        {
            get => _espessuraCamada;
            set => SetProperty(ref _espessuraCamada, value);
        }

        private string _posicaoSelecionada;
        public string PosicaoSelecionada
        {
            get => _posicaoSelecionada;
            set => SetProperty(ref _posicaoSelecionada, value);
        }

        // Controle de visibilidade dos formulários
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

        // Comandos de navegação
        public ICommand AvancarCommand { get; }
        public ICommand VoltarCommand { get; }

        // Construtor
        public DensidadeInSituViewModel()
        {
            AvancarCommand = new Command(ExibirFormulario2);
            VoltarCommand = new Command(ExibirFormulario1);
        }

        // Métodos para alternar visibilidade
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
    }
}
