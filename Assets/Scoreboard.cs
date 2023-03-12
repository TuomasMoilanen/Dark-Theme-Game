using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public PointsCalculator points;
    public TextMeshProUGUI souls;
    public TextMeshProUGUI killed;


    private void Update()
    {
        souls.text = points.soulsCollectedTotal.ToString();
        killed.text = points.enemiesKilled.ToString();
    }
}
