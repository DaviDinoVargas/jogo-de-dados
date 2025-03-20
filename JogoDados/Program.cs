using System;

namespace JogoDados
{
    class JogoDeDados
    {
        static Random random = new Random();
        static int posicaoJogador, posicaoAdversario;
        const int chegada = 30;

        static void Main(string[] args)
        {
            bool jogarNovamente;
            do
            {
                
                ResetarJogo();
                Console.Clear();
                Console.WriteLine("________________________________");
                Console.WriteLine("       Inicio do Jogo");
                Console.WriteLine(" Pressione Enter para iniciar");
                Console.WriteLine("________________________________");
                Console.ReadLine();

                while (posicaoJogador < chegada && posicaoAdversario < chegada)
                {
                    TurnoJogador();
                    if (posicaoJogador >= chegada) break;
                    TurnoComputador();
                }

                Console.WriteLine("________________________________");
                Console.WriteLine(posicaoJogador >= chegada ? "         Você venceu!" : "         Você perdeu!");
                Console.WriteLine("________________________________");

                Console.WriteLine("Deseja jogar novamente? (S/N)");
                jogarNovamente = Console.ReadLine().Trim().ToUpper() == "S";
            } while (jogarNovamente);
        }

        static void ResetarJogo()
        {
            posicaoJogador = 0;
            posicaoAdversario = 0;
        }

        static void TurnoJogador()
        {
            bool turnoExtra;
            do
            {
                turnoExtra = false;
                Console.WriteLine("________________________________");
                Console.WriteLine("\nSua vez");
                Console.ReadLine();
                int rolagem = RolarDado();
                Console.WriteLine($"Valor no dado: {rolagem}");
                NewPosicao(ref posicaoJogador, rolagem);

                if (posicaoJogador >= chegada)
                {
                    posicaoJogador = chegada;
                    return;
                }

                if (rolagem == 6)
                {
                    Console.WriteLine("Você ganhou um turno extra!");
                    turnoExtra = true;
                }
            } while (turnoExtra);
        }

        static void TurnoComputador()
        {
            bool turnoExtra;
            do
            {
                turnoExtra = false;
                Console.WriteLine("\nVez do Computador");
                int rolagem = RolarDado();
                Console.WriteLine($"Valor no dado: {rolagem}");
                NewPosicao(ref posicaoAdversario, rolagem);
                Console.WriteLine("________________________________");

                if (posicaoAdversario >= chegada)
                {
                    posicaoAdversario = chegada;
                    return;
                }

                if (rolagem == 6)
                {
                    Console.WriteLine("O Computador ganhou um turno extra!");
                    turnoExtra = true;
                }
            } while (turnoExtra);
        }

        static int RolarDado()
        {
            return random.Next(1, 7);
        }

        static void NewPosicao(ref int posicao, int rolagem)
        {
            posicao += rolagem;

            if (posicao >= chegada)
            {
                posicao = chegada;
                return;
            }

            Console.WriteLine($"Posição atual: {posicao}\n");

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

            if (bonus || penalidade)
            {
                Console.WriteLine($"\nNova posição: {posicao}");
            }
        }
    }
}
