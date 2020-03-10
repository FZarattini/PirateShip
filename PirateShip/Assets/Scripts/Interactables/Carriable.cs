using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriable : MonoBehaviour
{
    public Transform player;
    [SerializeField]private bool canEquip = false;
    [SerializeField] private bool equipped = false;
    public Vector3 offset;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(canEquip && Input.GetKeyDown(KeyCode.E))
        {
            Equip();
        }
    }

    public void Equip()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameObject.transform.parent = player;
        transform.position = player.position + offset;
    }

    public void Unequip()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void SetCanEquip(bool value)
    {
        this.canEquip = value;
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }
}
