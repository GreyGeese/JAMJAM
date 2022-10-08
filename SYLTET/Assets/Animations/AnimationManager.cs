using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    private Animator anim;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }


    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void SetBoolTrue(string boolean)
    {
        anim.SetBool(boolean, true);
    }

    public void SetBoolFalse(string boolean)
    {
        anim.SetBool(boolean, false);
    }


}
