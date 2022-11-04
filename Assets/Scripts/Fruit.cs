using UnityEngine;
using UnityEngine.Audio;

public class Fruit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D fruit;
    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failSound;

    private static int lostFruits = 0;
    private static int score = 0;

    private Vector2 screenBounds;

    private void Start()
    {
        fruit = this.GetComponent<Rigidbody2D>();
        screenBounds = Spawner.GetScreenBounds();
    }

    private void Update()
    {
        if(fruit.transform.position.y < -screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(successSound, new Vector3(0f, 0f, 0f));
            score++;
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("LoseCounter"))
        {
            AudioSource.PlayClipAtPoint(failSound, new Vector3(0f, 0f, 0f));
            lostFruits++;
        }
    }

    public static int GetScore()
    {
        return score;
    }

    public static void SetScore(int value)
    {
        score = value;
    }

    public static int GetLostFruits()
    {
        return lostFruits;
    }
    public static void SetLostFruits(int value)
    {
        lostFruits = value;
    }
}
