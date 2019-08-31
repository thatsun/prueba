using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_scrolltexture : MonoBehaviour
{
    [SerializeField]
    Renderer background;
    Vector2 offset=new Vector2(0,0);
    [SerializeField]
    float scrollSpeed=1.0f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        offset.y = Time.time * scrollSpeed;
        
        background.material.SetTextureOffset("_MainTex",offset);
    }
}
