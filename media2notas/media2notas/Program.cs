using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace media2notas
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;
            float nota1, nota2, media;

            Console.Write("Digite o nome do aluno(a): "); //pede dado
            nome = Console.ReadLine(); //libera teclado para usuário digitar o nome do aluno

            Console.Write("Digite a primeira nota de {0}: ",nome); //solicita nota1
            nota1 = float.Parse(Console.ReadLine()); //recebe dado e converte string para float

            Console.Write("Digite a segunda nota: ",nome=" "); //solicita nota2 usando concatenação0
            nota2 = float.Parse(Console.ReadLine()); //recebe dado, converte e salva na variável nota2

            media = (nota1 + nota2) / 2; //fórmula de cálculo de média aritmética simples

            Console.Write("O aluno(a) {0}, com notas {1} e {2}, tem média {3}",nome, nota1, nota2, media); //trecho inicial da frase que apresenta o resultado

            Console.WriteLine(" e está {0}\n\n", media>= 6?"aprovado":"reprovado");

            Console.WriteLine("aproveitando e fazendo combinações das notas...");

            Console.WriteLine("nota1 {0} é {1} que nota2 {2}\n", nota1, nota1>nota2? "maior":nota1<nota2?"menor":"igual", nota2); //ternário dentro de ternário

            Console.Write("pressione qualquer tecla para encerrar o programa");

            Console.ReadKey(); //liberação do teclado para usuário digitar apenas 1 tecla

            

        }
    }
}
