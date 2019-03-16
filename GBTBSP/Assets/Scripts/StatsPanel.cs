using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    public Text UnitName;
    public Text Description;
    public Text statNumbers;

    public void UpdateTo(int attackRange, int movementRange, int atk, int hp, string name, string descr)
    {
        UnitName.text = name;
        Description.text = descr;
        statNumbers.text = (attackRange + "\n\n" + movementRange + "\n\n" + atk + "\n\n" + hp);
    }
}
