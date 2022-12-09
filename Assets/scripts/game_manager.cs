using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    //public static game_manager manager;

    public GameObject menu;
    public GameObject f_menu_back;
    public RectTransform f_menu;

    public bool is_f_menu;
    public bool is_menu_show = true;

    
    private void Update()
    {
        show_menu();
        show_f_menu();
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
    public void show_around()
    {
        is_menu_show = !is_menu_show;
    }

    public void show_f_menu()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            is_f_menu = !is_f_menu;
        }
        if (is_f_menu)
        {
            f_menu.anchoredPosition = Vector2.zero;
            f_menu_back.SetActive(true);
        }
        else
        {
            f_menu.anchoredPosition = Vector2.down * 680;
            f_menu_back.SetActive(false);
        }
    }
    public void show_f_around()
    {
        is_f_menu = !is_f_menu;
    }

    void mouse_show()
    {
        if (is_menu_show || is_f_menu)
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

    public void exit_game()
    {
        Application.Quit();
    }
}
