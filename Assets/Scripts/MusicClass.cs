using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicClass : MonoBehaviour
{
    
    public AudioSource Source1;
    Toggle Music;
    public static bool MusicMute;
    void Start()
    {
        Music = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(1).GetComponent<Toggle>();
        
        if (MusicMute)
        {
            Music.isOn = false;
        }
        
        Source1.volume = 0.5f;
        Source1.Play();
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

    

    void Update()
    {
        Source1.mute = MusicMute;
    }
}