using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Domyślne życie gracza
    public TextMeshProUGUI healthText; // Referencja do komponentu tekstowego

    void Update()
    {
        healthText.text = "Życie: " + health.ToString(); // Aktualizacja tekstu życia
    }
}
