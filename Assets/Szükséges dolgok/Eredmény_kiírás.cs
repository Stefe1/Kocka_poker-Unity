using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.IO;

public class Eredmény_kiírás : MonoBehaviour
{
    public Szemét _szemet;
    public Pár _par;
    public Drill _drill;
    public Két_Pár _ket_par;
    public Kis_Póker _kis_poker;
    public Full _full;
    public Kis_Sor _kis_sor;
    public Nagy_Sor _nagy_sor;
    public Nagy_Póker _nagy_poker;
    public Játékos_Pontszám _jatekos_pontszam;
    public Eredmény_kiírás _eredmény_kiírás;
    public Gomb _gomb;
    public TMP_Text eredmeny;
    public bool kesz = false;

    private void OnMouseDown()
    {
        _szemet.vegso_ertek = 0;
        _szemet.lezarva = false;
        _szemet.szoveg.text = "";
        _szemet.szoveg.fontStyle = FontStyles.Normal;
        _par.vegso_ertek = 0;
        _par.lezarva = false;
        _par.szoveg.text = "";
        _par.szoveg.fontStyle = FontStyles.Normal;
        _drill.vegso_ertek = 0;
        _drill.lezarva = false;
        _drill.szoveg.text = "";
        _drill.szoveg.fontStyle = FontStyles.Normal;
        _ket_par.vegso_ertek = 0;
        _ket_par.lezarva = false;
        _ket_par.szoveg.text = "";
        _ket_par.szoveg.fontStyle = FontStyles.Normal;
        _kis_poker.vegso_ertek = 0;
        _kis_poker.lezarva = false;
        _kis_poker.szoveg.text = "";
        _kis_poker.szoveg.fontStyle = FontStyles.Normal;
        _full.vegso_ertek = 0;
        _full.lezarva = false;
        _full.szoveg.text = "";
        _full.szoveg.fontStyle = FontStyles.Normal;
        _kis_sor.vegso_ertek = 0;
        _kis_sor.lezarva = false;
        _kis_sor.szoveg.text = "";
        _kis_sor.szoveg.fontStyle = FontStyles.Normal;
        _nagy_sor.vegso_ertek = 0;
        _nagy_sor.lezarva = false;
        _nagy_sor.szoveg.text = "";
        _nagy_sor.szoveg.fontStyle = FontStyles.Normal;
        _nagy_poker.vegso_ertek = 0;
        _nagy_poker.lezarva = false;
        _nagy_poker.szoveg.text = "";
        _nagy_poker.szoveg.fontStyle = FontStyles.Normal;
        _jatekos_pontszam.Pontok.Clear();
        _eredmény_kiírás.eredmeny.text = "A meccs eredménye: ";

        _gomb.Gep_szemet = 0;
        _gomb.Gep_szemet_kesz = false;
        _gomb.szemet.text = "";
        _gomb.szemet.fontStyle = FontStyles.Normal;
        _gomb.Gep_par = 0;
        _gomb.Gep_par_kesz = false;
        _gomb.par.text = "";
        _gomb.par.fontStyle = FontStyles.Normal;
        _gomb.Gep_drill = 0;
        _gomb.Gep_drill_kesz = false;
        _gomb.drill.text = "";
        _gomb.drill.fontStyle = FontStyles.Normal;
        _gomb.Gep_ketpar = 0;
        _gomb.Gep_ketpar_kesz = false;
        _gomb.ket_par.text = "";
        _gomb.ket_par.fontStyle = FontStyles.Normal;
        _gomb.Gep_kispoker = 0;
        _gomb.Gep_kispoker_kesz = false;
        _gomb.kis_poker.text = "";
        _gomb.kis_poker.fontStyle = FontStyles.Normal;
        _gomb.Gep_full = 0;
        _gomb.Gep_full_kesz = false;
        _gomb.full.text = "";
        _gomb.full.fontStyle = FontStyles.Normal;
        _gomb.Gep_kissor = 0;
        _gomb.Gep_kissor_kesz = false;
        _gomb.kis_sor.text = "";
        _gomb.kis_sor.fontStyle = FontStyles.Normal;
        _gomb.Gep_nagysor = 0;
        _gomb.Gep_nagysor_kesz = false;
        _gomb.nagy_sor.text = "";
        _gomb.nagy_sor.fontStyle = FontStyles.Normal;
        _gomb.Gep_nagypoker = 0;
        _gomb.Gep_nagypoker_kesz = false;
        _gomb.nagy_poker.text = "";
        _gomb.nagy_poker.fontStyle = FontStyles.Normal;

        _gomb.Jatekoskore = true;
        _gomb.korszam = 0;
        _gomb.Gep_pontszam = 0;
        _gomb.pontszam.text = "";
        kesz = false;
    }


    void Update()
    {
        if (_gomb.korszam == 9)
        {
            if (_jatekos_pontszam.Pontok.Sum() > _gomb.Gep_pontszam)
            {
                eredmeny.text = "A meccs eredménye: A Játékos nyert";
            }
            else if (_jatekos_pontszam.Pontok.Sum() == _gomb.Gep_pontszam)
            {
                eredmeny.text = "A meccs eredménye: Döntetlen";
            }
            else if (_jatekos_pontszam.Pontok.Sum() < _gomb.Gep_pontszam)
            {
                eredmeny.text = "A meccs eredménye: A Gép nyert";
            }
            string nev = "meccs" + Random.Range(0,9999)+".txt";
            if (!kesz)
            {
                StreamWriter sw = new StreamWriter(nev);
                sw.WriteLine($"{_szemet.vegso_ertek} {_gomb.Gep_szemet}");
                sw.WriteLine($"{_par.vegso_ertek} {_gomb.Gep_par}");
                sw.WriteLine($"{_drill.vegso_ertek} {_gomb.Gep_drill}");
                sw.WriteLine($"{_ket_par.vegso_ertek} {_gomb.Gep_ketpar}");
                sw.WriteLine($"{_kis_poker.vegso_ertek} {_gomb.Gep_kispoker}");
                sw.WriteLine($"{_full.vegso_ertek} {_gomb.Gep_full}");
                sw.WriteLine($"{_kis_sor.vegso_ertek} {_gomb.Gep_kissor}");
                sw.WriteLine($"{_nagy_sor.vegso_ertek} {_gomb.Gep_nagysor}");
                sw.WriteLine($"{_nagy_poker.vegso_ertek} {_gomb.Gep_nagypoker}");
                sw.Close();
                kesz = true;
            }

        }
    }
}
