using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Mentes : MonoBehaviour
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

    static void Mentes_keszitese(StreamWriter sw, bool kesz, int ertek)
    {
        if (kesz)
        {
            sw.WriteLine(ertek);
        }
        else
        {
            sw.WriteLine("\t");
        }
    }
    private void OnMouseDown()
    {
        StreamWriter sw = new StreamWriter("mentes.txt");
        Mentes_keszitese(sw, _szemet.lezarva, _szemet.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_szemet_kesz, _gomb.Gep_szemet);
        Mentes_keszitese(sw, _par.lezarva, _par.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_par_kesz, _gomb.Gep_par);
        Mentes_keszitese(sw, _drill.lezarva, _drill.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_drill_kesz, _gomb.Gep_drill);
        Mentes_keszitese(sw, _ket_par.lezarva, _ket_par.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_ketpar_kesz, _gomb.Gep_ketpar);
        Mentes_keszitese(sw, _kis_poker.lezarva, _kis_poker.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_kispoker_kesz, _gomb.Gep_kispoker);
        Mentes_keszitese(sw, _full.lezarva, _full.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_full_kesz, _gomb.Gep_full);
        Mentes_keszitese(sw, _kis_sor.lezarva, _kis_sor.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_kissor_kesz, _gomb.Gep_kissor);
        Mentes_keszitese(sw, _nagy_sor.lezarva, _nagy_sor.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_nagysor_kesz, _gomb.Gep_nagysor);
        Mentes_keszitese(sw, _nagy_poker.lezarva, _nagy_poker.vegso_ertek);
        Mentes_keszitese(sw, _gomb.Gep_nagypoker_kesz, _gomb.Gep_nagypoker);
        sw.WriteLine(_jatekos_pontszam.Pontok.Sum());
        sw.WriteLine(_gomb.Gep_pontszam);
        sw.WriteLine(_gomb.korszam);
        if (_gomb.Jatekoskore)
        {
            sw.WriteLine("true");
        }
        else
        {
            sw.WriteLine("false");
        }
        sw.Close();
    }
}
