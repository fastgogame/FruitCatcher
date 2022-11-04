using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int health;
    private Text healthBar;
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        healthBar = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        health = maxHealth - Fruit.GetLostFruits();
        healthBar.text = health.ToString();
        if (health < 1)
        {
            Fruit.SetScore(0);
            Fruit.SetLostFruits(0);
            SceneManager.LoadScene(scene.name);
        }
    }
}
