using UnityEngine;
using UnityEngine.UI;

public class BasketMovement : MonoBehaviour
{
    [SerializeField] private Slider mouseSlider;
    [SerializeField] private Text sensitivityNumber;

    private float mouseSensitivity = 1f;

    private Vector2 screenBounds;
    private float basketWidth;

    private void Start()
    {
        screenBounds = Spawner.GetScreenBounds();

        basketWidth = gameObject.GetComponent<Collider2D>().bounds.size.x / 2f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!Menu.GetIsPaused())
        {
            float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x * mouseSensitivity;
            mousePos = Mathf.Clamp(mousePos, -screenBounds.x + basketWidth, screenBounds.x - basketWidth);
            transform.position = new Vector2(mousePos, transform.position.y);
        }
    }

    public void ApplySensitivity()
    {
        mouseSensitivity = mouseSlider.value;
        float sensPercent = mouseSlider.value / (mouseSlider.maxValue - mouseSlider.minValue) * 100f;
        sensitivityNumber.text = ((int)sensPercent - 5).ToString() + "%";
    }
}
