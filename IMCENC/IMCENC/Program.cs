using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRFonte
{
    class Program
    {
        // VARIÁVEIS GLOBAIS
        static double peso = 0; // para armazenar valor do salário e acumular IR calculados
        static string nome = " "; // para armazenar nome do funcionário
        static float altura = 0;

        static void Main(string[] args)  
        {
            // Variáveis locais do método main
            double resultado; 
            int contfunc = 0; 
            char continua = ' '; 
            Console.WriteLine("Calcula o Indice de Massa Corporal\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen; 
            do
            {
                contfunc++; 
                Entrada_de_Dados(contfunc); 
                resultado = Calcula_IMC(); 
                Mostra_Resultados(resultado, contfunc); 
                continua = Tras_Respostas("Deseja executar este programa novamente? (s/n): "); 
            } while (continua == 's' || continua == 'S');
            Encerramento(); 
        }

        static void Entrada_de_Dados(int qtd, float altura) 
        {
            Console.Write("\nInforme o nome do {0}º da pessoa: ", qtd);
            nome = Console.ReadLine();
            Console.Write("Informe o valor do peso de " + nome + ": ");
            while (!double.TryParse(Console.ReadLine(), out peso) || (peso <= 0)) 
            Console.Write("Informe o valor da altura de " + nome + ": ");
            while (!float.TryParse(Console.ReadLine(), out altura) || (altura <= 0))
                Console.Write("A altura deve ser numérico e maior que zero! Digite corretamente a altura de {0}: ", nome);
                
        }
        static double Calcula_IMC() 
        {
            double IMC; 
            if (IMC <= 20.7)
            {
                IMC = peso * (altura * altura);
            }
            else
            {
                if (IMC <= 2826.65)
                {
                    IMC = peso * (altura * altura);
                }
                else
                {
                    if (peso <= 3751.05)
                    {
                        IMC = peso * 15 / 100 - 354.80;
                    }
                    else
                    {
                        if (peso <= 4664.68)
                        {
                            IMC = peso * 22.5 / 100 - 636.13;
                        }
                        else
                        {
                            IMC = peso * 27.5 / 100 - 869.36;
                        }
                    }
                }
            }
            altura += IMC; // uso da atribuição de valor alternativa, que incrementa o valor do desconto no acumulador de IR
            return IMC;
        }

        static void Mostra_Resultados(double IMC, float altura, int contfunc) // detalhamento do método do tipo função com passagem de parâmetros
        {
            Console.WriteLine("A pessoa {0}, que tem o peso de ({1}), e a altura de {2:N} terá o IMC de {3:N}\n", contfunc, peso, altura, IMC);
        }

        static char Tras_Respostas(string pergunta) // detalhamento do método do tipo função com passagem de parâmetro
        {
            char resp; // variável local
            Console.Write(pergunta);
            resp = Console.ReadKey().KeyChar; // lê imediatamente o caracter da tecla digitada
            while (resp != 's' && resp != 'S' && resp != 'n' && resp != 'N') // consistência de resp (resposta), usando o indicativo de caracter
            {
                Console.Write("\nResposta inválida! Digite s ou n: "); // dá mensagem de erro e pede para digitar novamente
                resp = Console.ReadKey().KeyChar; // volta a ler o caracter da tecla digitada
            }
            Console.Write("\n");
            return resp;
        }

        static void Encerramento() // detalhamento do método do tipo procedimento sem passagem de parâmetro
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Mudança da cor do fundo
            Console.WriteLine("\nO Acumulado de IR que será descontado na fonte é R$ {0:N}\n", altura);
            Console.ForegroundColor = ConsoleColor.DarkMagenta; // Mudança da cor do fundo
            Console.Write("\nFim do programa IRFonte. Pressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}

