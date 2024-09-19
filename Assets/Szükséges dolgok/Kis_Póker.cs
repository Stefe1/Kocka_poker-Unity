using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kis_Póker : MonoBehaviour
{
    public Gomb _gomb;
    public Játékos_Pontszám _Játékos_Pontszám;
    private SpriteRenderer rend;
    public TMP_Text szoveg;
    public bool lezarva;
    public int vegso_ertek;
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
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (_gomb.lenyomva && !lezarva && _gomb.Jatekoskore)
        {
            lezarva = true;
            vegso_ertek = Kis_poker(_gomb.szamokra_rendezve);
            _Játékos_Pontszám.Pontok.Add(vegso_ertek);
            szoveg.fontStyle = FontStyles.Bold;
            _gomb.lenyomva = false;
            _gomb.Jatekoskore = false;
        }
    }
    void Update()
    {
        if (_gomb.lenyomva && !lezarva && _gomb.Jatekoskore)
        {
            szoveg.text = (Kis_poker(_gomb.szamokra_rendezve)).ToString();
        }
        else if (!lezarva && !_gomb.Jatekoskore)
        {
            szoveg.text = " ";
        }
    }
}
