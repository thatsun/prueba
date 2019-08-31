using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_controlUI : MonoBehaviour
{
    [SerializeField]
    GameObject controlUI;
    bool shown = false;
    // Start is called before the first frame update
    public void show()
    {
        if (shown==false)
        {
            shown = true;
            controlUI.SetActive(true);
            Time.timeScale = 0;
            C_game_control.control.juegopausado = true;
        }
        else
        {
            shown = false;
            controlUI.SetActive(false);
            Time.timeScale = 1;
            C_game_control.control.juegopausado = false;
        }
        
    }

    
}
