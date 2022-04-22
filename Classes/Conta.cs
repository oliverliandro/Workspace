using System.Text;
using Digi.Bank.Enums;

namespace Digi.Bank.Classes
{
    public class Conta
    {
        public Conta(E_Tipo_Conta tipoConta, string titular, double saldo, double chequeEspecial)
        {
            TipoConta = tipoConta;
            Titular = titular;
            Saldo = saldo;
            ChequeEspecial = chequeEspecial;

        }

        private E_Tipo_Conta TipoConta { get; set; }
        private string Titular { get; set; }
        private double Saldo { get; set; }
        private double ChequeEspecial { get; set; }


        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (ChequeEspecial * -1))
                return false;

            Saldo -= valorSaque;
            return true;
        }

        public bool Depositar(double valorDesposito)
        {
            Saldo += valorDesposito;
            return true;
        }

        public bool Transferir(double valorTranferencia, Conta contaDestino)
        {
            if (!Sacar(valorTranferencia))
            {
                return false;
            }

            return contaDestino.Depositar(valorTranferencia);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Titular.................: {Titular}");
            sb.AppendLine($"Tipo de Conta...........: {TipoConta.GetHashCode()}");
            sb.AppendLine($"Saldo da Conta..........: {Saldo}");
            sb.AppendLine($"Saldo Cheque Especial...: {ChequeEspecial}");

            return sb.ToString();
        }

    }
}