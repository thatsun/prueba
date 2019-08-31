using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_poolerbullets : MonoBehaviour
{
    [SerializeField]
    int maxbullet = 20;
    

    public GameObject[] bullets;
    public Transform[] bullets_trans;

    [SerializeField]
    GameObject balaprefab;
    // Start is called before the first frame update
    void Start()
    {
        Createbullets();
    }
    void Createbullets()
    {
        bullets = new GameObject[maxbullet];
        bullets_trans = new Transform[maxbullet];
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = GameObject.Instantiate(balaprefab);
            bullets_trans[i] = bullets[i].GetComponent<Transform>();
        }
    }    
}
