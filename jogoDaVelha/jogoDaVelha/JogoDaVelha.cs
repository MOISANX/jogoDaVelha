using System;
using System.Data;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;
        public string player , player1,player2;
        int vitoriaPlayer1 = 0;
        int derrotaPlayer1 = 0;
        int vitoriaPlayer2 = 0;
        int derrotaPlayer2 = 0;
        int empate = 0;
        int continuar = 0;
        

      
        

        public JogoDaVelha()
        {
            fimDeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n-JOGO DA VELHA");
            Console.WriteLine(" Game Start[1]");
            Console.WriteLine(" Creditos[2]");
            Console.WriteLine(" Placar[3]");
            Console.WriteLine(" Sair[4]");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                   NomeDoPlayer();break;
                    case 2:Creditos(); break;
                case 3:verPlacar();break;
                    case 4:Environment.Exit(4); break;
                  

            
            
            }
        
        }

        public void NomeDoPlayer() 
        {

            Console.Clear();
            Console.WriteLine("Escolha o nome do primeiro player");
             player1 = Console.ReadLine();

            Console.WriteLine("Escolha o nome do segundo player");
             player2 = Console.ReadLine();

            Iniciar();


        }
        

        public void Iniciar()
        {
            Console.Clear();
           
            player = player1;
            while (!fimDeJogo)
            {

                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerficarFimDeJogo();
                MudarVez();
            }
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';

            if (vez == 'X')
            {

                player = player1;

            }
            else { 
            
                player = player2;
            
            }
        }

        private void VerficarFimDeJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitória de {player} {vez}");

                if (player == player1)
                {

                    vitoriaPlayer1++;
                    derrotaPlayer2++;

                }
                else if (player == player2)
                {
                    vitoriaPlayer2++;
                    derrotaPlayer1++;

                }
                else {

                    empate++;
                
                }
                Console.WriteLine("PLACAR: ");
                Console.WriteLine($"PLAYER1-{player1} = {vitoriaPlayer1} / PLAYER2-{player2} = {vitoriaPlayer2}");
                Console.WriteLine("Deseja jogar outra partida ?(1-sim/2-nao)");
                 continuar = int.Parse(Console.ReadLine());


                if (continuar == 1)
                {
                    Console.Clear();
                    fimDeJogo = false;
                    posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    quantidadePreenchida = 0;
                    Iniciar();




                }
                else if (continuar == 2)
                {

                    Console.Clear();
                    new JogoDaVelha().Menu();
                    fimDeJogo = false;



                }
                Console.ReadKey();
            }

            if (quantidadePreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo!!! EMPATE");
                Console.WriteLine("PLACAR: ");
                Console.WriteLine($"PLAYER1-{player1} = {vitoriaPlayer1} / PLAYER2-{player2} = {vitoriaPlayer2}");
                Console.WriteLine("Deseja jogar outra partida ?(1-sim/2-nao)");
                 continuar = int.Parse(Console.ReadLine());


                if (continuar == 1)
                {
                    Console.Clear();
                    fimDeJogo = false;
                    posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    quantidadePreenchida = 0;
                    Iniciar();




                }
                else if (continuar == 2)
                {

                    Console.Clear();
                    new JogoDaVelha().Menu();
                    fimDeJogo = false;


                }
            }
        }

        private void verPlacar()
        {

            Console.Clear();
            Console.WriteLine("PLACAR:");
            Console.WriteLine($"{player1}: {vitoriasPlayer1} vitorias, {derrotasPlayer1} derrotas");
            Console.WriteLine($"{player2}: {vitoriasPlayer2} vitorias, {derrotasPlayer2} derrotas");
            Console.WriteLine($"Quantas vezes ocorreu o empate :{empate}");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Menu();


         }

       

      
        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }

        private void LerEscolhaDoUsuario()
        {
           
            Console.WriteLine($"       Agora é a vez de {player} {vez}, entre uma posição de 1 a 9 que esteja disponível na tabela");

             bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
               
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            posicoes[indice] = vez;
            quantidadePreenchida++;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            return  posicoes[indice] != 'O' && posicoes[indice] != 'X';
        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"\n\t\t\t\t\t  {posicoes[0]}  |  {posicoes[1]}  |  {posicoes[2]}  \n" +
                   $"\t\t\t\t\t_____|_____|_____\n" +
                   $"\t\t\t\t\t     |     |     \n"+
                   $"\t\t\t\t\t  {posicoes[3]}  |  {posicoes[4]}  |  {posicoes[5]}  \n" +
                   $"\t\t\t\t\t_____|_____|_____\n" +
                    $"\t\t\t\t\t     |     |     \n" +
                   $"\t\t\t\t\t  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }

        private void Creditos() 
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\t\t\tAgradecimentos as pessoas que possibilitaram eu concluir esse projeto:");
            Console.WriteLine("\t\t\tCanal do youtube DevJonas link:https://www.youtube.com/watch?v=4ffSCMF8SHE&t=428s");
            Console.WriteLine("\t\t\tAo canal do youtube pesca link:https://www.youtube.com/watch?v=U7w5YYbwh40&t=397s ");
            Console.WriteLine("\t\t\tAo professor Hugo que mim possibilitou ver metodos de uma outra maneira. ");
            Console.WriteLine("\t\t\tE por ultimo mas não menos importante a minha pessoa pela perserverança e força de vontade.");
            Console.ReadKey();
            Menu();
        
        }
    }



}