using System;

namespace DIO.Bank
{
    public class Conta
    {
        // atributos

        public Conta(double _Saldo, double _credito, string _nome, TipoConta _tipoConta)
        {
            this._Saldo = _Saldo;
            this._credito = _credito;
            this._nome = _nome;
            this._tipoConta = _tipoConta;

        }
        private double _Saldo { get; set; }
        private double _credito { get; set; } // tipo cheque especial
        private string _nome { get; set; }
        private TipoConta _tipoConta { get; set; }

        public bool sacar(double valorSaque)
        {
            if ((this._Saldo - valorSaque) < ((this._credito *-1)))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            } 
            this._Saldo -= valorSaque;
            Console.WriteLine("O saldo atual da conta: {0} é {1}", this._nome, this._Saldo);
            return true;
        }

        public void depositar(double valorDeposito)
        {
            this._Saldo += valorDeposito;
            Console.WriteLine("O valor atual do saldo da conta: {0} é de {1}", this._nome, this._Saldo);
        }

        public bool transferir(double valor, Conta contaDestino)
        {
            if (this.sacar(valor))
            {
                contaDestino.depositar(valor);
                return true;
            } else
            {
                return false;
            }
        }
    
        public override string ToString()
        {
            string retornar = "";
            retornar += "Tipo Conta " + this._tipoConta + " | ";
            retornar += "Nome " + this._nome + " | ";
            retornar += "Saldo " + this._Saldo + " | ";
            retornar += "Crédito " + this._credito;
            return retornar;
        }

    }
}