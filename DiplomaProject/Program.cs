// See https://aka.ms/new-console-template for more information


using DiplomaProject;
using System.Runtime.CompilerServices;

//var generator = new EquentialsGenerator();

//var x = generator.GenerateX(10);
//var y = generator.GenerateY(10);
//var z = generator.GenerateZ(10);

//foreach(var line in x)
//{
//    foreach(var item in line)
//    {
//        Console.Write(item.ToString());
//        Console.Write(" + ");
//    }

//    Console.WriteLine();
//}

//foreach (var line in y)
//{
//    foreach (var item in line)
//    {
//        Console.Write(item.ToString());
//        Console.Write(" + ");
//    }

//    Console.WriteLine();
//}

//foreach (var line in z)
//{
//    foreach (var item in line)
//    {
//        Console.Write(item.ToString());
//        Console.Write(" + ");
//    }

//    Console.WriteLine();
//}

var gammaGen = new GammaGenerator();
//0xFFF141BB26E901EB
//0111110001010010001000001000010111 
//0100111001101101011110100100011001
//0111000101000100101010001010100000

//0x4CED482318BE6784
//1111111010001010100110011100110000
//1010100111111111111010101000101101
//0000011111101010111110111100001011

var gamma = gammaGen.GenerateGamma(0x4CED482318BE6784U, 100);

gamma.ForEach(x => Console.Write(x));

Console.WriteLine("stop");

