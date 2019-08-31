using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_player_control : MonoBehaviour
{
    float x = 0;
    Rigidbody2D playerbody;
    [SerializeField]
    float speed = 1;
    Animator anim;
    bool muerto = false;    
    bool allowshot=true;

    [SerializeField]
    int maxusablebullet = 10;
    [SerializeField]
    int maxbullet=20;
    int currentmaxbullets;
    [SerializeField]
    float shotfrecuency=0.5f;

    GameObject[] bullets;
    Transform[] bullets_trans;
    [SerializeField]
    GameObject balaprefab;

    [SerializeField]
    ParticleSystem explosion;

    [SerializeField]
    GameObject playerdislpay;

    [SerializeField]
    AudioSource shotSFX;
    [SerializeField]
    AudioSource dieSFX;

    [SerializeField]
    GameObject shieldGO;

    [SerializeField]
    GameObject pauseUI;

    [SerializeField]
    C_genericshoter[] shoters = new C_genericshoter[2];

    

    // Start is called before the first frame update
    void Start()
    {
        currentmaxbullets = maxusablebullet;
        C_game_control.control.shield = false;
        C_game_control.control.firepower = false;
        C_game_control.control.triplefire = false;
        Createbullets();
        playerbody =gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Createbullets()
    {
        bullets = new GameObject[maxbullet];
        bullets_trans = new Transform[maxbullet];
        for (int i=0; i< bullets.Length; i++)
        {
            bullets[i] = GameObject.Instantiate(balaprefab);
            bullets_trans[i] = bullets[i].GetComponent<Transform>();
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (muerto)return;
        if (C_game_control.control.juegopausado) return;
        
        if (other.CompareTag("firepower") & !C_game_control.control.firepower)
        {

            firepowerup();
            return;
        }
        if (other.CompareTag("triplefire") & !C_game_control.control.triplefire)
        {

            triplefire();
            return;
        }        
        if (other.CompareTag("shield")&!C_game_control.control.shield)
        {

            pickupshield();
            return;
        }
        if (other.CompareTag("enemy") || other.CompareTag("bulletenemy"))
        {
            if (C_game_control.control.shield) return;
            muerto = true;
            x = 0;
            playerbody.velocity = Vector3.zero;
            playerdislpay.SetActive(false);
            //anim.Play("muerto");
            dieSFX.Play();
            explosion.Play();
            Invoke("Gameover",2.0f);
        }
    }
    public void Shotbullets(int _shoter)
    {
        if (allowshot)
        {
            if (C_game_control.control.triplefire)
            {
                shoters[0].shot();
                shoters[1].shot();

            }
            for (int i = 0; i < currentmaxbullets; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets_trans[i].transform.position =transform.position;
                    bullets[i].SetActive(true);
                    allowshot = false;
                    shotSFX.Play();
                    Invoke("Allowshotbullet", shotfrecuency);
                    return;

                }                
            }
            
            

        }        
    }
    void Allowshotbullet()
    {
        allowshot = true;
    }
    void Gameover()
    {
        C_game_control.control.change_levelsecure("gameover");
    }
    public void resumebutton()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
        C_game_control.control.juegopausado = false;
    }
    public void exitbutton()
    {
        C_game_control.control.change_levelsecure("mainmenu");
    }
    void Update()
    {
        if (C_game_control.control.juegopausado)
        {
            if (Input.GetButtonDown("Pausa"))
            {
                Time.timeScale = 1.0f;
                pauseUI.SetActive(false);
                C_game_control.control.juegopausado = false;                
            }
            return;
        }
        if (muerto) return;
        x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Pausa"))
        {
            C_game_control.control.juegopausado = true;
            Time.timeScale = 0;
            pauseUI.SetActive(true);
            return;
        }
        if (Input.GetButton("Shot"))
        {
            Shotbullets(0);


        }

        if (Input.GetAxis("Horizontal")!=0)
        {
            playerbody.velocity=new Vector3( x * speed * Time.deltaTime,0,0);
        }
        
    }
    void pickupshield()
    {

        C_game_control.control.shield = true;
        shieldGO.SetActive(true);
        Invoke("disableshield", 20f);
    }
    void disableshield()
    {
        shieldGO.SetActive(false);
        C_game_control.control.shield = false;
    }
    void firepowerup()
    {

        C_game_control.control.firepower = true;
        currentmaxbullets = maxbullet;
        Invoke("disablefirepowerup", 20f);
    }
    void triplefire()
    {

        C_game_control.control.triplefire = true;
        
        Invoke("disabletriplefire", 20f);
    }
    void disablefirepowerup()
    {
        C_game_control.control.firepower = false;
        currentmaxbullets = maxbullet;
    }
    void disabletriplefire()
    {
        C_game_control.control.triplefire = false;
        
    }
}
