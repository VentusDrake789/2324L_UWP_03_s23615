using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
