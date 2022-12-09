using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    //public static game_manager manager;

    public GameObject menu;

    public bool is_menu_show = true;

    
    private void Update()
    {
        show_menu();
        mouse_show();
        if (is_menu_show)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }
    public void show_menu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            is_menu_show = !is_menu_show;
        }
    }
    void mouse_show()
    {
        if (is_menu_show)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void show_around()
    {
        is_menu_show = !is_menu_show;
    }
    public void exit_game()
    {
        Application.Quit();
    }
}
