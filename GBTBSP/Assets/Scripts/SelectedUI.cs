using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectedUI : MonoBehaviour
{
    public Text targetName;
    public Text buttonText;
    public StatsPanel stats;
    public AudioSource buttonpress;

    public void UpdateTo(MoveAbleObject obj)
    {
        targetName.text = obj.unitName;
        stats.UpdateTo(obj.attackRange, obj.movementRange, obj.atk, obj.hp, obj.unitName, obj.unitDescr);
    }

    public void UpdateToNone()
    {
        targetName.text = "None";
    }

    public void showStatsPanel()
    {
        buttonpress.Play();
        if (!stats.gameObject.activeSelf)
        {
            buttonText.text = ">>";
            stats.gameObject.SetActive(true);
        }
        else
        {
            buttonText.text = "<<";
            stats.gameObject.SetActive(false);
        }
    }
}
