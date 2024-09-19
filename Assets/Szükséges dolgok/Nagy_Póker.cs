using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Nagy_Póker : MonoBehaviour
{
    public Gomb _gomb;
    public Játékos_Pontszám _Játékos_Pontszám;
    private SpriteRenderer rend;
    public TMP_Text szoveg;
    public bool lezarva;
    public int vegso_ertek;
    static int Nagy_Poker(List<int> l, List<int> k)
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
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (_gomb.lenyomva && !lezarva&&_gomb.Jatekoskore)
        {
            lezarva = true;
            vegso_ertek = Nagy_Poker(_gomb.szamokra_rendezve, _gomb.kor);
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
            szoveg.text = (Nagy_Poker(_gomb.szamokra_rendezve, _gomb.kor)).ToString();
        }
        else if (!lezarva && !_gomb.Jatekoskore)
        {
            szoveg.text = " ";
        }
    }
}
