using System;

namespace JogoDados
{
    class Program
    {
        static void Main(string[] args)
        {
            bool jogarNovamente;
            do
            {
                JogoDados.ResetarJogo();
                Console.Clear();
                Console.WriteLine("________________________________");
                Console.WriteLine("       Inicio do Jogo");
                Console.WriteLine(" Pressione Enter para iniciar");
                Console.WriteLine("________________________________");
                Console.ReadLine();

                while (JogoDados.DeveContinuar())
                {
                    TurnoJogador();
                    TurnoComputador();

                    if (JogoDados.JogadorVenceu() || JogoDados.ComputadorVenceu()) break;
                    
                }

                Console.WriteLine("________________________________");
                Console.WriteLine(JogoDados.JogadorVenceu() ? "         Você venceu!" : "         Você perdeu!");
                Console.WriteLine("________________________________");

                Console.WriteLine("Deseja jogar novamente? (S/N)");
                jogarNovamente = Console.ReadLine().Trim().ToUpper() == "S";
            } while (jogarNovamente);
        }

        static void TurnoJogador()
        {
            bool turnoExtra;
            do
            {
                turnoExtra = false;
                Console.WriteLine("________________________________");
                Console.WriteLine("Sua vez");
                Console.ReadLine();
                int rolagem = JogoDados.RolarDado();
                Console.WriteLine($"Valor no dado: {rolagem}");
                JogoDados.NewPosicao(ref JogoDados.posicaoJogador, rolagem);

                if (JogoDados.posicaoJogador >= JogoDados.chegada)
                {
                    JogoDados.posicaoJogador = JogoDados.chegada;
                    return;
                }

                if (rolagem == JogoDados.jogadaExtra)
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
                Console.WriteLine("\nVez do Computador\n");
                int rolagem = JogoDados.RolarDado();
                Console.WriteLine($"Valor no dado: {rolagem}");
                JogoDados.NewPosicao(ref JogoDados.posicaoComputador, rolagem);
                Console.WriteLine("________________________________");

                if (JogoDados.posicaoComputador >= JogoDados.chegada)
                {
                    JogoDados.posicaoComputador = JogoDados.chegada;
                    return;
                }

                if (rolagem == JogoDados.jogadaExtra)
                {
                    Console.WriteLine("O Computador ganhou um turno extra!");
                    turnoExtra = true;
                }
            } while (turnoExtra);
        }
    }
}
