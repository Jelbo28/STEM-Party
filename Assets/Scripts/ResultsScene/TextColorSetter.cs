using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextColorSetter : MonoBehaviour
{
    //[SerializeField] private Color[] textColors;
    //private Color thisColor;
    [SerializeField] private int colorAnimation;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //thisColor = GetComponent<MeshRenderer>().sharedMaterial.color;
        //for (int i = 0; i < textColors.Length; i++)
        //{
        //    if (textColors[i] == thisColor)
        //    {
        //        anim.SetInteger("ColorNum", i);
        //    }
        //}
        anim.SetInteger("ColorNum", colorAnimation);
    }
}
