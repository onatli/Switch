using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.IO;
using System.IO;
public class Stars : MonoBehaviour
{
    public GameObject[] Star;
    public static string PathLevel;
    int Move , Optimum;
    public int[] LevelStars = new int[40];
    public static int MoveFirst;
    string TempLevel;
    public GameObject PlayAgainB;
    public AudioSource StarSound1,StarSound2,StarSound3;
    void CreateLevelStars()
    {
        
        PathLevel = Application.persistentDataPath + "/LevelStars.txt";
        
        if (!File.Exists(PathLevel))
        {
            File.WriteAllText(PathLevel, "");
        }
        
    }
    void LevelEntry(int a)
    {
        LevelMenu.LevelStars[(SceneManager.GetActiveScene().buildIndex) - 2] = a;
        
        foreach (var item in LevelMenu.LevelStars)
        {
            
            TempLevel += item.ToString() + '\n';
            
            

        }
        File.WriteAllText(PathLevel, TempLevel);
        
    }
    public static string LevelRead()
    {
        PathLevel = Application.persistentDataPath + "/LevelStars.txt";
        StreamReader reader = new StreamReader(PathLevel);
        string a = reader.ReadToEnd();
        reader.Close();
        return a;
    }
    
    void Start()
    {
        Move = FindObjectOfType<Shape_Check>().Move_Counter;
        Star[0] = this.transform.GetChild(1).gameObject;
        Star[1] = this.transform.GetChild(2).gameObject;
        Star[2] = this.transform.GetChild(3).gameObject;
        PlayAgainB = this.transform.GetChild(5).gameObject;
        CreateLevelStars();
        StarSound1 = this.transform.GetChild(1).GetComponent<AudioSource>();
        StarSound2 = this.transform.GetChild(2).GetComponent<AudioSource>();
        StarSound3 = this.transform.GetChild(3).GetComponent<AudioSource>();
        
        if (MainMenu.Sounds)
        {
            StarSound1.volume = 0.5f;
            StarSound2.volume = 0.5f;
            StarSound3.volume = 0.5f;
        }
        else
        {
            StarSound1.volume = 0;
            StarSound2.volume = 0;
            StarSound3.volume = 0;
        }

        Optimum = MoveFirst - 15;

        if (Move >= MoveFirst-(Optimum + 3))
        {
            
            Star[0].SetActive(true);
            Star[1].SetActive(true);
            Star[2].SetActive(true);
            
            Shape_Check.TotalStars += 3;
            LevelEntry(3);



        }
        else if (Move >= MoveFirst - (Optimum + 8))
        {

            Star[0].SetActive(true);
            Star[1].SetActive(true);
            PlayAgainB.SetActive(true);
            Shape_Check.TotalStars += 2;
            LevelEntry(2);
        }
        else
        {

            Star[0].SetActive(true);
            Shape_Check.TotalStars++;
            PlayAgainB.SetActive(true);
            LevelEntry(1);


        }

    }
    void Update()
    {
        
    }
}
