using System.Windows.Input;
using EngeTerraPlan.Data;
using EngeTerraPlan.Models;
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
     
        // ações
        public Command SalvarCommand { get; }

        // Construtor
        public DensidadeInSituViewModel()
        {
            AvancarCommand = new Command(ExibirFormulario2);
            VoltarCommand = new Command(ExibirFormulario1);
            SalvarCommand = new Command(SalvarDados);
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

        private void SalvarDados()
        {
            // Criar o modelo com os dados do formulário
            var novoCadastro = new DensidadeInSituModel
            {
                Data = this.Data,
                Estaca = this.Estaca,
                Camada = this.Camada,
                ProfundidadeFuro = double.TryParse(this.ProfundidadeFuro, out var profundidade) ? profundidade : 0,
                EspessuraCamada = double.TryParse(this.EspessuraCamada, out var espessura) ? espessura : 0,
                PosicaoSelecionada = this.PosicaoSelecionada,
                Antes = this.Antes,
                Depois = this.Depois,
                Diferenca = this.Diferenca,
                PesoFunil = this.PesoFunil,
                PesoFuro = this.PesoFuro,
                DensidadeAreia = this.DensidadeAreia,
                VolumeFuro = this.VolumeFuro,
                Umidade = this.Umidade,
                TaraRecipiente = this.TaraRecipiente,
                PesoSoloUmido = this.PesoSoloUmido
            };

            // Inserir no banco de dados
            DatabaseService.Database.Insert(novoCadastro);

            // Exibir o registro recém-adicionado no terminal
            System.Diagnostics.Debug.WriteLine("Novo registro cadastrado:");
            System.Diagnostics.Debug.WriteLine($"ID: {novoCadastro.Id}, Data: {novoCadastro.Data}, Estaca: {novoCadastro.Estaca}, Camada: {novoCadastro.Camada}");
            System.Diagnostics.Debug.WriteLine($"Profundidade: {novoCadastro.ProfundidadeFuro}, Espessura: {novoCadastro.EspessuraCamada}, Posição: {novoCadastro.PosicaoSelecionada}");
            System.Diagnostics.Debug.WriteLine($"Antes: {novoCadastro.Antes}, Depois: {novoCadastro.Depois}, Diferença: {novoCadastro.Diferenca}");
            System.Diagnostics.Debug.WriteLine($"Peso Funil: {novoCadastro.PesoFunil}, Peso Furo: {novoCadastro.PesoFuro}");
            System.Diagnostics.Debug.WriteLine($"Densidade Areia: {novoCadastro.DensidadeAreia}, Volume Furo: {novoCadastro.VolumeFuro}");
            System.Diagnostics.Debug.WriteLine($"Umidade: {novoCadastro.Umidade}, Tara Recipiente: {novoCadastro.TaraRecipiente}, Peso Solo Úmido: {novoCadastro.PesoSoloUmido}");

            // Recuperar todos os registros e listar no terminal
            var todosRegistros = ObterTodosOsRegistros();

            System.Diagnostics.Debug.WriteLine("Lista completa de registros:");
            foreach (var registro in todosRegistros)
            {
                System.Diagnostics.Debug.WriteLine($"ID: {registro.Id}, Data: {registro.Data}, Estaca: {registro.Estaca}, Camada: {registro.Camada}");
                System.Diagnostics.Debug.WriteLine($"Profundidade: {registro.ProfundidadeFuro}, Espessura: {registro.EspessuraCamada}, Posição: {registro.PosicaoSelecionada}");
                System.Diagnostics.Debug.WriteLine($"Antes: {registro.Antes}, Depois: {registro.Depois}, Diferença: {registro.Diferenca}");
                System.Diagnostics.Debug.WriteLine($"Peso Funil: {registro.PesoFunil}, Peso Furo: {registro.PesoFuro}");
                System.Diagnostics.Debug.WriteLine($"Densidade Areia: {registro.DensidadeAreia}, Volume Furo: {registro.VolumeFuro}");
                System.Diagnostics.Debug.WriteLine($"Umidade: {registro.Umidade}, Tara Recipiente: {registro.TaraRecipiente}, Peso Solo Úmido: {registro.PesoSoloUmido}");
            }

            // Exibir mensagem de sucesso
            App.Current.MainPage.DisplayAlert("Sucesso", "Cadastro salvo com sucesso!", "OK");
        }

        public List<DensidadeInSituModel> ObterTodosOsRegistros()
        {
            return DatabaseService.Database.Table<DensidadeInSituModel>().ToList();
        }
    }
}
