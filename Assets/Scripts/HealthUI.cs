using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = "Życie: " + health.ToString();
    }
}
