using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Cubes : Cubes
{
    public int b = 0;
    public Animator Animat;
    public void OnMouseDown()
    {
        Start = Input.mousePosition;
       
    }
    private void OnMouseUp()
    {
        End = Input.mousePosition;
        GameObject[] gameObjs = GameObject.FindGameObjectsWithTag("Cubes");
        if (FindObjectOfType<Shape_Check>().clickable)
        {
            if (Start.x > End.x)
            {
                rotation++;
                if (MainMenu.Sounds)
                {
                    woosh.Play();
                }
                FindObjectOfType<Shape_Check>().Move_Counter--;
                foreach (GameObject item in gameObjs)
                {
                    if (item.transform.position.x < this.transform.position.x && item.transform.position.y == this.transform.position.y)
                    {
                        item.tag = "Change+";
                    }
                }
            }
            else if (Start.x < End.x)
            {
                rotation--;
                if (MainMenu.Sounds)
                {
                    woosh.Play();
                }
                FindObjectOfType<Shape_Check>().Move_Counter--;
                foreach (GameObject item in gameObjs)
                {
                    if (item.transform.position.x < this.transform.position.x && item.transform.position.y == this.transform.position.y)
                    {
                        item.tag = "Change-";
                    }
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
        if (rotation > 4)
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


