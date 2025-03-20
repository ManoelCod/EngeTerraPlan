namespace CalculationNBR
{
    public static class CalculationLibrary
    {
        public static double CalcularDiferenca(double antes, double depois)
        {
            return antes - depois;
        }

        public static double CalcularCompactacao(double densidadeSeca, double densidadeMaxima)
        {
            if (densidadeMaxima == 0)
                throw new DivideByZeroException("A densidade máxima não pode ser zero.");

            return (densidadeSeca / densidadeMaxima) * 100;
        }

        // Outros métodos podem ser adicionados aqui, por exemplo:
        public static double CalcularDensidadeSolo(double pesoSoloUmido, double volumeFuro)
        {
            if (volumeFuro == 0)
                throw new DivideByZeroException("O volume do furo não pode ser zero.");

            return pesoSoloUmido / volumeFuro;
        }
        public static double CalcularPesoDaAreiaDoFuro(double diferenca, double pesoFunil)
        {
            return diferenca - pesoFunil;
        }

        public static double CalcularVolumeFuro(double pesoFuro, double densidadeAreia)
        {
            if (densidadeAreia == 0)
                throw new DivideByZeroException("A densidade da areia não pode ser zero.");

            double volumeFuro = pesoFuro / densidadeAreia;
            return Math.Round(volumeFuro, 4); // Arredondar para 4 casas decimais
        }

        public static double CalcularPesoDoSoloUmido(double pesoSoloUmidoRec, double taraRecipiente)
        {
            return pesoSoloUmidoRec - taraRecipiente;
        }

        public static double CalcularDensidadeSoloUmido(double pesoDoSoloUmido, double volumeFuro)
        {
            if (volumeFuro == 0)
                throw new DivideByZeroException("O volume do furo não pode ser zero.");

            return pesoDoSoloUmido / volumeFuro;
        }
        public static double CalcularDensidadeSoloSeco(double densidadeSoloUmido, double umidadePercentual)
        {
            if (umidadePercentual == 0)
                throw new DivideByZeroException("A umidade percentual não pode ser zero.");

            return densidadeSoloUmido / (umidadePercentual + 100);
        }
    }
}
