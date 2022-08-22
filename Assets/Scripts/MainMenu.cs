using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.IO;
using System.IO;
using System;


public class MainMenu : MonoBehaviour
{
    static string Path,LangPath;
    string[] LogData,menu;
    string Log;
    public static string Level = "Level 1";
    public static string language = "ENG";
    public static bool MscToggle = true,Sounds=true;
    public Toggle Tutorial1,MusicT,SoundT;
    //public static bool change = false;
    Music BGMusic;
    
    
    public void MenuLang()
    {
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/CL.txt");
        language = reader.ReadToEnd().Split('-')[1];
        reader.Close();
        string path = Application.persistentDataPath + "/Lang/" + language + ".txt";
        if (File.Exists(path))
        {
            reader = new StreamReader(path);
            string menutext = reader.ReadToEnd();
            menu = menutext.Split('\n');
            reader.Close();
        }
        
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = menu[0];
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = menu[1];
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = menu[2];
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = menu[3];
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(8).transform.GetChild(1).GetComponent<Text>().text = menu[9];//Reset Pop-up Text
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(8).transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = menu[10];//Cancel Button
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(8).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = menu[8];//Reset Confirm

        

    }

    void CreateLangDirectory()
    {
        if (!Directory.Exists(Application.dataPath + "/Lang"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Lang");
        }

    }

    void CreateLangFiles()
    {
        
        LangPath = Application.persistentDataPath + "/Lang/ENG.txt";
        if (!File.Exists(LangPath) || menu[Tutorial.ReadStart]!= "Swipe the cube to change the shape.")
        {
            File.WriteAllText(LangPath, Language.LangENG);
        }
        //TUR
        LangPath = Application.persistentDataPath + "/Lang/TUR.txt";
        if (!File.Exists(LangPath) || menu[Tutorial.ReadStart] != "Şekli değiştirmek için küpü çevirin.")
        {
            File.WriteAllText(LangPath, Language.LangTUR);
        }
    }

    public static void CreateLog ()
    {
        Path = Application.persistentDataPath + "/CL.txt";
        File.WriteAllText(Path, Level + "-" + language +"-"+MscToggle+"-"+Sounds+"-"+Tutorial.tutorial);
    }
    public void ReadLog()
    {
        Path = Application.persistentDataPath + "/CL.txt";
        StreamReader reader = new StreamReader(Path);
        Log = reader.ReadToEnd();
        reader.Close();
        LogData = Log.Split('-');
        Level = LogData[0];
        language = LogData[1];
        MscToggle = Convert.ToBoolean(LogData[2]);
        Sounds = Convert.ToBoolean(LogData[3]);
        Tutorial.tutorial = Convert.ToBoolean(LogData[4]);
        
        
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(Level);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    

    public void Start()
    {

        
        
        
        Path = Application.persistentDataPath + "/CL.txt";
        if (!File.Exists(Path))
        {
            CreateLog();
        }
        ReadLog();
        
        if (File.Exists(Application.persistentDataPath + "/Lang/" + language + ".txt"))
        {
            MenuLang();
        }
        Tutorial1 = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(4).GetComponent<Toggle>();
        MusicT = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(1).GetComponent<Toggle>();
        SoundT = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(7).GetComponent<Toggle>();

        Tutorial1.isOn = Tutorial.tutorial;
        MusicT.isOn = MscToggle;
        SoundT.isOn = Sounds;


        CreateLangDirectory();
        if (Directory.Exists(Application.persistentDataPath + "/Lang"))
        {
            CreateLangFiles();
        }
        MenuLang();
    }

    public void ResetLevel()
    {
        
        Level = "Level 1";
        CreateLog();
        File.WriteAllText(Application.persistentDataPath + "/LevelStars.txt", "");
        
        
    }
    
    public void Toggle_Change(bool Value)
    {
        
        Tutorial.tutorial = Value;

    }
    public void MusicToggle(bool Msc)
    {
        BGMusic = GameObject.FindObjectOfType<Music>();
        if (!Msc)
        {
            BGMusic.volume = 0;
        }
        else if(Msc)
        {
            BGMusic.volume = 0.5f;
        }
        MscToggle = Msc;
        CreateLog();
        
    }

    public void SoundToggle(bool sound)
    {
        Sounds = sound;
        CreateLog();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        }
        
    }

}
