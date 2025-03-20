using SQLite;

namespace EngeTerraPlan.Models
{
    public class DensidadeInSituModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Data { get; set; }
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
        public double PesoSoloUmidoRec { get; set; }
        
        // Novos campos para o terceiro formulário
        public double DensidadeSoloUmido { get; set; }
        public double DensidadeSoloSeco { get; set; }
        public string RegistroAmostra { get; set; }
        public double DensidadeMaxima { get; set; }
        public double UmidadeOtima { get; set; }
        public string GrauCompactacao { get; set; }
    }
}
