using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    
    Animator anim;
    bool open;

    void Start()
    {
        anim = GameObject.Find("Door").GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!open) anim.SetTrigger("Open");
        else anim.SetTrigger("Close");
        open = !open;
    }


}
