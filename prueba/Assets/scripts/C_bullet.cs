using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_bullet : MonoBehaviour
{
    bool activa = false;
    [SerializeField]
    Animator bulletanim;
    [SerializeField]
    Collider2D colliderbullet;
    [SerializeField]
    Rigidbody2D body;
    [SerializeField]
    float bulletlife = 2.0f;
    [SerializeField]
    float speed = 5.0f;



    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!activa) return;

        if (other.CompareTag("enemy")||other.CompareTag("bulletenemy"))
        {
            activa = false;
            CancelInvoke();
            body.gravityScale = 0;
            body.velocity = Vector3.zero;
            colliderbullet.enabled = false;

            bulletanim.Play("bulletinpact",0);
            Invoke("disablebullet",0.5f);
        }
    }
    private void OnEnable()
    {
        Invoke("disablebullet", bulletlife);
        body.gravityScale = -speed;
        colliderbullet.enabled = true;
        activa = true;
    }    // Update is called once per frame
    void disablebullet()
    {
        activa = false;
        this.gameObject.SetActive(false);
    }
}
