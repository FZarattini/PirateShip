using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerController player;
    public Canvas inventoryCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            toggleInventory();
        }
    }

    private void toggleInventory()
    {
        if (!inventoryCanvas.isActiveAndEnabled)
        {
            inventoryCanvas.gameObject.SetActive(true);

            inventoryCanvas.GetComponent<InventoryUI>().UpdateUI();
        }
        else
        {
            inventoryCanvas.gameObject.SetActive(false);
        }

    }

}
