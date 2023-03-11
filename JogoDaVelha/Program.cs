internal class Program
{
    private static void Main(string[] args)
    {
        bool ganhou = false;
        bool verifica = false;
        int cont_rodadas = 0;
        int lugar_cerquilha = 0;
        int linha = 0, coluna = 0;

        char[,] cerquilha = {{'1','2','3' },
                             { '4','5','6' },
                             { '7','8','9'} };

        //Inicializacao(cerquilha);
        //Console.WriteLine("EXIBIÇÃO DOS VALORES");
        //Exibicao(cerquilha);


        while (ganhou == false && cont_rodadas < 9)
        {
            cont_rodadas++;
            Exibicao(cerquilha);

            do
            {
                Console.WriteLine("Rodada: " + cont_rodadas);
                Console.Write("DIGITE A POSICAO[1 - 9]: ");
                lugar_cerquilha = int.Parse(Console.ReadLine());

                switch (lugar_cerquilha)
                {
                    case 1:
                        linha = 0;
                        coluna = 0;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 2:
                        linha = 0;
                        coluna = 1;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 3:
                        linha = 0;
                        coluna = 2;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 4:
                        linha = 1;
                        coluna = 0;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 5:
                        linha = 1;
                        coluna = 1;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 6:
                        linha = 1;
                        coluna = 2;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 7:
                        linha = 2;
                        coluna = 0;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 8:
                        linha = 2;
                        coluna = 1;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                    case 9:
                        linha = 2;
                        coluna = 2;
                        verifica = VerificaPosicao(linha, coluna);
                        break;

                }

            } while (lugar_cerquilha < 1 || lugar_cerquilha > 9 || verifica == false);

            MarcarPosicao(linha, coluna, cerquilha, cont_rodadas);

            if (cont_rodadas >= 5)
            {
                int i = 0;
                while (i < 3 && ganhou == false)
                {
                    ganhou = VerificaLinha(i, cerquilha);
                    i++;
                }

                i = 0;
                while (i < 3 && ganhou == false)
                {
                    ganhou = VerificaColuna(i, cerquilha);
                    i++;
                }

                if (ganhou == false)
                {
                    ganhou = VerificaDiagonalPrincipal(cerquilha);

                    if (ganhou == false)
                    {
                        ganhou = VerificaDiagonalSecundaria(cerquilha);
                    }
                }


            }


        }

        if (ganhou == true)
        {
            if (cont_rodadas % 2 == 0)
            {
                Console.WriteLine("O jogador com marcação de BOLA ganhou !!!");
            }
            else
            {
                Console.WriteLine("O jogador com marcacao de X ganhou !!!");
            }
        }
        else
        {
            Console.WriteLine("DEU VELHA !!!");
        }


        /*
        void Inicializacao(char[,] cerquilha)
        {
 
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
       
                  cerquilha[linha, coluna] = 'l'; 
                  
                }
            }
        }
        */

        void Exibicao(char[,] cerquilha)
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Console.Write(cerquilha[linha, coluna] + "  ");
                }

                Console.WriteLine();
            }
        }

        bool VerificaPosicao(int linha, int coluna)
        {
            bool verifica = false;

            if (cerquilha[linha, coluna] != 'X' && cerquilha[linha, coluna] != 'O')
            {
                verifica = true;
            }

            return verifica;
        }

        void MarcarPosicao(int linha, int coluna, char[,] cerquilha, int cont_rodadas)
        {
            if (cont_rodadas % 2 == 0)
            {
                cerquilha[linha, coluna] = 'O';
            }
            else
            {
                cerquilha[linha, coluna] = 'X';
            }
        }

        bool VerificaLinha(int linha, char[,] cerquilha)
        {
            bool achou = false;
            int cont_bola = 0;
            int cont_x = 0;

            for (int c = 0; c < cerquilha.GetLength(1); c++)
            {
                if (cerquilha[linha, c] == 'O')
                {
                    cont_bola++;
                }
                if (cerquilha[linha, c] == 'X')
                {
                    cont_x++;
                }
            }

            if (cont_bola == 3 || cont_x == 3)
            {
                achou = true;
            }

            return achou;

        }

        bool VerificaColuna(int coluna, char[,] cerquilha)
        {
            bool achou = false;
            int cont_bola = 0;
            int cont_x = 0;

            for (int l = 0; l < cerquilha.GetLength(0); l++)
            {
                if (cerquilha[l, coluna] == 'O')
                {
                    cont_bola++;
                }
                if (cerquilha[l, coluna] == 'X')
                {
                    cont_x++;
                }
            }

            if (cont_bola == 3 || cont_x == 3)
            {
                achou = true;
            }

            return achou;
        }

        bool VerificaDiagonalPrincipal(char[,] cerquilha)
        {
            bool achou = false;
            int cont_bola = 0;
            int cont_X = 0;

            for (int i = 0; i < 3; i++)
            {
                if (cerquilha[i, i] == 'O')
                {
                    cont_bola++;
                }
                if (cerquilha[i, i] == 'X')
                {
                    cont_X++;
                }
            }

            if (cont_bola == 3 || cont_X == 3)
            {
                achou = true;
            }

            return achou;
        }

        bool VerificaDiagonalSecundaria(char[,] cerquilha)
        {
            bool achou = false;
            int cont_bola = 0;
            int cont_X = 0;

            for (int linha = 0, coluna = 2; linha < 3; linha++, coluna--)
            {
                if (cerquilha[linha, coluna] == 'O')
                {
                    cont_bola++;
                }
                if (cerquilha[linha, coluna] == 'X')
                {
                    cont_X++;
                }
            }

            if (cont_bola == 3 || cont_X == 3)
            {
                achou = true;
            }
            return achou;
        }
    }
}
