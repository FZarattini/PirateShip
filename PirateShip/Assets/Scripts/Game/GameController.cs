using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerController player;
    public SpawnManager sm;
    public Canvas inventoryCanvas;
    public int spawnID;

    // Start is called before the first frame update
    void Awake()
    {

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

    public void SetSpawnID(int id)
    {
        spawnID = id;
    }

    private void SpawnPlayer()
    {
        player.transform.position = sm.spawnPoints[spawnID].position;
    }

    private void OnLevelWasLoaded(int level)
    {
        player = FindObjectOfType<PlayerController>();
        sm = FindObjectOfType<SpawnManager>();
        SpawnPlayer();
    }


}
