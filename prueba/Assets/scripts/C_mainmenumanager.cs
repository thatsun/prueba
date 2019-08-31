using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_mainmenumanager : MonoBehaviour
{
    bool ignoremenu = false;    
    public void PlayButton()
    {
        if (ignoremenu) return;

        ignoremenu = true;
        C_game_control.control.puntos = 0;
        C_game_control.control.juegopausado = false;
        C_game_control.control.change_levelsecure("gameplay");

    }
    public void MainmenuButton()
    {
        if (ignoremenu) return;

        ignoremenu = true;

        C_game_control.control.change_levelsecure("mainmenu");

    }
    public void ExitButton()
    {
        if (ignoremenu) return;

        ignoremenu = true;
        Application.Quit();

    }
}
