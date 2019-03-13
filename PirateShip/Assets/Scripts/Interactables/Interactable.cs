using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canInteract = false;
    private bool hasInteracted = false;


    public virtual void Interact()
    {
        Debug.Log("Picking Up");
    }

    private void Update()
    {
        
    }
}
