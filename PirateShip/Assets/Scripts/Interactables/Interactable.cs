using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public bool canInteract = false;
    private bool hasInteracted = false;


    public virtual void Interact()
    {
        Debug.Log("Picking Up");
    }

    private void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
