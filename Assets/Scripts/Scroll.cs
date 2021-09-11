using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public Animation anim;


    public void ScrollIn()
    {
        anim.Play("Scroll");
    }

    public void ScrollOut()
    {
        anim.Play("ScrollOut");
    }
}
