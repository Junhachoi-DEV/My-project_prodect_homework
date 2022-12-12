using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    

    public GameObject menu;
    public GameObject f_menu_back;
    public RectTransform f_menu;

    public GameObject[] text_list;
    

    public bool is_f_menu;
    //bool[] is_texts; 

    public bool is_menu_show = true;

    //public static game_manager manager => manager;
    // 오류남. 이유는 두개 A 함수에서 B를 호출하는데, B에서 A를 호출하면
    // A->B->A->B->A->B->A->B->A->B->A->B->A->B->A->B->A->B->A->B-> ...
    // 이렇게 호출하다 보면 Stack Frame을 만들어주기 위한.
    // 호출스택이 꽉 차서 StackOverflow가 발생.
    check_controller check;

    private void Start()
    {
        check = FindObjectOfType<check_controller>();
    }

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
            check_effects();
        }
        else
        {
            f_menu.anchoredPosition = Vector2.down * 680;
            f_menu_back.SetActive(false);
        }
    }

    void check_effects()
    {
        if (check.check_obj())
        {
            if (check.hit_info.transform.name == "effect_intro")
            {
                text_list[0].SetActive(true);
                text_list[1].SetActive(false);
                text_list[2].SetActive(false);
            }
            if (check.hit_info.transform.name == "effect_explain")
            {
                text_list[0].SetActive(false);
                text_list[1].SetActive(true);
                text_list[2].SetActive(false);
            }
            if (check.hit_info.transform.name == "effect_sung_le_moon")
            {
                text_list[0].SetActive(false);
                text_list[1].SetActive(false);
                text_list[2].SetActive(true);
            }
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
