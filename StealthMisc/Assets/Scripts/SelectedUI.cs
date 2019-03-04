using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectedUI : MonoBehaviour
{
    public Text targetName;

    public void UpdateName(string name)
    {
        targetName.text = name;
    }
}
