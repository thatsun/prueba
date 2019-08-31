using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_enemymanager : MonoBehaviour
{
    [SerializeField]
    int maxenemies = 20;
    [SerializeField]
    float spawnfrecuency = 0.5f;

    GameObject[] enemies;
    Transform[] enemiestrans;
    C_enemigo[] enemiesinfo;

    [SerializeField]
    public GameObject enemyprefab;

    Vector3 spawnhelper = new Vector3(0,10,0);
    // Start is called before the first frame update
    [SerializeField]
    C_poolerbullets currentpooler;

    [SerializeField]
    C_puntagemanager puntajemanager;

    void Start()
    {
        Createnemies();
    }

    // Update is called once per frame
    void Createnemies()
    {
        enemies = new GameObject[maxenemies];
        enemiestrans = new Transform[maxenemies];
        enemiesinfo = new C_enemigo[maxenemies];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = GameObject.Instantiate(enemyprefab);
            enemiestrans[i] = enemies[i].GetComponent<Transform>();
            enemiesinfo[i]= enemies[i].GetComponent<C_enemigo>();
            enemiesinfo[i].poolerbullets = currentpooler;
            enemiesinfo[i].puntagemanager = puntajemanager;
        }
        InvokeRepeating("Spawnenemie", spawnfrecuency, spawnfrecuency);
    }
    void Spawnenemie()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                spawnhelper.x = Random.Range(-7,7);

                enemiestrans[i].transform.position = spawnhelper;
                enemies[i].SetActive(true);
                
                
                return;

            }
        }
        
    }
}
