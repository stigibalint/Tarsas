using System.IO;
string[] osveny = File.ReadAllLines("osvenyek.txt");
string[] dobasok = File.ReadAllLines("dobasok.txt");

List<string> dobasokLista = new List<string>();

foreach (var beolvas in dobasok)
{
	foreach (var item in beolvas.Split(" "))
	{
		dobasokLista.Add(item);
	}

}
Console.WriteLine($"2. feladat:	\nA dobások száma:{dobasokLista.Count()}" +
	$"\nAz ösvények száma: {osveny.Count()}");

//Console.WriteLine($"3. feladat:\n Az egyik leghosszabb a(z) {} ösvény, hossza: ");

int leghosszabbOsveny  = 0;
for(int i = 1; i < osveny.Length; i++)
{
	if (osveny[i].Length > osveny[leghosszabbOsveny].Length)
	{
		leghosszabbOsveny = i;
	}
}
Console.WriteLine($"3. feladat \nAz egyik leghosszabb a(z) {leghosszabbOsveny+1 }. ösvény, " +
	$"hossza: {osveny[leghosszabbOsveny].Length}");

Console.WriteLine("4. feladat: \nAdja megy egy ösvény sorszámát! ");
int osvenyekSzamanakBekerese = int.Parse(Console.ReadLine());
Console.WriteLine("Adja megy a játékosok számát! ");
int jatekosokSzamanakBekerese = int.Parse(Console.ReadLine());

if (osvenyekSzamanakBekerese < 1)
	osvenyekSzamanakBekerese = 1;
else if(osvenyekSzamanakBekerese > osveny.Count())
	osvenyekSzamanakBekerese = osveny.Count();
else if(jatekosokSzamanakBekerese < 2)
	jatekosokSzamanakBekerese = 2;
else if(jatekosokSzamanakBekerese > 5)
	jatekosokSzamanakBekerese = 5;


int mSzamlalo = 0;
int vSzamlalo = 0;
int eSzamlalo = 0;
int index = 0;
StreamWriter sr = new StreamWriter("kulonleges.txt");
foreach (var item in osveny[osvenyekSzamanakBekerese-1])
	
{
	 if (item == 'V')
	{
		vSzamlalo++;
		sr.Write($"{index}  {item}\n");
	}
	else if(item == 'E')
	{
		eSzamlalo++;
        sr.Write($"{index}  {item}\n");
    }
	else
	{
		mSzamlalo++;
	}
	index++;
}
sr.Close();
Console.WriteLine($"5. feladat: \nM:{mSzamlalo} darab \nV:{vSzamlalo} darab\nE: {eSzamlalo} darab");
int[] jatekosok = new int[jatekosokSzamanakBekerese];
int seged = 1;
int dobas = 0;
bool jatek = true ;
int cel = osveny[osvenyekSzamanakBekerese - 1].Length;
while (jatek)
{
	for (int i = 0; i < jatekosok.Length; i++)
	{
        jatekosok[i] += int.Parse(dobasokLista[dobas]);
        {

            dobas++;
        if (jatekosok[i] >= cel )
		{
			jatek = false;
            Console.WriteLine($"7. feladat: a(z) {seged}." +
				$" körben fejeződött be. A legtávolabb jutó(k) sorszáma: {i+1}");
        }
    }
	
	seged++;
}



}