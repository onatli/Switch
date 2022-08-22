using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Unity.IO;

public class LevelMenu : MonoBehaviour
{
    
    public static int[] LevelStars = new int [40];
    public static string [] LevelText;
    string[] LangSub;
    string PathLevel,URL;
    public string LevelRead()
    {
        PathLevel = Application.persistentDataPath + "/LevelStars.txt";
        StreamReader reader = new StreamReader(PathLevel);
        string a = reader.ReadToEnd();
        reader.Close();
        return a;
    }
    void Start()
    {
        
        ReadLangFile();
        LevelText = LevelRead().Split('\n');
        

        for (int i = 0; i < LevelText.Length-1; i++)
        {
            if (GameObject.Find("Level 21") != null && i<20)
            {
                i = 20;
            }
            if (LevelText[i] == "1")
            {
                GameObject.Find("Level " + (i + 1)).transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Level " + (i + 1)).GetComponent<Button>().interactable = true;
                GameObject.Find("Level " + (i + 2)).GetComponent<Button>().interactable = true;

            }
            else if (LevelText[i] == "2")
            {
                GameObject.Find("Level " + (i + 1)).transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Level " + (i + 1)).transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("Level " + (i + 1)).GetComponent<Button>().interactable = true;
                GameObject.Find("Level " + (i + 2)).GetComponent<Button>().interactable = true;
            }
            else if (LevelText[i] == "3")
            {
                GameObject.Find("Level " + (i + 1)).transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Level " + (i + 1)).transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("Level " + (i + 1)).transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("Level " + (i + 1)).GetComponent<Button>().interactable = true;
                GameObject.Find("Level " + (i + 2)).GetComponent<Button>().interactable = true;
            }
            
        }
        
    }

    void ReadLangFile()
    {
        
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/Lang/" + MainMenu.language + ".txt");
        
        LangSub = reader.ReadToEnd().Split('\n');
        GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>().text = LangSub[1];
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = LangSub[4];
        GameObject.Find("Canvas").transform.GetChild(8).transform.GetChild(0).GetComponent<Text>().text = LangSub[4];
        GameObject.Find("Canvas").transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = LangSub[17]+" 2\n"+LangSub[19];
        GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = LangSub[17] + " 1\n" + LangSub[18];
        GameObject.Find("Canvas").transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = LangSub[17] + " 3\n" + LangSub[21];
        GameObject.Find("Canvas").transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = LangSub[17] + " 4\n" + LangSub[21];
        GameObject.Find("Canvas").transform.GetChild(9).transform.GetChild(0).GetComponent<Text>().text = LangSub[22];
    }
    public void LevelSelect(string Level)
    {
        Level = this.name;
        SceneManager.LoadScene(Level);
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void patreon()
    {
        URL = "http://poxangames.com";
        Application.OpenURL(URL);
    }
    
}
