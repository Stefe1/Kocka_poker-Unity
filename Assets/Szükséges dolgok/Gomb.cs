using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Gomb : MonoBehaviour
{
    public bool lenyomva;
    public bool Jatekoskore = true;
    public SpriteRenderer ElsoKocka;
    public SpriteRenderer MasodikKocka;
    public SpriteRenderer HarmadikKocka;
    public SpriteRenderer NegyedikKocka;
    public SpriteRenderer OtodikKocka;
    public int ertekegy1 = 1;
    public int ertekegy2 = 1;
    public int ertekegy3 = 1;
    public int ertekegy4 = 1;
    public int ertekegy5 = 1;

    public List<int> kor;
    public List<int> szamokra_rendezve;
    private Sprite[] diceSides;

    public int Gep_szemet = 0, Gep_par = 0, Gep_drill = 0, Gep_ketpar = 0, Gep_kispoker = 0, Gep_full = 0, Gep_kissor = 0, Gep_nagysor = 0, Gep_nagypoker = 0, Gep_pontszam = 0;
    public bool Gep_szemet_kesz = false, Gep_par_kesz = false, Gep_drill_kesz = false, Gep_ketpar_kesz = false, Gep_kispoker_kesz = false, Gep_full_kesz = false, Gep_kissor_kesz = false, Gep_nagysor_kesz = false, Gep_nagypoker_kesz = false;
    public TMP_Text szemet, par, drill, ket_par, kis_poker, full, kis_sor, nagy_sor, nagy_poker, pontszam;
    private List<int> Gep_ertekek = new List<int>();

    public int korszam = 0;
    public Játékos_Pontszám _jatekos_pontszam;
    public TMP_Text eredmeny;

    static int Nagy_Poker(List<int> l)
    {
        if (l.Max() == 5)
        {
            return 50;
        }
        else
        {
            return 0;
        }
    }
    static int Nagy_Sor(List<int> l)
    {
        if (l.Contains(2) && l.Contains(3) && l.Contains(4) && l.Contains(5) && l.Contains(6))
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    static int Kis_Sor(List<int> l)
    {
        if (l.Contains(1) && l.Contains(2) && l.Contains(3) && l.Contains(4) && l.Contains(5))
        {
            return 15;
        }
        else
        {
            return 0;
        }
    }
    static int Fullos(List<int> l, List<int> k)
    {
        if (l.Contains(3) && l.Contains(2))
        {
            return k.Sum();
        }
        else
        {
            return 0;
        }
    }
    static int Ket_Par(List<int> l)
    {
        int ertek = 0;
        bool elso = false;
        bool beteljesult = false;
        for (int i = 0; i < 6; i++)
        {
            if (l[i] >= 2)
            {
                if (!elso)
                {
                    ertek = i + 1;
                    elso = true;
                }
                else
                {
                    ertek += i + 1;
                    beteljesult = true;
                }
            }
        }
        if (beteljesult)
        {
            return ertek * 2;
        }
        else
        {
            return 0;
        }
    }
    static int Kis_poker(List<int> l)
    {
        int ertek = 0;
        for (int i = 0; i < 6; i++)
        {
            if (l[i] >= 4)
            {
                ertek = i + 1;

            }
        }
        return ertek * 4;
    }
    static int Drilles(List<int> l)
    {
        int ertek = 0;
        for (int i = 0; i < 6; i++)
        {
            if (l[i] >= 3)
            {
                ertek = i + 1;

            }
        }
        return ertek * 3;
    }
    static int Par(List<int> l)
    {
        int ertek = 0;
        for (int i = 0; i < 6; i++)
        {
            if (l[i] >= 2)
            {
                ertek = i + 1;
            }
        }

        return ertek * 2;
    }
    static TMP_Text Kiiras(TMP_Text szov, bool kesz, int ertek, int Fuggvenyertek)
    {
        if (kesz)
        {
            szov.text = ertek.ToString();
            szov.fontStyle = FontStyles.Bold;
            return szov;
        }
        else
        {

            return szov;
        }
    }

    private void Start()
    {

        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    private void OnMouseDown()
    {
        if (korszam!=9)
        {
            if (Jatekoskore)
            {
                if (!lenyomva)
                {
                    StartCoroutine("Dobas");
                    kor.Sort();
                    szamokra_rendezve = Rendezes(kor);
                    lenyomva = true;

                }
            }
            else
            {
                Gep_ertekek.Clear();
                StartCoroutine("Dobas");
                kor.Sort();
                szamokra_rendezve = Rendezes(kor);
                if (!Gep_szemet_kesz)
                {
                    Gep_ertekek.Add(kor.Sum());
                }
                if (!Gep_par_kesz)
                {
                    Gep_ertekek.Add(Par(szamokra_rendezve));
                }
                if (!Gep_drill_kesz)
                {
                    Gep_ertekek.Add(Drilles(szamokra_rendezve));
                }
                if (!Gep_ketpar_kesz)
                {
                    Gep_ertekek.Add(Ket_Par(szamokra_rendezve));
                }
                if (!Gep_kispoker_kesz)
                {
                    Gep_ertekek.Add(Kis_poker(szamokra_rendezve));
                }
                if (!Gep_full_kesz)
                {
                    Gep_ertekek.Add(Fullos(szamokra_rendezve, kor));
                }
                if (!Gep_kissor_kesz)
                {
                    Gep_ertekek.Add(Kis_Sor(kor));
                }
                if (!Gep_nagysor_kesz)
                {
                    Gep_ertekek.Add(Nagy_Sor(kor));
                }
                if (!Gep_nagypoker_kesz)
                {
                    Gep_ertekek.Add(Nagy_Poker(szamokra_rendezve));
                }

                //Érték kiválasztása
                if (!Gep_szemet_kesz && kor.Sum() == Gep_ertekek.Max())
                {
                    Gep_szemet = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_szemet_kesz = true;
                }

                else if (!Gep_par_kesz && Par(szamokra_rendezve) == Gep_ertekek.Max())
                {
                    Gep_par = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_par_kesz = true;
                }

                else if (!Gep_drill_kesz && Drilles(szamokra_rendezve) == Gep_ertekek.Max())
                {
                    Gep_drill = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_drill_kesz = true;
                }

                else if (!Gep_ketpar_kesz && Ket_Par(szamokra_rendezve) == Gep_ertekek.Max())
                {
                    Gep_ketpar = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_ketpar_kesz = true;
                }

                else if (!Gep_kispoker_kesz && Kis_poker(szamokra_rendezve) == Gep_ertekek.Max())
                {
                    Gep_kispoker = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_kispoker_kesz = true;
                }

                else if (!Gep_full_kesz && Fullos(szamokra_rendezve, kor) == Gep_ertekek.Max())
                {
                    Gep_full = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_full_kesz = true;
                }

                else if (!Gep_kissor_kesz && Kis_Sor(kor) == Gep_ertekek.Max())
                {
                    Gep_kissor = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_kissor_kesz = true;
                }

                else if (!Gep_nagysor_kesz && Nagy_Sor(kor) == Gep_ertekek.Max())
                {
                    Gep_nagysor = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_nagysor_kesz = true;
                }

                else if (!Gep_nagypoker_kesz && Nagy_Poker(szamokra_rendezve) == Gep_ertekek.Max())
                {
                    Gep_nagypoker = Gep_ertekek.Max();
                    Gep_pontszam += Gep_ertekek.Max();
                    Gep_nagypoker_kesz = true;

                }

                Kiiras(szemet, Gep_szemet_kesz, Gep_szemet, kor.Sum());
                Kiiras(par, Gep_par_kesz, Gep_par, Par(szamokra_rendezve));
                Kiiras(drill, Gep_drill_kesz, Gep_drill, Drilles(szamokra_rendezve));
                Kiiras(ket_par, Gep_ketpar_kesz, Gep_ketpar, Ket_Par(szamokra_rendezve));
                Kiiras(kis_poker, Gep_kispoker_kesz, Gep_kispoker, Kis_poker(szamokra_rendezve));
                Kiiras(full, Gep_full_kesz, Gep_full, Fullos(szamokra_rendezve, kor));
                Kiiras(kis_sor, Gep_kissor_kesz, Gep_kissor, Kis_Sor(kor));
                Kiiras(nagy_sor, Gep_nagysor_kesz, Gep_nagysor, Nagy_Sor(kor));
                Kiiras(nagy_poker, Gep_nagypoker_kesz, Gep_nagypoker, Nagy_Poker(szamokra_rendezve));
                pontszam.text = Gep_pontszam.ToString();
                Jatekoskore = true;
                korszam++;
            }
        }
        
    }

    static List<int> Az_adott_kor()
    {
        List<int> szamok = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            szamok.Add(Random.Range(0, 6) + 1);
        }
        return szamok;
    }
    static List<int> Rendezes(List<int> l)
    {
        List<int> szamok = new List<int>();
        int[] lehetsegesek = { 1, 2, 3, 4, 5, 6 };
        foreach (var item in lehetsegesek)
        {
            int mennyi = 0;
            foreach (var itemk in l)
            {
                if (itemk == item)
                {
                    mennyi++;
                }
            }
            szamok.Add(mennyi);
        }

        return szamok;
    }
    private void Dobas()
    {
        kor = Az_adott_kor();
        ertekegy1 = kor[0];
        ertekegy2 = kor[1];
        ertekegy3 = kor[2];
        ertekegy4 = kor[3];
        ertekegy5 = kor[4];

        ElsoKocka.sprite = diceSides[ertekegy1 - 1];
        MasodikKocka.sprite = diceSides[ertekegy2 - 1];
        HarmadikKocka.sprite = diceSides[ertekegy3 - 1];
        NegyedikKocka.sprite = diceSides[ertekegy4 - 1];
        OtodikKocka.sprite = diceSides[ertekegy5 - 1];
    }
}
