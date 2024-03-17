using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int damage = 10;


        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthUI>().takeDamage(damage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemiesKilledUI.instance.addKill();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!IsVisibleFromCamera()){
            Destroy(gameObject);
        }
    }

    private bool IsVisibleFromCamera()
    {
        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        bool isVisible = viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1;
        return isVisible;
    }
}
