using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Játékos_Pontszám : MonoBehaviour
{
    public List<int> Pontok;
    public TMP_Text szoveg;
    void Update()
    {
        szoveg.text = (Pontok.Sum()).ToString();
    }
}
