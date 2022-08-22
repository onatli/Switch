using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class W_Cubes : Cubes
{
    
    public int w = 0;
    public Animator Animat;
    
    public void OnMouseDown()
    {
        Start = Input.mousePosition;
        
        
    }
    private void OnMouseUp()
    {
        End = Input.mousePosition;
        if (FindObjectOfType<Shape_Check>().clickable)
        {
            if (Start.x > End.x)
            {
                rotation++;
                FindObjectOfType<Shape_Check>().Move_Counter--;
                if (MainMenu.Sounds)
                {
                    woosh.Play();
                }
                
            }
            else if (Start.x < End.x)
            {
                rotation--;
                FindObjectOfType<Shape_Check>().Move_Counter--;
                if (MainMenu.Sounds)
                {
                    woosh.Play();
                }
            }
        }
    }

    public void Update()
    {
        
        if (tag == "Change+")
        {
            rotation++;
            tag = "Cubes";
        }
        else if (tag == "Change-")
        {
            rotation--;
            tag = "Cubes";
        }
        if (rotation > 4 )
        {
            rotation = 1;
        }
        else if (rotation < 1)
        {
            rotation = 4;
        }
        Animat.SetInteger("Rotation", rotation);


    }
    
}


