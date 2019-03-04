using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{

    public Text statNumbers;

    public void UpdateTo(int atk, int range, int hp)
    {
        statNumbers.text = (atk+"\n\n"+range+"\n\n"+hp);
    }
    public void close()
    {
        this.gameObject.SetActive(false);
    }
}
