using System.Diagnostics;
using UnityEngine;

public class Chestinteraction : MonoBehaviour, IInteractable
{
    Animator anim;
    static bool open;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        if (!open) anim.SetTrigger("Open");
        else anim.SetTrigger("Close");
        open = !open;
    }
}
