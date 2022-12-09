using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_controller : MonoBehaviour
{
    RaycastHit hit_info;

    public int check_distance;

    public bool is_press_f_show;

    public GameObject press_f_butten;

    
    void Update()
    {
        if (check_obj())
        {
            Debug.Log(hit_info);
            if(hit_info.transform.tag == "inter")
            {
                is_press_f_show = true;
                press_f_butten.SetActive(true);
            }
        }
        else
        {
            is_press_f_show = false;
            press_f_butten.SetActive(false);
        }
    }

    bool check_obj()
    {
        // 캐릭터의 위치에 생성, 방향, 닿은것의 정보값 넣기, 거리
        if (Physics.Raycast(transform.position, transform.forward, out hit_info, check_distance))
        {
            return true;
        }
        return false;
    }
}
