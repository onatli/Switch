using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.IO;
using System.IO;
using System;
using UnityEngine.Advertisements;

public class Shape_Check : Cubes
{
    public static int TotalStars;
    public Text moveText,LevelN;
    public int Move_Counter , S_Counter;
    public static bool addmove = false;
    string Move, LangPath;
    public GameObject[] Obj;
    public GameObject LevelClear, LevelFail, PauseMenu, Goal, PlayAgainB;
    public bool clickable = true, start = false;
    string[] LangSub;

    
    
    public bool ShapeControl()
    {
        
        foreach (GameObject Obj in Obj)
        {

            if (Goal.transform.rotation.eulerAngles == Obj.transform.rotation.eulerAngles)
            {
                S_Counter++;
            }
        }
        if (Obj.Length == S_Counter)
        {
            return true;
        }else
        {
            S_Counter = 0;
            return false;
        }
    }
    void ReadLangFile()
    {
        LangPath = Application.persistentDataPath + "/Lang/" + MainMenu.language + ".txt";
        StreamReader reader = new StreamReader(LangPath);
        LangSub = reader.ReadToEnd().Split('\n');
    }
    void Start()
    {
        if (Directory.Exists(Application.persistentDataPath+"/Lang"))
        {
            ReadLangFile();
        }
        moveText = GameObject.Find("Canvas").transform.GetChild(2).GetComponent<Text>();
        LevelN = GameObject.Find("Canvas").transform.GetChild(5).GetComponent<Text>();
        Move = moveText.text;
        Move_Counter = Convert.ToInt32(Move);
        Stars.MoveFirst = Move_Counter;
        Obj = GameObject.FindGameObjectsWithTag("Cubes");
        Goal = GameObject.Find("Cube_Goal");
        LevelN.text = SceneManager.GetActiveScene().name;
        File.WriteAllText(Application.persistentDataPath + "/CL.txt", SceneManager.GetActiveScene().name + "-" + MainMenu.language + "-" + MainMenu.MscToggle + "-" + MainMenu.Sounds + "-" + Tutorial.tutorial);
        LevelClear = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        LevelClear.transform.GetChild(4).GetComponent<Text>().text = LangSub[11];
        PlayAgainB = LevelClear.transform.GetChild(5).gameObject;
        PlayAgainB.transform.GetChild(0).GetComponent<Text>().text = LangSub[13];
        LevelClear.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = LangSub[12];




        LevelFail = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        LevelFail.transform.GetChild(1).GetComponent<Text>().text = LangSub[14];
        LevelFail.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = LangSub[13];
        LevelFail.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = LangSub[15];
        LevelFail.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = LangSub[16];

        PauseMenu = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
        PauseMenu.transform.GetChild(1).GetComponent<Text>().text = LangSub[19];
        PauseMenu.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = LangSub[8];
        PauseMenu.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = LangSub[16];
        PauseMenu.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = LangSub[4];

        

    }

    
    void Update()
    {
        if (addmove)
        {
            addmove = false;
            Move_Counter += 5;
            clickable = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetMouseButtonUp(0))
        {

            moveText.text = Move_Counter.ToString();
            start = true;
        }
        if (Move_Counter>0)
        {

            if (start && ShapeControl())
            {
                
                LevelClear.SetActive(true);
                
                clickable = false;
                
              
            }
        }
        
        else
        {
            
            moveText.text = "0";
            clickable = false;
            LevelFail.SetActive(true);
        }
        
    }
    
}
