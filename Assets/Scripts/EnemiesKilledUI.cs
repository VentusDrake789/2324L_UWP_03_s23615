using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesKilledUI : MonoBehaviour
{
    public int kills = 0;
    public TextMeshProUGUI enemiesKilledText;
    public static EnemiesKilledUI instance;

    void Update()
    {
        enemiesKilledText.text = "Enemies Killed: " + kills.ToString();
    }

    public void addKill()
    {
        kills += 1;
        /*if (kills >= 10) 
        {
            Time.timeScale = 0;
        }*/
    }
}
