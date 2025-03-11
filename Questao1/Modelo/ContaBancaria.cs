namespace Questao1.Modelo
{
    class ContaBancaria
    {
        public ContaBancaria(int numero, string titular, double saldo)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldo;
        }

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0;
        }

        public int Numero { get; private set; }

        public string Titular { get; private set; }

        public double Saldo { get; private set; }

        public void TrocarNomeTitular(string titular)
        {
            Titular = titular;
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= (valor + 3.5);
        }

        public override string ToString()
        {
            return $"Conta: {Numero}, Titular: {Titular}, Saldo: {Saldo.ToString("C")}";
        }
    }
}
