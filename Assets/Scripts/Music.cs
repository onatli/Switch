using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public static AudioSource Source1;
    public static bool MusicT = true;
    public float volume = 0.5f;
    float oldvolume;
    
    void Awake()
    {
        Source1 = GameObject.Find("Music").GetComponent<AudioSource>();
        oldvolume = volume;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(objs[1]);
        }
        
        DontDestroyOnLoad(this.gameObject);
        
    }
    private void Update()
    {
        if (volume != oldvolume)
        {
            Source1.volume = volume;
            oldvolume = volume;
        }
        
    }






}
