using TMPro;
using UnityEngine;

public class TowerStatUpgradeText : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;

    public void SetText(string statName, float oldValue, float newValue)
    {

        _text.text = $"{statName} : {oldValue} -> {newValue}";

    }

}
