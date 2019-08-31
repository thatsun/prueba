using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_enemigo : MonoBehaviour
{
    float directionX=0;
    bool activa = false;

    [SerializeField]
    Animator enemyanim;
    [SerializeField]
    Collider2D colliderenemy;
    [SerializeField]
    Rigidbody2D body;
    [SerializeField]
    float enemylife = 20.0f;
    [SerializeField]
    float speedX = 10f;
    [SerializeField]
    float speedY = 0.05f;
    float IAinterval = 0.5f;
    [HideInInspector]
    public C_poolerbullets poolerbullets;
    [HideInInspector]
    public C_puntagemanager puntagemanager;

    bool allowshot = true;
    [SerializeField]
    float shotfrecuency = 5.0f;
    // Start is called before the first frame update
    void OnEnable()
    {
        IAinterval = Random.Range(1.5f, 1.6f);
        
        body.gravityScale = speedY;
        colliderenemy.enabled = true;
        activa = true;
        allowshot = true;
        Invoke("Switchdirection", IAinterval);
        Invoke("Disableenemy", enemylife);
        Invoke("Shotbullets", shotfrecuency);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activa) return;

        if (other.CompareTag("Player") || other.CompareTag("bulletplayer"))
        {
            puntagemanager.EarnPoints();
            activa = false;
            CancelInvoke();
            body.gravityScale = 0;
            body.velocity = Vector3.zero;
            colliderenemy.enabled = false;
            
            enemyanim.Play("enemydie", 0);
            Invoke("Disableenemy", 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!activa) return;

        body.velocity = new Vector3( directionX * speedX * Time.deltaTime, body.velocity.y , 0);
    }
    void Switchdirection()
    {
        directionX = speedX * Random.Range(-1, 2);
        IAinterval = Random.Range(1.5f, 1.6f);
        Invoke("Switchdirection", IAinterval);
    }
    void Disableenemy()
    {
        activa = false;
        this.gameObject.SetActive(false);
    }
    public void Shotbullets()
    {
        if (allowshot)
        {
            for (int i = 0; i < poolerbullets.bullets.Length; i++)
            {
                if (!poolerbullets.bullets[i].activeInHierarchy)
                {
                    poolerbullets.bullets_trans[i].transform.position = transform.position;
                    poolerbullets.bullets[i].SetActive(true);
                    allowshot = false;

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
}
