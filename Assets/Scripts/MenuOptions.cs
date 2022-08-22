using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.IO;
using System.IO;

public class MenuOptions : MonoBehaviour
{
    bool adwatched = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (adwatched)
        {
            GameObject GetButton;
            GetButton = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(3).gameObject;
            GetButton.SetActive(false);
        }
        adwatched = false;
    }
    public void NextLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GetMove()
    {
        if (!adwatched)
        {
            Debug.Log("AdWaced");
            adwatched = true;
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
            Shape_Check.addmove = true;
        }
    }


}
