using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject bulletPrefab;
    private Transform player;
    public float shootingRange = 5f;
    public float bulletSpeed = 10f;
    public float shootingCooldown = 1f;

    public Vector2 movementDirection;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Sprawdzenie zasięgu do gracza
        if (Vector2.Distance(transform.position, player.position) <= shootingRange)
        {
            // Zatrzymanie, jeśli gracz w zasięgu
            if (cooldownTimer > shootingCooldown)
            {
                ShootAtPlayer();
                cooldownTimer = 0f;
            }
        }
        else
        {
            Move();
        }

        cooldownTimer += Time.deltaTime;

        // Sprawdzenie, czy przeciwnik wyszedł poza ekran
        if (!IsVisibleFromCamera())
        {
            Destroy(gameObject);
        }
    }

    public void setRandomDirection(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void Move()
    {
        transform.position += (Vector3)movementDirection * moveSpeed * Time.deltaTime;
    }

    private void ShootAtPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }

    private bool IsVisibleFromCamera()
    {
        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        bool isVisible = viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1;
        return isVisible;
    }
}