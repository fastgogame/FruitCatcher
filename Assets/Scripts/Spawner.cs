using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private float respawnTime = 2f;

    private static Vector2 screenBounds;

    private void Start()
    {
        SetScreenBounds();
        StartCoroutine(RunSpawner());
    }

    private void Update()
    {
        int score = Fruit.GetScore();
        respawnTime = 3 / (1 + Mathf.Sqrt(score));
    }

    private void SpawnFruit()
    {
        GameObject fruit = Instantiate(fruitPrefab);
        fruit.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 1.2f);
    }

    private IEnumerator RunSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnFruit();
        }
    }

    private void SetScreenBounds()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public static Vector2 GetScreenBounds()
    {
        return screenBounds;
    }
}
