using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.IO;
using System.IO;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialText1, TutorialText2, TutorialImage1, TutorialImage2;
    string tutorLog;
    string[] tutorsub;
    public GameObject Cube, LevelClear;
    public static bool tutorial = true;
    public Animator Finger,Red_C;
    public int counter=0;
    public static int ReadStart = 23;

    void Start()
    {

        Cube = GameObject.Find("Cube_W");

        TutorialText1 = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        TutorialText2 = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        TutorialImage1 = GameObject.Find("Canvas").transform.GetChild(6).gameObject;
        LevelClear = GameObject.Find("Canvas").transform.GetChild(0).gameObject;

        Finger = GameObject.Find("Canvas").transform.GetChild(6).GetComponent<Animator>();


        ReadLang();


        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            counter = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            counter = 5;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            counter = 10;
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            counter = 15;
        }
        else if (SceneManager.GetActiveScene().name == "Level 9")
        {
            counter = 20;
        }
        else if (SceneManager.GetActiveScene().name == "Level 11")
        {
            counter = 25;
        }
        else if (SceneManager.GetActiveScene().name == "Level 21")
        {
            counter = 30;
        }
        else
        {
            counter = 35;
        }

    }
    void Update()
    {
        if (LevelClear.activeSelf)
        {
            TutorialEnd();
        }
        if (tutorial)
        {


            switch (counter)
            {
                case 0:
                    TutorialW();
                    break;
                case 1:
                    if (Cube.transform.rotation.eulerAngles.y == 0)
                    {
                        TutorialW2();
                    }
                    break;
                case 2:
                    TutorialEnd();
                    counter++;
                    break;
                case 5:
                    TutorialMove();
                    break;
                case 6:
                    TutorialEnd();
                    counter++;
                    break;
                case 10:
                    TutorialB();
                    break;
                case 11:
                    TutorialEnd();
                    counter++;
                    break;
                case 15:
                    TutorialG();
                    break;
                case 16:
                    TutorialEnd();
                    counter++;
                    break;
                case 20:
                    TutorialS();
                    break;
                case 21:
                    TutorialEnd();
                    counter++;
                    break;
                case 25:
                    TutorialY();
                    break;
                case 26:
                    TutorialEnd();
                    counter++;
                    break;
                case 30:
                    TutorialR();
                    break;
                case 31:
                    TutorialEnd();
                    counter++;
                    break;
                default:
                    break;

            }

        }

    }

    void ReadLang()
    {
        StreamReader reader = new StreamReader(Application.persistentDataPath+"/Lang/"+ MainMenu.language+".txt");
        tutorLog = reader.ReadToEnd();
        tutorsub = tutorLog.Split('\n');
        reader.Close();
    }
    
    
    void TutorialW()
    {
        TutorialText1.GetComponent<Text>().text = tutorsub[ReadStart];
        TutorialImage1.SetActive(true);
        TutorialText1.SetActive(true);
        
        if (Input.GetMouseButtonDown(0))
        {
            TutorialText1.SetActive(false);
            counter++;     
        }
        
    }
    void TutorialW2()
    {
        TutorialText2.GetComponent<Text>().text = tutorsub[ReadStart+1];
        Finger.SetInteger("tutor", 1);
        TutorialText1.SetActive(false);
        TutorialText2.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            TutorialImage1.SetActive(false);
            TutorialText2.SetActive(false);
            counter++;
        }
        
    }
    void TutorialMove()
    {
        TutorialText1.GetComponent<Text>().text = tutorsub[ReadStart+2];
        //Red_C.SetInteger("Red", 1);
        TutorialImage2.SetActive(true);
        TutorialText1.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            TutorialImage2.SetActive(false);
            TutorialText1.SetActive(false);
            counter++;
        }

    }

    void TutorialB()
    {
        TutorialText1.GetComponent<Text>().text = tutorsub[ReadStart+3];

        TutorialImage1.SetActive(true);
        TutorialText1.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {

            TutorialImage1.SetActive(false);
            TutorialText1.SetActive(false);
            counter++;

        }

    }
    void TutorialG()
    {
        TutorialText1.GetComponent<Text>().text = tutorsub[ReadStart+4];
        Finger.SetInteger("tutor", 1);
        TutorialImage1.SetActive(true);
        TutorialText1.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {

            TutorialImage1.SetActive(false);
            TutorialText1.SetActive(false);
            counter++;

        }
    }
    void TutorialS()
    {
        TutorialText1.GetComponent<Text>().text = tutorsub[ReadStart+5];
        Finger.SetInteger("tutor", 2);
        TutorialImage1.SetActive(true);
        TutorialText1.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            
            TutorialImage1.SetActive(false);
            TutorialText1.SetActive(false);
            counter++;
            
        }
    }
    
    void TutorialY() 
    {
        TutorialText1.GetComponent<Text>().text = tutorsub[ReadStart+6];
        Finger.SetInteger("tutor", 4);
        TutorialImage1.SetActive(true);
        TutorialText1.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {

            TutorialImage1.SetActive(false);
            TutorialText1.SetActive(false);
            counter++;

        }
    }
    void TutorialR()
    {
        TutorialText1.GetComponent<Text>().text = tutorsub[ReadStart+7];
        Finger.SetInteger("tutor", 2);
        TutorialImage1.SetActive(true);
        TutorialText1.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {

            TutorialImage1.SetActive(false);
            TutorialText1.SetActive(false);
            counter++;

        }
    }
    void TutorialEnd()
    {
        TutorialImage1.SetActive(false);
        TutorialImage2.SetActive(false);
        TutorialText1.SetActive(false);
        TutorialText2.SetActive(false);
    }
    
    
   
}
