// See https://aka.ms/new-console-template for more information
using HuffmanTreeBytes;
using HuffmanTreeInts;
using System.Text;

var s = "132456789123456132\n174258369147285147\n124357689124357681243571241\n123456789123456781234567123456123451234123121";
Console.WriteLine(s);

Console.WriteLine();

//var tree = HuffmanTreeBytes.Tree.GetTreeFromArray(Encoding.UTF8.GetBytes(s));
var tree = HuffmanTreeInts.Tree.GetTreeFromArray(Encoding.UTF8.GetBytes(s).ToList().ConvertAll(x => (int)x));

var dict = tree.GetDictionary();

Console.WriteLine("Count:");
var list = s.ToHashSet().ToList();
list.Sort((x1, x2) => s.Count(x => x == x2) - s.Count(x => x == x1));
foreach (var c in list) Console.WriteLine($"{c} | {s.Count(x => x == c)}");

Console.WriteLine();

Console.WriteLine("HuffmanTree:");
var sortedDict = new Dictionary<byte, string>();
foreach (var c in list)
{
    byte b = (byte)c;
    sortedDict.Add(b, dict[b]);
}
foreach (var item in sortedDict) Console.WriteLine($"{(char)item.Key} | {item.Value}");

Console.WriteLine();

Console.WriteLine("Conclusion:");
int originalSize = Encoding.UTF8.GetBytes(s).Length;
Console.WriteLine($"Original: {originalSize * 8} bits => {originalSize} bytes");

int compressedSize = 0;
foreach (var item in sortedDict) compressedSize += s.Count(x => x == (char)item.Key) * item.Value.Length;
Console.WriteLine($"Compressed: {compressedSize} bits => {MathF.Ceiling(compressedSize / 8f)} bytes");