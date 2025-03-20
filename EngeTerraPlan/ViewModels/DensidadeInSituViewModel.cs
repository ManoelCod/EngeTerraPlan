using System.Windows.Input;
using CalculationNBR;
using EngeTerraPlan.Data;
using EngeTerraPlan.Models;
using Microsoft.Maui.Controls;

namespace EngeTerraPlan.ViewModels
{
    public class DensidadeInSituViewModel : BaseViewModel
    {
        // Propriedades para bindings simples (não precisam de SetProperty)
        public double PesoFunil { get; set; }
        public double PesoFuro { get; set; }
        public double DensidadeAreia { get; set; }
        public double VolumeFuro { get; set; }
        public double Umidade { get; set; }
        public double TaraRecipiente { get; set; }
        public double PesoSoloUmido { get; set; }

        // Propriedades que requerem notificações explícitas
        private double _antes;
        public double Antes
        {
            get => _antes;
            set
            {
                SetProperty(ref _antes, value);
                AtualizarDiferenca();
            }
        }

        private double _depois;
        public double Depois
        {
            get => _depois;
            set
            {
                SetProperty(ref _depois, value);
                AtualizarDiferenca();
            }
        }


        private double _diferenca;
        public double Diferenca
        {
            get => _diferenca;
            set => SetProperty(ref _diferenca, value);
        }

        private DateTime _data;
        public DateTime Data
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

        // Propriedades para Formulário 3
        private double _densidadeSoloUmido;
        public double DensidadeSoloUmido
        {
            get => _densidadeSoloUmido;
            set => SetProperty(ref _densidadeSoloUmido, value);
        }

        private double _densidadeSoloSeco;
        public double DensidadeSoloSeco
        {
            get => _densidadeSoloSeco;
            set
            {
                SetProperty(ref _densidadeSoloSeco, value);
                AtualizarGrauCompactacao();
            }
        }

        private string _registroAmostra;
        public string RegistroAmostra
        {
            get => _registroAmostra;
            set => SetProperty(ref _registroAmostra, value);
        }

        private double _densidadeMaxima;
        public double DensidadeMaxima
        {
            get => _densidadeMaxima;
            set => SetProperty(ref _densidadeMaxima, value);
        }

        private double _umidadeOtima;
        public double UmidadeOtima
        {
            get => _umidadeOtima;
            set => SetProperty(ref _umidadeOtima, value);
        }

        private string _grauCompactacao;
        public string GrauCompactacao
        {
            get => _grauCompactacao;
            set => SetProperty(ref _grauCompactacao, value);
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

        private bool _mostrarFormulario3 = false;
        public bool MostrarFormulario3
        {
            get => _mostrarFormulario3;
            set => SetProperty(ref _mostrarFormulario3, value);
        }

        // Comandos de navegação
        public ICommand AvancarParaFormulario2Command { get; }
        public ICommand VoltarParaFormulario1Command { get; }
        public ICommand AvancarParaFormulario3Command { get; }
        public ICommand VoltarParaFormulario2Command { get; }

        // ações
        public Command SalvarCommand { get; }

        // Construtor
        public DensidadeInSituViewModel()
        {
            AvancarParaFormulario2Command = new Command(ExibirFormulario2);
            VoltarParaFormulario1Command = new Command(ExibirFormulario1);
            AvancarParaFormulario3Command = new Command(ExibirFormulario3);
            VoltarParaFormulario2Command = new Command(ExibirFormulario2);
            SalvarCommand = new Command(SalvarDados);
        }

        // Métodos para alternar visibilidade
        private void ExibirFormulario1()
        {
            MostrarFormulario1 = true;
            MostrarFormulario2 = false;
            MostrarFormulario3 = false;
        }

        private void ExibirFormulario2()
        {
            MostrarFormulario1 = false;
            MostrarFormulario2 = true;
            MostrarFormulario3 = false;
        }

        private void ExibirFormulario3()
        {
            MostrarFormulario1 = false;
            MostrarFormulario2 = false;
            MostrarFormulario3 = true;
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
                PesoSoloUmido = this.PesoSoloUmido,
                DensidadeSoloUmido = this.DensidadeSoloUmido,
                DensidadeSoloSeco = this.DensidadeSoloSeco,
                RegistroAmostra = this.RegistroAmostra,
                DensidadeMaxima = this.DensidadeMaxima,
                UmidadeOtima = this.UmidadeOtima,
                GrauCompactacao = this.GrauCompactacao
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
            System.Diagnostics.Debug.WriteLine($"Densidade Solo Úmido: {novoCadastro.DensidadeSoloUmido}, Densidade Solo Seco: {novoCadastro.DensidadeSoloSeco}");
            System.Diagnostics.Debug.WriteLine($"Registro Amostra: {novoCadastro.RegistroAmostra}, Densidade Máxima: {novoCadastro.DensidadeMaxima}, Umidade Ótima: {novoCadastro.UmidadeOtima}");
            System.Diagnostics.Debug.WriteLine($"Grau de Compactação: {novoCadastro.GrauCompactacao}");

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
                System.Diagnostics.Debug.WriteLine($"Densidade Solo Úmido: {registro.DensidadeSoloUmido}, Densidade Solo Seco: {registro.DensidadeSoloSeco}");
                System.Diagnostics.Debug.WriteLine($"Registro Amostra: {registro.RegistroAmostra}, Densidade Máxima: {registro.DensidadeMaxima}, Umidade Ótima: {registro.UmidadeOtima}");
                System.Diagnostics.Debug.WriteLine($"Grau de Compactação: {registro.GrauCompactacao}");
            }

            // Exibir mensagem de sucesso
            App.Current.MainPage.DisplayAlert("Sucesso", "Cadastro salvo com sucesso!", "OK");
        }

        public List<DensidadeInSituModel> ObterTodosOsRegistros()
        {
            return DatabaseService.Database.Table<DensidadeInSituModel>().ToList();
        }


        // Método para atualizar automaticamente a diferença
        private void AtualizarDiferenca()
        {
            Diferenca = CalculationLibrary.CalcularDiferenca(Antes, Depois);
        }

        // Método para calcular o grau de compactação
        private void AtualizarGrauCompactacao()
        {
            try
            {
                var grau = CalculationLibrary.CalcularCompactacao(DensidadeSoloSeco, DensidadeMaxima);
                GrauCompactacao = $"{grau:F2} %";
            }
            catch (DivideByZeroException ex)
            {
                GrauCompactacao = "Erro: " + ex.Message;
            }
        }
    }
}