using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PMaisProx
{
    public class ParMaisProximo
    {
        // [1,3] [2,4] [2,2] [5,4] [3,7]
        public ParMaisProximo()
        {
        }

        public int BuscaExaustiva(int[][] input)
        {
            int minDist = CalcDist(input[0][0], input[0][1], input[1][0], input[1][1]);
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = i+1; j < input.Count(); j++)
                {
                    int temp = CalcDist(input[i][0], input[i][1], input[j][0], input[j][1]);
                    if(temp < minDist)
                    {
                        minDist = temp;
                    }

                }
            }
            return minDist;
        }


        public int EncontrarParMaisProximo(int[][] pontos)
        {
            if (pontos.Length < 2)
                return int.MaxValue; // Não há par para comparar

            // Chamada para a função de divisão e conquista
            return DivisaoConquista(pontos, 0, pontos.Length - 1);
        }

        public int DivisaoConquista(int[][] pontos, int inicio, int fim)
        {
            if (inicio >= fim)
                return int.MaxValue; // Não há par para comparar

            int meio = (inicio + fim) / 2;

            // Resolver recursivamente em ambas as metades
            int menorDistanciaEsquerda = DivisaoConquista(pontos, inicio, meio);
            int menorDistanciaDireita = DivisaoConquista(pontos, meio + 1, fim);

            // Encontrar a menor distância entre as metades
            int menorDistanciaEntreMetades = Math.Min(menorDistanciaEsquerda, menorDistanciaDireita);

            // Encontrar pontos na faixa central
            for (int i = inicio; i <= meio; i++)
            {
                for (int j = meio + 1; j <= fim; j++)
                {
                    int distancia = CalcDist(pontos[i][0], pontos[i][1], pontos[j][0], pontos[j][1]);
                    menorDistanciaEntreMetades = Math.Min(menorDistanciaEntreMetades, distancia);
                }
            }

            return menorDistanciaEntreMetades;
        }


        public int DivisaoConquista(int[][] input)
        {
            if (input.Count() <= 2)
                return CalcDist(input[0][0], input[0][1], input[1][0], input[1][1]);

            int meio = (int) (input.Count() / 2);
            int delta1 = DivisaoConquista((int[][])input.Take(meio));
            int delta2 = DivisaoConquista((int[][])input.Skip(meio));
            int delta = Math.Min(delta1, delta2);

            // Buscar a faixa
            int[][] faixa = new int[input.Count()][];
            for(int i = 0; i <input.Count(); i++)
            {
                if (Math.Abs(input[i][0] - meio) < delta)
                {
                    faixa.Append(input[i]);
                }
            }

            OrdenarPorY(faixa);

            for(int i = 0; i < faixa.Count() - 7; i++)
            {
                for(int j = i+1; j < faixa.Count() && (faixa[j][1] - faixa[i][1]) < delta; j++)
                {
                    int delta3 = CalcDist(input[i][0], input[i][1], input[j][0], input[j][1]);
                    delta = Math.Min(delta, delta3);
                }
            }

            return delta;
        }

        private void OrdenarPorY(int[][] faixa)
        {
            MergeSort.MergeSortByY(faixa, 0, faixa.Count()-1);
        }

        private int CalcDist(int x1, int y1, int x2, int y2)
        {
            return (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
