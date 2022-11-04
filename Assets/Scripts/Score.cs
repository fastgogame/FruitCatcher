using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private Text scoreBar;

    private void Start()
    {
        scoreBar = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        scoreBar.text = Fruit.GetScore().ToString();
    }    
}
