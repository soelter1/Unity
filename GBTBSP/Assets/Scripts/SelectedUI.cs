using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectedUI : MonoBehaviour
{
    public Text targetName;
    public StatsPanel stats;

    public void UpdateTo(MoveAbleObject obj)
    {
        targetName.text = obj.unitName;
        stats.UpdateTo(obj.atk, obj.movementRange, obj.hp);
    }

    public void UpdateToNone()
    {
        targetName.text = "None";
    }

    public void showStatsPanel()
    {
        stats.gameObject.SetActive(true);
    }
}
