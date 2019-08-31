using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_powerup : MonoBehaviour
{
    float directionX = 0;
    bool activa = false;

   
    [SerializeField]
    Collider2D itemcollider;
    [SerializeField]
    Rigidbody2D body;
    [SerializeField]
    float itemlife = 20.0f;
    [SerializeField]
    float speedX = 10f;
    [SerializeField]
    float speedY = 0.05f;
    float IAinterval = 0.5f;   

   
    // Start is called before the first frame update
    void OnEnable()
    {
        IAinterval = Random.Range(1.5f, 1.6f);
        Invoke("Switchdirection", IAinterval);
        Invoke("Disableitem", itemlife);
        
        body.gravityScale = speedY;
        itemcollider.enabled = true;
        activa = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activa) return;

        if (other.CompareTag("Player") )
        {
            
            activa = false;
            CancelInvoke();
            body.gravityScale = 0;
            body.velocity = Vector3.zero;
            itemcollider.enabled = false;

            
            Disableitem();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!activa) return;

        body.velocity = new Vector3(directionX * speedX * Time.deltaTime, body.velocity.y, 0);
    }
    void Switchdirection()
    {
        directionX = speedX * Random.Range(-1, 2);
        IAinterval = Random.Range(1.5f, 1.6f);
        Invoke("Switchdirection", IAinterval);
    }
    void Disableitem()
    {
        activa = false;
        this.gameObject.SetActive(false);
    }   
}
