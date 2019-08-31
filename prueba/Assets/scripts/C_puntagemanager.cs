using UnityEngine;
using UnityEngine.UI;
public class C_puntagemanager : MonoBehaviour
{
    [SerializeField]
    Text puntageUI;
    [SerializeField]
    Text hiscoreUI;
    // Start is called before the first frame update
    private void Start()
    {
        hiscoreUI.text = "" + C_game_control.control.hiscore;
        puntageUI.text = "0";
    }
    public void EarnPoints()
    {
        C_game_control.control.puntos+=100;

        puntageUI.text = ""+C_game_control.control.puntos;
    }

}
