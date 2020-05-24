using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class GameController : MonoBehaviour
{

    #region Singleton
    private static GameController _instance;
    private static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject op = new GameObject("GameController");
                op.AddComponent<GameController>();
            }
            return _instance;
        }
    }
    #endregion

    /////////////////////////////////////////////////
    ///On game start - Implement later
    public GameObject playerPrefab;
    /////////////////////////////////////////////////

    private static Scene scene;
    private LoadSceneMode mode;

    public PlayerController player;
    //public SpawnManager sm;
    public Canvas inventoryCanvas;
    //public int spawnID;

    public List<NPCController> npcList;
    public List<Quest> questList;

    public float sympMinDiff;
    public float compMinDiff;
    public float neutralMinDiff;
    public float uncompMinDiff;
    public float unsympMinDiff;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        LoadNPCs();
        LoadQuests();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            toggleInventory();
        }

    }

    public void GetScene()
    {
        scene = SceneManager.GetActiveScene();
    }

    #region Loaders

    public void LoadNPCs()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("NPC"))
        {           
            npcList.Add(obj.GetComponent<NPCController>());
        }
    }

    public void ClearNPCs()
    {
        npcList.Clear();
    }

    public void LoadQuests()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Quest"))
        {
            questList.Add(obj.GetComponent<Quest>());
        }
    }

    public void ClearQuests()
    {
        questList.Clear();
    }

    #endregion

    public void InitializeNPCs()
    {
        foreach (NPCController n in npcList)
        {            
            if(n.hasEmpathy == false)
            {
                n.empathy.CalculateBaseEmpathy(player.personality, n.personality);
                n.hasEmpathy = true;
                Debug.Log("NPC: " + n.gameObject.name + " Empatia: " + n.empathy.empathy);
            }
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

    private void OnEnable()
    {
        
    }

    private void OnLevelWasLoaded(int level)
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        ClearNPCs();
        ClearQuests();
        LoadNPCs();
        LoadQuests();
    }
}
