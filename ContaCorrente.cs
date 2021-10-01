// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {

        public static double TaxaOperacao { get; private set; }

        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }


  
        public int Agencia { get; }
        
        public int Numero{get;}
        private double _saldo = 100;

        public int ContadorSaquesNaoPermitidos { get; private set; }

        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0)
            {
                string teste = nameof(agencia); //vai ser "numeroAgencia"

                throw new ArgumentException("O argumento Agencia deve ser maior que 0 (Zero).", nameof(agencia));
            }
            if(numero <= 0)
            {
                throw new ArgumentException("O Argumento Numero deve ser maior que 0 (Zero).", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;


            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;

        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferencia.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException e)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada", e);
            }

            Sacar(valor);

            contaDestino.Depositar(valor);
        }
    }
}
