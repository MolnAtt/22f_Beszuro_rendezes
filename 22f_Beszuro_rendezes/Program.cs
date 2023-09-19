using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22f_Beszuro_rendezes
{
	internal class Program
	{

		static void Csere(List<int> lista, int i, int j)
		{
			int temp = lista[i];
			lista[i] = lista[j];
			lista[j] = temp;
		}
		static void Balra_sullyeszt(List<int> lista, int i)
		{
			while (0<i && lista[i - 1] > lista[i])
			{
				Csere(lista, i, i - 1);
				i--;
			}
		}

		static void Beszuro_Rendezes(List<int> lista)
		{
			for (int i = 1; i < lista.Count; i++)
			{
				Balra_sullyeszt(lista, i);
			}
		}

		static Random r = new Random();
		static List<int> Véletlen_lista(int maxhossz, int mettol, int meddig)
		{
			List<int> result = new List<int>();
			int hossz = r.Next(maxhossz);
			for (int i = 0; i < hossz; i++)
			{
				result.Add(r.Next(mettol, meddig));
			}
			return result;
		}

		static bool Megegyeznek(List<int> egyik, List<int> masik)
		{
			if (egyik.Count != masik.Count)
			{
				return false;
			}
			for (int i = 0; i < egyik.Count; i++)
			{
				if (egyik[i] != masik[i])
				{
					return false;
				}
			}
			return true;
		}

		static void Teszt(int db)
		{
			int rosszdb = 0;
			for (int i = 0; i < db; i++)
			{
				List<int> rendezetlen = Véletlen_lista(100, 0, 50);
				List<int> eredeti = new List<int>(rendezetlen);

				//List<int> masolat = eredeti; // ez nagyon nem jó! így nem jön létre új lista! Ez csak a címet másolja le! // ezzel az lett volna, hogy az eredeti rendezésével a másik is ugyanolyan rendezett lett volna. 
				List<int> masolat = new List<int>(eredeti); // a new kell ahhoz, hogy új dolog jöjjön létre
				eredeti.Sort(); // ez a C# beépített rendezése
				Beszuro_Rendezes(masolat);
				if (!Megegyeznek(eredeti, masolat))
				{
					Console.WriteLine("Ezek nem stimmelnek!");
					Console.WriteLine($"rendezetlen: [{String.Join(", ", rendezetlen)}]");
					Console.WriteLine($"C#   : [{String.Join(", ", eredeti)}]");
					Console.WriteLine($"mienk: [{String.Join(", ", masolat)}]");
					rosszdb++;
				}
			}

            Console.WriteLine($"Összesen {db} db tesztet végeztünk, ebből {rosszdb} db nem volt jó.");

        }


		static void Main(string[] args)
		{
			/*
			List<int> lista = new List<int> { 3, 0, 1, 8, 7, 2, 5, 4, 9, 8 };

            Console.WriteLine("Eredeti lista:");
			Console.WriteLine($"[{String.Join(", ", lista)}]");

			Beszuro_Rendezes(lista);
			Console.WriteLine("Rendezett lista (?):");
			Console.WriteLine($"[{String.Join(", ", lista)}]");
			*/
			Teszt(1000000);

			Console.ReadKey();

		}
	}
}


/*

Eljárás Beszúró_rendezés(lista: Lista[Egész]):
	Ciklus i:= 1-től lista.Hossz()-ig:
		
	Ciklus vége.

 
*/
