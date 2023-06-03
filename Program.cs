using System.Security.Cryptography;

Console.Clear();
Console.WriteLine("Adivinha");
Console.WriteLine();

Console.Write("Estou pensando em um número entre 1 e 100.");
Thread.Sleep(500); Console.Write(".");
Thread.Sleep(500); Console.Write(".");
Thread.Sleep(500); Console.WriteLine(" Pronto! Agora, tente adivinhar.");

int palpite = 0;
int numeroSecreto = RandomNumberGenerator.GetInt32(1, 101);
int tentativa = 1;
bool acertou = false;

do
{
    Console.WriteLine();
    Console.Write($"Faça seu palpite #{tentativa}? ");

    if (!Int32.TryParse(Console.ReadLine(), out palpite) || palpite < 1 || palpite > 100)
        continue;

    int erro = palpite - numeroSecreto;
    int distanciaErro = Math.Abs(erro);

    acertou = (palpite == numeroSecreto);

    if (!acertou)
    {
        tentativa++;

        if (distanciaErro <= 3)
            Console.WriteLine("Pelando!\n");
        else if (distanciaErro <= 10)
            Console.WriteLine("Quente!\n");
        else
        {
            if (distanciaErro >= 30)
                Console.WriteLine("Congelando... ");
            else
                 Console.WriteLine("Frio... ");

            bool tentarMaisAlto = Math.Sign(erro) == -1;

            Console.Write("tente um número mais ");
            Console.WriteLine(tentarMaisAlto ? "alto" : "baixo");
            Console.WriteLine(".");
        }
    }
}
while (tentativa <= 7 && !acertou);


Console.Write("\nO número que escolhi era ");
Console.WriteLine(numeroSecreto.ToString());
Console.WriteLine(".\n");
Console.ForegroundColor = ConsoleColor.DarkRed;


Console.WriteLine(acertou ? "Parabéns!" : "Tente novamente.");
Console.ResetColor();