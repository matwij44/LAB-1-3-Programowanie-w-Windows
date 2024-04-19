using System;
using System.Collections.Generic;

public class RGB
{
    private int R_value,G_value, B_value;

    public RGB(int R_value = 0, int G_value = 0, int B_value = 0)
    {
        this.R_value = R_value;
        this.G_value = G_value;
        this.B_value = B_value;
    }

    public int GetR_value()
    {
        return R_value;
    }

    public void SetR_value(int value)
    {
        R_value = value;
    }

    public int GetG_value()
    {
        return G_value;
    }

    public void SetG_value(int value)
    {
        G_value = value;
    }

    public int GetB_value()
    {
        return B_value;
    }

    public void SetB_value(int value)
    {
        B_value = value;
    }
}

class RGBController
{
    public void InicjalizacjaKolorow(RGB kolorowyObiekt, int R, int G, int B)
    {
        kolorowyObiekt.SetR_value(R);
        kolorowyObiekt.SetG_value(G);
        kolorowyObiekt.SetB_value(B);
    }

    public void WyswietlKolor(RGB kolorowyObiekt)
    {
        Console.WriteLine("[{0}, {1}, {2}]", kolorowyObiekt.GetR_value(), kolorowyObiekt.GetG_value(), kolorowyObiekt.GetB_value());
    }

    public RGB LaczenieKolorow(RGB kolorowyObiekt1, RGB kolorowyObiekt2)
    {
        int mixedR = (kolorowyObiekt1.GetR_value() + kolorowyObiekt2.GetR_value()) / 2;
        int mixedG = (kolorowyObiekt1.GetG_value() + kolorowyObiekt2.GetG_value()) / 2;
        int mixedB = (kolorowyObiekt1.GetB_value() + kolorowyObiekt2.GetB_value()) / 2;

        return new RGB(mixedR, mixedG, mixedB);
    }
}

class Student
{
    private string nr_indeksu;
    private string imie;
    private string nazwisko;
    private int rok_st;

    public Student(string nr, string imie, string nazwisko, int rok)
    {
        this.nr_indeksu = nr;
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.rok_st = rok;
    }

    public string GetNrIndeksu()
    {
        return this.nr_indeksu;
    }

    public void SetNrIndeksu(string nr)
    {
        this.nr_indeksu = nr;
    }

    public string GetImie()
    {
        return this.imie;
    }

    public void SetImie(string imie)
    {
        this.imie = imie;
    }

    public string GetNazwisko()
    {
        return this.nazwisko;
    }

    public void SetNazwisko(string nazwisko)
    {
        this.nazwisko = nazwisko;
    }

    public int GetRokStudiow()
    {
        return this.rok_st;
    }

    public void SetRokStudiow(int rok)
    {
        this.rok_st = rok;
    }

    public void WyswietlDaneStudenta()
    {
        Console.WriteLine("Student: {0} {1} ma index: {2}, w roku: {3}", imie, nazwisko, nr_indeksu, rok_st);
    }
}

class Uni
{
    private List<double> DopuszczalneOceny = new List<double> { 2, 3, 3.5, 4, 4.5, 5 };
    private Dictionary<string, List<double>> studentOceny = new Dictionary<string, List<double>>();
    private List<Student> ListaStudentow = new List<Student>();

    public void DodajStudenta(Student student)
    {
        ListaStudentow.Add(student);

        Console.WriteLine("Przypisanie ocen studentowi o indeksie {0}:", student.GetNrIndeksu());
        List<double> oceny = new List<double>();

        string wejscie="";

        while (wejscie != "x")
        {
            Console.Write("Podaj ocenę (lub wpisz 'x' aby zakończyć): ");
            wejscie = Console.ReadLine();
            if (wejscie.ToLower() == "x")
                break;

            try
            {
                double ocenaSparsowana = double.Parse(wejscie);
                if (DopuszczalneOceny.Contains(ocenaSparsowana))
                {
                    oceny.Add(ocenaSparsowana);
                }
                else
                {
                    Console.WriteLine("Wprowadzona liczba nie może zostać użyta jako ocena.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("To nie liczba !");
            }
        }

        studentOceny.Add(student.GetNrIndeksu(), oceny);
    }

    public void UsunStudenta(string nrIndeksu)
    {
        Student studentDoUsuniecia = ListaStudentow.Find(s => s.GetNrIndeksu() == nrIndeksu);
        if (studentDoUsuniecia != null)
        {
            ListaStudentow.Remove(studentDoUsuniecia);
            studentOceny.Remove(nrIndeksu);
            Console.WriteLine("Student z indeksem {0} został usunięty.", nrIndeksu);
        }
        else
        {
            Console.WriteLine("Nie znaleziono takiego studenta.");
        }
    }

    public void ObliczSrednia(string nrIndeksu)
    {
        if (studentOceny.ContainsKey(nrIndeksu))
        {
            List<double> oceny = studentOceny[nrIndeksu];
            if (oceny.Count > 0)
            {
                double suma = 0;
                foreach (double ocena in oceny)
                {
                    suma += ocena;
                }
                double srednia = suma / oceny.Count;
                Console.WriteLine("Średnia ocena studenta z indeksem {0} wynosi: {1}", nrIndeksu, srednia);
            }
            else
            {
                Console.WriteLine("Brak ocen dla studenta z {0}.", nrIndeksu);
            }
        }
        else
        {
            Console.WriteLine("Nie znaleziono takiego studenta.");
        }
    }

    public void ObliczSredniaWszystkichStudentow()
    {
        double sumaOcen = 0;
        int liczbaOcen = 0;
        foreach (var oceny in studentOceny.Values)
        {
            foreach (double ocena in oceny)
            {
                sumaOcen += ocena;
                liczbaOcen++;
            }
        }
        if (liczbaOcen > 0)
        {
            double srednia = sumaOcen / liczbaOcen;
            Console.WriteLine("Średnia ocen wszystkich studentów wynosi: {0}", srednia);
        }
        else
        {
            Console.WriteLine("Nie ma żadnych ocen.");
        }
    }




class Program
{
    static void Main(string[] args)
    {
        Uni university = new Uni();

        // Dodawanie studentów i ocen
        Student student1 = new Student("00000", "Michał", "Matwij", 1);
        university.DodajStudenta(student1);

        Student student2 = new Student("11111", "Karol", "Kujawski", 2);
        university.DodajStudenta(student2);

        Student student3 = new Student("22222", "Dominik","Savio",3);
        university.DodajStudenta(student3);

        // Usuwanie studenta
        university.UsunStudenta("00000");

        // Obliczanie średniej oceny dla konkretnego studenta
        university.ObliczSrednia("11111");

        // Obliczanie średniej ocen wszystkich studentów
        university.ObliczSredniaWszystkichStudentow();


        /*RGBController controller = new RGBController();

        RGB kolorowy1 = new RGB(100, 50, 200);
        RGB kolorowy2 = new RGB();
        controller.InicjalizacjaKolorow(kolorowy2, 20, 150, 70);

        Console.WriteLine("Obiekt 1:");
        controller.WyswietlKolor(kolorowy1);

        Console.WriteLine("Obiekt 2:");
        controller.WyswietlKolor(kolorowy2);

        RGB obiektLaczony = controller.LaczenieKolorow(kolorowy1, kolorowy2);
        Console.WriteLine("Polaczony obiekt::");
        controller.WyswietlKolor(obiektLaczony);
        */
    }
}
}