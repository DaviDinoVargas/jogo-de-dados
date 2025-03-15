using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDados
{
    class JogoDados
    {
        static Random random = new Random();
        static int posicaoJogador = 0, posicaoAdversario = 0;
        const int chegada = 30;

        static void Main(string[] args)
        {
            Console.WriteLine("Inicio do Jogo");
            Console.WriteLine("Enter para iniciar");
            while (posicaoJogador < chegada && posicaoAdversario < chegada)
            {
                TurnoJogador();
                if (posicaoJogador >= chegada) break;
                TurnoComputador();
            }
            Console.WriteLine(posicaoJogador >= chegada ? "você venceu" : "você perdeu");
            Console.ReadLine();
        }

        static void TurnoJogador()
        {
            bool turnoExtra;
            do
            {
                turnoExtra = false;
                Console.WriteLine("\nSua vez");
                Console.ReadLine();
                int rolagem = RolarDado();
                NewPosicao(ref posicaoJogador, rolagem);
                if (rolagem == 6)
                {
                    Console.WriteLine("você ganhou um turno extra");
                    turnoExtra = true;
                }
            }
            while (turnoExtra);

            }
        

        static void TurnoComputador()
        {
            Console.WriteLine("\nVez do Computador");
            int rolagem = RolarDado();
            NewPosicao(ref posicaoAdversario, rolagem);

        }

        static int RolarDado()
        {
            return random.Next(1, 7);
        }
        static void NewPosicao(ref int posicao, int rolagem)
        {
            posicao += rolagem;
            Console.WriteLine($"valor no dado:{rolagem}\nposicão atual:{posicao}\n");

            bool bonus = false, penalidade = false;
            
                if (posicao == 5 || posicao == 10 || posicao == 15)
                {
                    Console.WriteLine("Bonus +3");
                    posicao += 3;
                    bonus = true;
                }
                else if (posicao == 7 || posicao == 13 || posicao == 20)
                {
                    Console.WriteLine("penalidade -2");
                    posicao -= 2;
                    penalidade = true;

                }

            if (bonus || penalidade)
            {
                Console.WriteLine($"\nnova posição:{posicao}");
            }
        }


    }

}
