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
    public Transform playerParent;
    /////////////////////////////////////////////////

    private static Scene scene;

    public PlayerController player;
    public SpawnManager sm;
    public Canvas inventoryCanvas;
    public int spawnID;

    public List<NPCController> npcList;
    public List<Quest> questList;



    // Start is called before the first frame update
    void Awake()
    {
        //player = Instantiate(playerPrefab, playerParent).gameObject.GetComponent<PlayerController
        

    }

    private void Start()
    {
        LoadNPCs();
        LoadQuests();
        /*if(scene.name != "Tracker1" || scene.name != "Tracker2")
        {
            InitializeNPCs();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            toggleInventory();
        }

        if (DialogueLua.GetVariable("QuestAccepted").AsBool == true)
        {
            CheckAcceptedQuests();
            DialogueLua.SetVariable("QuestAccepted", "false");
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

    public void LoadQuests()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Quest"))
        {
            questList.Add(obj.GetComponent<Quest>());
        }
    }

    #endregion

    private void InitializeNPCs()
    {
        foreach (NPCController n in npcList)
        {
            n.empathy.CalculateBaseEmpathy(player.personality, n.personality);
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


#region TrackerCheckers

    public static void CheckInteractions()
    {
        //Instance.RegisterInteractions();
        foreach (NPCController n in Instance.npcList)
        {
            if (n.interacted == true)
            {
                if (scene.name == "Tracker1")
                    Extraversion.RegisterNPC();
            }
        }

    }

    public static void CheckAcceptedQuests()
    {
        if (scene.name == "Tracker1")
            Agreeableness.RegisterAcceptedQuest();
    }

    public static void CheckCompletedQuests()
    {
        foreach (Quest quest in Instance.questList)
        {
            if (quest.completed == true)
            {
                if (scene.name == "Tracker1")
                    Conscientiousness.RegisterCompletedQuest();
            }
        }
    }

    public static void CheckVisitedArea()
    {
        if (scene.name == "Tracker1")
            Openness.RegisterVisit();
    }

    #endregion

}
