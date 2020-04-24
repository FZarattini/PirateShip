using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canInteract = false;
    public bool hasInteracted;


    public virtual void Interact()
    {
        //Debug.Log("Picking Up");
    }

    private void Update()
    {
        
    }

    public bool GetHasInteracted()
    {
        return this.hasInteracted;
    }

    public void SetHasInteracted(bool value)
    {
        this.hasInteracted = value;
    }
}
