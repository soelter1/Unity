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
        stats.UpdateTo(obj.atk, obj.movementRange, obj.hp, obj.unitName, obj.unitDescr);
    }

    public void UpdateToNone()
    {
        targetName.text = "None";
    }

    public void showStatsPanel()
    {
        if (!stats.gameObject.activeSelf) stats.gameObject.SetActive(true);
        else stats.gameObject.SetActive(false);
    }
}
