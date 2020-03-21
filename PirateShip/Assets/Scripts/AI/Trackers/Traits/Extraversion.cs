using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extraversion : MonoBehaviour
{
    /* Relacionado a interação entre Player e NPCs - Frequência e rapidez */


    #region Singleton
    private static Extraversion _instance;
    private static Extraversion Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject op = new GameObject("Extraversion");
                op.AddComponent<Extraversion>();
            }
            return _instance;
        }
    }
    #endregion

    public delegate void OnNPCInteracted();
    public static event OnNPCInteracted onNPC;


    public int maxNPCs;
    [SerializeField] int interactedNPCs;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onNPC += IncrementNPC;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RegisterNPC()
    {
        onNPC();
    }

    void IncrementNPC()
    {
        interactedNPCs += 1;
    }

    public void ProcessInteractedNPCs()
    {
        GameController.CheckInteractions();

    }
}
