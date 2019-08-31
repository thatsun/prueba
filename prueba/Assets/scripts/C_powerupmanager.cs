using UnityEngine;

public class C_powerupmanager : MonoBehaviour
{
    [SerializeField]
    GameObject shield;
    [SerializeField]
    Transform shield_t;
    [SerializeField]
    float shieldspawn=5f;
    

    [SerializeField]
    GameObject firepower;
    [SerializeField]
    Transform firepower_t;
    [SerializeField]
    float firepowerspawn = 10f;

    [SerializeField]
    GameObject triplefire;
    [SerializeField]
    Transform triplefire_t;
    [SerializeField]
    float triplefirespawn = 15f;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("activatehield", 5f, shieldspawn);
        InvokeRepeating("activatefirepower", 20f, shieldspawn);
        InvokeRepeating("activatetriplefire", 25f, shieldspawn);
    }

    // Update is called once per frame
    void activatehield()
    {
        if (!shield.activeInHierarchy & C_game_control.control.shield == false)
        {
            shield_t.position = transform.position;
            shield.SetActive(true);
        }
    }
    void activatefirepower()
    {
        if (!firepower.activeInHierarchy & C_game_control.control.firepower == false)
        {
            firepower_t.position = transform.position;
            firepower.SetActive(true);
        }
    }
    void activatetriplefire()
    {
        if (!triplefire.activeInHierarchy & C_game_control.control.triplefire == false)
        {
            triplefire_t.position = transform.position;
            triplefire.SetActive(true);
        }
    }
}
