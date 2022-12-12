using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class check_controller : MonoBehaviour
{
    //private static check_controller c_controller = null;
    public RaycastHit hit_info;
    public RaycastHit hit_info2;

    public int check_distance;

    public bool is_press_f_show;

    public float in_time;
    public float max_in_time =2;

    public GameObject _3second_ui_obj;
    public Camera _camera;
    [SerializeField]
    Image _3s_img;
    game_manager g_manager;

    private void Start()
    {
        g_manager = FindObjectOfType<game_manager>();
    }
    //public static check_controller c_controller;
    

    void Update()
    {
        if (check_obj())
        {
            //Debug.Log(hit_info.transform.name);
            //Debug.Log(hit_info.transform.tag);
            if (hit_info.transform.tag == "inter")
            {
                is_press_f_show = true;
                _3second_ui_obj.SetActive(true);
                look_on();
            }
        }
        else
        {
            _3s_img.fillAmount = 0;
            in_time = 0;
            is_press_f_show = false;
            _3second_ui_obj.SetActive(false);
        }
    }

    public bool check_obj()
    {
        // 캐릭터의 위치에 생성, 방향, 닿은것의 정보값 넣기, 거리
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit_info, check_distance))
        {
            return true;
        }
        return false;
    }
    public bool check_effect_obj()
    {
        // 캐릭터의 위치에 생성, 방향, 닿은것의 정보값 넣기, 거리
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit_info2, check_distance * 3))
        {
            return true;
        }
        return false;
    }

    void look_on()
    {
        
        if(_3s_img.fillAmount < 1 && !g_manager.is_f_menu)
        {
            in_time += Time.deltaTime / max_in_time;
            _3s_img.fillAmount = in_time;
        }
        else
        {
            g_manager.is_f_menu = true;
            _3s_img.fillAmount = 0;
            in_time = 0;
        }
        
    }
}
