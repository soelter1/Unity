using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    public Text UnitName;
    public Text Description;
    public Text statNumbers;

    public void UpdateTo(int atk, int range, int hp, string name, string descr)
    {
        UnitName.text = name;
        Description.text = descr;
        statNumbers.text = (atk+"\n\n"+range+"\n\n"+hp);
    }
}
