using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Utiliza o pacote externo PixelCrushers
using PixelCrushers.DialogueSystem;

/* Representa o traço Extraversion de personalidade no modelo Big 5 */
public class Extraversion : Trait
{

    // Singleton garante que uma instância da classe esteja presente a cada momento
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

    // Evento onNPC - Disparado sempre que o jogador interage com algum NPC
    public delegate void OnNPCInteracted();
    public static event OnNPCInteracted onNPC;

    // Acesso a classe PlayerController
    public PlayerController player;

    // Quantidade máxima de NPCs na cena, informada pelo inspector do Unity
    public int maxNPCs;

    [SerializeField] int interactedNPCs = 0;

    // Awake é chamada assim que todos os objetos são inicializados
    protected override void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        // Assina o método IncrementNPC ao evento onNPC - IncrementNPC será chamado toda vez que o evento for disparado
        onNPC += IncrementNPC;
    }

    /* Registra NPCs ao ocorrer a interação - Dispara o evento onNPC */
    public static void RegisterNPC()
    {
        onNPC();
    }

    /* Executado toda vez que o evento onNPC é executado - Incrementa a quantidade de NPCs interagidos em 1 */
    void IncrementNPC()
    {
        interactedNPCs += 1;
    }

    /// <summary>
    /// Calculates the Extraversion Personality Trait in the Big 5 Model
    /// </summary>
    /// <param name="trait"></param>
    /// <param name="reversedTrait"></param>
    /// <returns> The normalized score for the Extraversion personality trait </returns>
    public override float CalculateTrait(string trait, string reversedTrait)
    {
        // The Extraversion score is based on the amount of interacted NPCs in realation to the total NPCs in scene
        float npcInteractionRate = interactedNPCs / maxNPCs;

        if (npcInteractionRate < 0.2)
        {
            assignedValue = 1;
        }
        else if (npcInteractionRate > 0.2 && npcInteractionRate < 0.4)
        {
            assignedValue = 2;
        }
        else if (npcInteractionRate > 0.4 && npcInteractionRate < 0.6)
        {
            assignedValue = 3;
        }
        else if (npcInteractionRate > 0.6 && npcInteractionRate < 0.8)
        {
            assignedValue = 4;
        }
        else
        {
            assignedValue = 5;
        }

        return base.CalculateTrait(trait, reversedTrait);
    }
}
