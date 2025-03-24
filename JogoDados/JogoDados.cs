using System;

namespace JogoDados
{
    public class JogoDados
    {
        public static Random random = new Random();
        public static int posicaoJogador, posicaoComputador;
        public const int chegada = 30;
        public const int jogadaExtra = 6;

        public static void ResetarJogo()
        {
            posicaoJogador = 0;
            posicaoComputador = 0;
        }

        public static int RolarDado()
        {
            return random.Next(1, 7);
        }

        public static void NewPosicao(ref int posicao, int rolagem)
        {
            posicao += rolagem;

            if (posicao >= chegada)
            {
                posicao = chegada;
                Console.WriteLine($"Posição atual: {posicao}");
                return;
            }

            bool bonus = false, penalidade = false;

            if (posicao == 5 || posicao == 10 || posicao == 15)
            {
                Console.WriteLine("Bônus +3");
                posicao += 3;
                bonus = true;
            }
            else if (posicao == 7 || posicao == 13 || posicao == 20)
            {
                Console.WriteLine("Penalidade -2");
                posicao -= 2;
                penalidade = true;
            }

            Console.WriteLine($"Posição atual: {posicao}");

            if (bonus || penalidade)
            {
                Console.WriteLine($"\nNova posição: {posicao}");
            }
        }

        public static void TurnoJogador(ref int posicaoJogador)
        {
            bool turnoExtra;
            do
            {
                turnoExtra = false;

                int rolagem = RolarDado();
                Console.WriteLine($"Valor no dado: {rolagem}");
                NewPosicao(ref posicaoJogador, rolagem);

                if (posicaoJogador >= chegada)
                {
                    posicaoJogador = chegada;
                    return;
                }

                if (rolagem == jogadaExtra)
                {
                    Console.WriteLine("Você ganhou um turno extra!");
                    turnoExtra = true;
                }
            } while (turnoExtra);
        }

        public static void TurnoComputador(ref int posicaoAdversario)
        {
            bool turnoExtra;
            do
            {
                turnoExtra = false;

                int rolagem = RolarDado();
                Console.WriteLine($"Valor no dado: {rolagem}");
                NewPosicao(ref posicaoAdversario, rolagem);

                if (posicaoAdversario >= chegada)
                {
                    posicaoAdversario = chegada;
                    return;
                }
                
                if (rolagem == jogadaExtra)
                {
                    Console.WriteLine("O Computador ganhou um turno extra!");
                    turnoExtra = true;
                }
            } while (turnoExtra);
        }

        public static bool DeveContinuar()
        {
            return posicaoJogador < chegada && posicaoComputador < chegada;
        }
        public static bool JogadorVenceu()
        {
            return posicaoJogador >= chegada;
        }
        public static bool ComputadorVenceu()
        {
            return posicaoComputador >= chegada;
        }
    }

}
