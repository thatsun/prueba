using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class C_game_control : MonoBehaviour
{
    public static C_game_control control;
    //mis variables
    public int puntos = 0;
    public int hiscore = 5000;
    public string juego;
    public string savefile;
    public C_fading fade;

    public bool juegopausado = false;

    public bool shield = false;
    public bool firepower = false;
    public bool triplefire = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;

            //adding defaul data to mision catalog
            
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Load_playerdata();
    }
    
    public void change_levelsecure(string scenename)
    {


        Time.timeScale = 1;
        StartCoroutine(ChangeLevel(scenename));
    }
    IEnumerator ChangeLevel(string scene)
    {
        float fadeTime = C_game_control.control.fade.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(scene);

    }

    public void Load_playerdata()
    {
        if (File.Exists(Application.persistentDataPath + "/" + juego + savefile + "094.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream my_file = File.Open(Application.persistentDataPath + "/" + juego + savefile + "094.dat", FileMode.Open);
            PlayerData my_data = (PlayerData)bf.Deserialize(my_file);

            hiscore = my_data.hiscore;

            


            my_file.Close();
            Debug.Log("datos player cargadas");
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + juego + savefile + "094.dat");
            PlayerData data = new PlayerData();

            data.hiscore = hiscore;
            

            bf.Serialize(file, data);
            file.Close();
            Debug.Log("datos player guardadas");
        }
    }
    public void Save_playerdata()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + juego + savefile + "094.dat");
        PlayerData data = new PlayerData();

        data.hiscore = hiscore;

        


        bf.Serialize(file, data);
        file.Close();
        Debug.Log("datos player guardadas");

    }
}
[Serializable]
public class PlayerData
{
    
    public int hiscore;
    
}