using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Debug.Log("Đã thu thập vật phẩm!");
            gameManager.AddScore(10);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Va chạm với kẻ thù!");
        }
        else if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Finish"))
        {
            Destroy(collision.gameObject);
            gameManager.GameWin();
        }
    }
}
