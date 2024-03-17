using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D playerRB;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    private Vector2 movement;
    private Vector2 lastMovementDirection;

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Zapamiętujemy ostatni kierunek ruchu
        if (movement != Vector2.zero)
        {
            lastMovementDirection = movement;
        }

        // Strzelanie
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(lastMovementDirection);
        }
    }

    void FixedUpdate()
    {
        // Ruch
        playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot(Vector2 direction)
    {
        if (direction != Vector2.zero) // Sprawdzamy, czy jest ustalony kierunek strzału
        {
            GameObject bullet = Instantiate(bulletPrefab, playerRB.position + direction, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * bulletSpeed;
        }
    }
}