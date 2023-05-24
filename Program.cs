List<string> kifejezesek = new List<string>();
using (StreamReader sr = new("./kifejezesek.txt"))
{
    while (!sr.EndOfStream)
    {
        kifejezesek.Add(sr.ReadLine()!);
    }
}

//2. feladat 
Console.WriteLine($"2. feladat: Kifejezések száma: {kifejezesek.Count()}");

//3. feladat
Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {kifejezesek.Count(x => x.Split(' ')[1].Equals("mod"))}");

//4.feladat
Console.WriteLine("4. feladat: {0}", kifejezesek.Any(x => int.Parse(x.Split(' ')[^1]) != 0 && int.Parse(x.Split(' ')[0]) % int.Parse(x.Split(' ')[^1]) == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!");

//5. feladat
Console.WriteLine($"5. feladat: Statisztika:" +
    $"\n\tmod -> {kifejezesek.Count(x => x.Split(' ')[1].Equals("mod"))} db" +
    $"\n\t/ -> {kifejezesek.Count(x => x.Split(' ')[1].Equals("/"))} db" +
    $"\n\tdiv -> {kifejezesek.Count(x => x.Split(' ')[1].Equals("div"))} db" +
    $"\n\t- -> {kifejezesek.Count(x => x.Split(' ')[1].Equals("-"))} db" +
    $"\n\t* -> {kifejezesek.Count(x => x.Split(' ')[1].Equals("*"))} db" +
    $"\n\t+ -> {kifejezesek.Count(x => x.Split(' ')[1].Equals("+"))} db");

//7. feladat
string result = string.Empty;
while (!result.Equals("vége"))
{
    Console.Write("7.feladat: Kérek egy kifejezést (pl.:1+1):");
    result = Console.ReadLine()!;
    Console.WriteLine(Szamolas(result));
}

//8. feladat
using (StreamWriter sw = new("./eredmények.txt"))
{
    kifejezesek.ForEach(x => sw.WriteLine(Szamolas(x)));
}

//6. feladat
static string Szamolas(string expression)
{
    string result;
    if (string.IsNullOrEmpty(expression) || expression.Equals("vége"))
    {
        return string.Empty;
    }
    Dictionary<string, Func<double, double, double>> operatorDictionary = new Dictionary<string, Func<double, double, double>>()
    {
        { "+", (a,b) => a+ b},
        { "-", (a,b) => a-b},
        { "*", (a,b) => a*b},
        { "/", (a,b) => a/b},
        { "mod", (a,b) => a%b},
        { "div", (a,b) => Math.Floor(a / b)},
    };
    try
    {
        result = $"{operatorDictionary[expression.Split(' ')[1]]
        (double.Parse(expression.Split(' ')[0]), double.Parse(expression.Split(' ')[^1]))}";
    }
    catch (KeyNotFoundException)
    {
        result = "Hibás operátor!";
    }

    catch (Exception)
    {
        result = "Egyéb hiba!";
    }
    return expression + $" = {result}";
}