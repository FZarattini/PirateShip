using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class GameController : MonoBehaviour
{

    public float agreeablenessWeight;
    public float conscientiousnessWeight;

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

    private static Scene scene;
    private LoadSceneMode mode;

    public PlayerController player;
    public PlayerMovement playerMovement;

    //public SpawnManager sm;
    public Canvas inventoryCanvas;
    public Canvas pauseMenuCanvas;
    //public int spawnID;

    public List<NPCController> npcList;
    public List<Quest> questList;

    private PersonalityDisplay personalityCanvas;

    public delegate void OnPersonalityUpdated();
    public static event OnPersonalityUpdated onPersonalityUpdated;

    private void Start()
    {
        onPersonalityUpdated += InitializeNPCs;
        onPersonalityUpdated += InitializeNPCEmpathyDialogue;
        personalityCanvas = GameObject.Find("PersonalityCanvas").GetComponent<PersonalityDisplay>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerMovement = player.gameObject.GetComponent<PlayerMovement>();
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePauseMenu();
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
            if (n.hasEmpathy == false)
            {
                n.empathy.CalculateBaseEmpathy(agreeablenessWeight, conscientiousnessWeight, player.personality, n.personality);
                n.hasEmpathy = true;
                Debug.Log("NPC: " + n.gameObject.name + " Empatia: " + n.empathy.empathy);
            }
        }
    }

    public void InitializeNPCEmpathyDialogue()
    {
        foreach (NPCController n in npcList)
        {
            DialogueLua.SetVariable(n.gameObject.name + "Empathy", n.empathy.empathy);
            n.empathy.CalculateBaseEmpathy(agreeablenessWeight, conscientiousnessWeight, player.personality, n.personality);
            n.hasEmpathy = true;
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

    public void togglePauseMenu()
    {
        if (!pauseMenuCanvas.isActiveAndEnabled && !PixelCrushers.DialogueSystem.DialogueManager.IsConversationActive)
        {
            pauseMenuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnLevelWasLoaded(int level)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        ClearNPCs();
        ClearQuests();
        LoadNPCs();
        LoadQuests();
    }

    public void OnIncreaseConscientiousness(float value)
    {
        player.personality.UpdatePersonality(1, value);
        onPersonalityUpdated();
    }

    public void OnDecreaseConscientiousness(float value)
    {
        player.personality.UpdatePersonality(1, -value);
        onPersonalityUpdated();
    }

    public void OnIncreaseAgreeableness(float value)
    {
        player.personality.UpdatePersonality(3, value);
        onPersonalityUpdated();
    }

    public void OnDecreaseAgreeableness(float value)
    {
        player.personality.UpdatePersonality(3, -value);
        onPersonalityUpdated();
    }

    public void TogglePersonalityDisplay()
    {
        if (personalityCanvas.display == true)
        {
            personalityCanvas.display = false;
        }
        else
        {        
            personalityCanvas.display = true;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneWasLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneWasLoaded;
    }

    private void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        personalityCanvas = GameObject.Find("PersonalityCanvas").GetComponent<PersonalityDisplay>();
    }

}
