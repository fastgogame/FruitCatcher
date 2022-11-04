using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private static bool isPaused = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivateMenu();
            Cursor.visible = true;
        }
        else
        {
            DeactivateMenu();
            Cursor.visible = false;
        }
    }

    private void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        menu.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        menu.SetActive(false);
        isPaused = false;
    }

    public static bool GetIsPaused()
    {
        return isPaused;
    }
}
