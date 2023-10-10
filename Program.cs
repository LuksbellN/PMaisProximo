namespace PMaisProx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParMaisProximo PMP = new();
            int[][] input = [ [1, 3], [2, 4], [2, 2], [5, 4], [3, 7] ];
            Console.WriteLine(PMP.BuscaExaustiva(input));
        }
    }
}