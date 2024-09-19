using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class Mentes_beolvasasa : MonoBehaviour
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
    public Gomb _gomb;

    static int Mentes_beolvasas(string sor)
    {
        if (sor == "\t")
        {
            return 0;
        }
        else
        {
            return int.Parse(sor);
        }
    }
    static bool Menetes_beolvasasaketto(string sor)
    {
        if (sor == "\t")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    static TMP_Text Menetes_beolvasasszoveg(string sor,TMP_Text szov,int ertek)
    {
        if (sor == "\t")
        {
            return szov;
        }
        else
        {
            szov.fontStyle = FontStyles.Bold;
            szov.text = ertek.ToString();
            return szov;
        }
    }
    void Start()
    {
        try
        {
            string[] mentes = File.ReadAllLines("mentes.txt");
            _szemet.vegso_ertek = Mentes_beolvasas(mentes[0]);
            _szemet.lezarva = Menetes_beolvasasaketto(mentes[0]);
            _szemet.szoveg=Menetes_beolvasasszoveg(mentes[0],_szemet.szoveg,_szemet.vegso_ertek);
            _gomb.Gep_szemet = Mentes_beolvasas(mentes[1]);
            _gomb.Gep_szemet_kesz = Menetes_beolvasasaketto(mentes[1]);

            _par.vegso_ertek = Mentes_beolvasas(mentes[2]);
            _par.lezarva = Menetes_beolvasasaketto(mentes[2]);
            _par.szoveg = Menetes_beolvasasszoveg(mentes[2], _par.szoveg, _par.vegso_ertek);
            _gomb.Gep_par = Mentes_beolvasas(mentes[3]);
            _gomb.Gep_par_kesz = Menetes_beolvasasaketto(mentes[3]);

            _drill.vegso_ertek = Mentes_beolvasas(mentes[4]);
            _drill.lezarva = Menetes_beolvasasaketto(mentes[4]);
            _drill.szoveg = Menetes_beolvasasszoveg(mentes[4], _drill.szoveg, _drill.vegso_ertek);
            _gomb.Gep_drill = Mentes_beolvasas(mentes[5]);
            _gomb.Gep_drill_kesz = Menetes_beolvasasaketto(mentes[5]);

            _ket_par.vegso_ertek = Mentes_beolvasas(mentes[6]);
            _ket_par.lezarva = Menetes_beolvasasaketto(mentes[6]);
            _ket_par.szoveg = Menetes_beolvasasszoveg(mentes[6], _ket_par.szoveg, _ket_par.vegso_ertek);
            _gomb.Gep_ketpar = Mentes_beolvasas(mentes[7]);
            _gomb.Gep_ketpar_kesz = Menetes_beolvasasaketto(mentes[7]);

            _kis_poker.vegso_ertek = Mentes_beolvasas(mentes[8]);
            _kis_poker.lezarva = Menetes_beolvasasaketto(mentes[8]);
            _kis_poker.szoveg = Menetes_beolvasasszoveg(mentes[8], _kis_poker.szoveg, _kis_poker.vegso_ertek);
            _gomb.Gep_kispoker = Mentes_beolvasas(mentes[9]);
            _gomb.Gep_kispoker_kesz = Menetes_beolvasasaketto(mentes[9]);

            _full.vegso_ertek = Mentes_beolvasas(mentes[10]);
            _full.lezarva = Menetes_beolvasasaketto(mentes[10]);
            _full.szoveg = Menetes_beolvasasszoveg(mentes[10], _full.szoveg, _full.vegso_ertek);
            _gomb.Gep_full = Mentes_beolvasas(mentes[11]);
            _gomb.Gep_full_kesz = Menetes_beolvasasaketto(mentes[11]);

            _kis_sor.vegso_ertek = Mentes_beolvasas(mentes[12]);
            _kis_sor.lezarva = Menetes_beolvasasaketto(mentes[12]);
            _kis_sor.szoveg = Menetes_beolvasasszoveg(mentes[12], _kis_sor.szoveg, _kis_sor.vegso_ertek);
            _gomb.Gep_kissor = Mentes_beolvasas(mentes[13]);
            _gomb.Gep_kissor_kesz = Menetes_beolvasasaketto(mentes[13]);

            _nagy_sor.vegso_ertek = Mentes_beolvasas(mentes[14]);
            _nagy_sor.lezarva = Menetes_beolvasasaketto(mentes[14]);
            _nagy_sor.szoveg = Menetes_beolvasasszoveg(mentes[14], _nagy_sor.szoveg, _nagy_sor.vegso_ertek);
            _gomb.Gep_nagysor = Mentes_beolvasas(mentes[15]);
            _gomb.Gep_nagysor_kesz = Menetes_beolvasasaketto(mentes[15]);

            _nagy_poker.vegso_ertek = Mentes_beolvasas(mentes[16]);
            _nagy_poker.lezarva = Menetes_beolvasasaketto(mentes[16]);
            _nagy_poker.szoveg = Menetes_beolvasasszoveg(mentes[16], _nagy_poker.szoveg, _nagy_poker.vegso_ertek);
            _gomb.Gep_nagypoker = Mentes_beolvasas(mentes[17]);
            _gomb.Gep_nagypoker_kesz = Menetes_beolvasasaketto(mentes[17]);

            _jatekos_pontszam.Pontok.Add(Mentes_beolvasas(mentes[18]));
            _gomb.Gep_pontszam = Mentes_beolvasas(mentes[19]);
            _gomb.korszam = Mentes_beolvasas(mentes[20]);
            if (mentes[21]=="true")
            {
                _gomb.Jatekoskore = true;
            }
            else if (mentes[21] == "false")
            {
                _gomb.Jatekoskore = false;
            }
            File.Delete("mentes.txt");
        }
        catch
        {

        }
    }

}
