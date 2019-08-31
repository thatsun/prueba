using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_scoremanager : MonoBehaviour
{
    [SerializeField]
    Text hiscoreUI;

    [SerializeField]
    GameObject newrecord;
    bool ignoremenu = true;
    // Start is called before the first frame update
    void Start()
    {
        hiscoreUI.text = "" + C_game_control.control.puntos;
        if (C_game_control.control.puntos>C_game_control.control.hiscore)
        {
            newrecord.SetActive(true);
            C_game_control.control.hiscore = C_game_control.control.puntos;
            C_game_control.control.Save_playerdata();
        }
        ignoremenu = false;
    }
    
    public void RetryButton()
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
}
