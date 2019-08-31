using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_genericshoter : MonoBehaviour
{
    [SerializeField]
    C_poolerbullets currentpoler;
    // Start is called before the first frame update
    public void shot()
    {
        for(int i = 0; i < currentpoler.bullets.Length; i++)
            {
            if (!currentpoler.bullets[i].activeInHierarchy)
            {
                currentpoler.bullets[i].transform.position = transform.position;
                currentpoler.bullets[i].SetActive(true);

                
                
                return;

            }
        }
    }

}
