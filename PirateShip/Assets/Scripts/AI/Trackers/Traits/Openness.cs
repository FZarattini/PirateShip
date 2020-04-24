using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Utiliza o pacote externo PixelCrushers
using PixelCrushers.DialogueSystem;


// Representa o traço Openness de personalidade dentro da modelagem Big 5
public class Openness : MonoBehaviour
{

    //Singleton garante que uma instância da classe esteja presente a cada momento
    #region Singleton
    private static Openness _instance;
    private static Openness Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject op = new GameObject("Openness");
                op.AddComponent<Openness>();
            }
            return _instance;
        }
    }
    #endregion

    // Evento onVisit - Disparado sempre que o jogador visitar uma área nova do mapa
    public delegate void OnAreaVisited();
    public static event OnAreaVisited onVisit;

    public PlayerController player;
    public Inventory inventory;

    // Quantidade máxima de áreas - Setada na interface do Unity
    public int maxAreas;

    [SerializeField]int visitedAreas = 0;
    
    public float finalValue;

    public float assignedValue;
    public float assignedReverseValue;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Assina o método IncrementArea ao evento onVisit (IncrementArea chamado sempre que onVisit é disparado)
        onVisit += IncrementArea;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Registra a visita de uma nova área - Dispara o evento onVisit
    public static void RegisterVisit()
    {
        onVisit();
    }

    // Incrementa a quantidade de áreas visitadas em 1
    void IncrementArea()
    {
        visitedAreas += 1;
    }

    // Calcula e retorna a razão de áreas visitadas pelo jogador em relação a quantidade máxima de áreas
    public float ProcessVisitedAreas()
    {
        return (visitedAreas) / maxAreas;
    }

    // Calcula e retorna o valor normalizado relativo ao traço de personalidade Openness
    public float AssignOpenness()
    {
        //Recupera a pontuação e a pontuação reversa
        float assignedValue = DialogueLua.GetVariable("OpennessValue").AsFloat;
        float assignedReverseValue = 6 - DialogueLua.GetVariable("OpennessReversedValue").AsFloat;
        
        //Média entre a pontuação e a pontuação reversa
        float mean = (assignedValue + assignedReverseValue) / 2.0f;
        //Normaliza o valor
        float normalizedValue = (mean - 1) / 4.0f;

        return normalizedValue;
        //player.personality.personality[0] = normalizedValue;
    }
}
