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
        static double salario=0, acumIR=0; // para armazenar valor do salário e acumular IR calculados
        static string nome=" "; // para armazenar nome do funcionário

        static void Main(string[] args) // método principal 
        {
            // Variáveis locais do método main
            double resultado; // para armazenar o retorno do cálculo do IR
            int contfunc = 0; // para ir contando os funcionários que terão IR calculado
            char continua = ' '; // para armazenar a resposta do usuário se deseja continuar um novo loop do programa
            Console.WriteLine("Calcula o Imposto de Renda retido na fonte\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen; // Mudança de cor de fundo, ou seja, cor do caracter
            do
            {
                contfunc++; // uso da atribuição de valor alternativa, que incrementa em 1 tal variável
                Entrada_de_Dados(contfunc); // chamada de método do tipo procedimento com passagem de parâmetros
                resultado = Calcula_IRFonte(); // chamada do método do tipo função sem passagem de parâmetro
                Mostra_Resultados(resultado, contfunc); // chamada de método do tipo procedimento com passagem de parâmetros
                continua = Tras_Respostas("Deseja executar este programa novamente? (s/n): "); // chamada de método do tipo função com passagem de parâmetros
            } while (continua == 's' || continua == 'S');
            Encerramento(); // chamada de método do tipo procedimento sem passagem de parâmetro
        }

        static void Entrada_de_Dados (int qtd) // detalhamento do método do tipo procedimento com passagem de parâmetro
        {
            Console.Write("\nInforme o nome do {0}º funcionário: ", qtd);
            nome = Console.ReadLine();
            Console.Write("Informe o valor do salário de " + nome + ": ");
            while (!double.TryParse(Console.ReadLine(), out salario)||(salario<=0)) // consistência do valor do salário, para só aceitar número que possa ser transformado em double e maior que zero
            Console.Write("Salário deve ser numérico e maior que zero! Digite corretamente o salário de {0}: ",nome);
    }
        static double Calcula_IRFonte() // detalhamento do método do tipo função sem passagem de parâmetro
        {
            double desconto; // declaração de variável local para cálculo do IR na Fonte
            if (salario <= 1903.98)
            {
                desconto = 0;
            }
            else
            {
                if (salario <= 2826.65)
                {
                    desconto = salario * 7.5 / 100 - 142.60;
                }
                else
                {
                    if (salario <= 3751.05)
                    {
                        desconto = salario * 15 / 100 - 354.80;
                    }
                    else
                    {
                        if (salario <= 4664.68)
                        {
                            desconto = salario * 22.5 / 100 - 636.13;
                        }
                        else
                        {
                            desconto = salario * 27.5 / 100 - 869.36;
                        }
                    }
}
            }
            acumIR += desconto; // uso da atribuição de valor alternativa, que incrementa o valor do desconto no acumulador de IR
            return desconto;
        }

        static void Mostra_Resultados(double resultado, int contfunc) // detalhamento do método do tipo função com passagem de parâmetros
        {
            Console.WriteLine("Funcionário {0}({1}), que tem salário de R$ {2:N}, terá desconto de IR de R${3:N}\n",contfunc,nome, salario, resultado);
        }

        static char Tras_Respostas(string pergunta) // detalhamento do método do tipo função com passagem de parâmetro
        {
            char resp; // variável local
            Console.Write(pergunta);
            resp = Console.ReadKey().KeyChar; // lê imediatamente o caracter da tecla digitada
            while(resp!='s' && resp!='S' && resp!='n' && resp!='N') // consistência de resp (resposta), usando o indicativo de caracter
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
            Console.WriteLine("\nO Acumulo de IR que será descontado na fonte é R$ {0:N}\n", acumIR);
            Console.ForegroundColor = ConsoleColor.DarkMagenta; // // Mudança de cor de fundo 
            Console.Write("\nFim do programa IRFonte. Pressione qualquer tecla para encerrar...");
            Console.ReadKey();

       }
  }

}

