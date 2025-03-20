using SQLite;

namespace EngeTerraPlan.Models
{
    public class DensidadeInSituModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Data { get; set; }
        public string Estaca { get; set; }
        public string Camada { get; set; }
        public double ProfundidadeFuro { get; set; }
        public double EspessuraCamada { get; set; }
        public string PosicaoSelecionada { get; set; }

        // Campos do segundo formulário
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
    }
}
