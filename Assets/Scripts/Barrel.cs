using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private GameObject barrelAOEPF;
    [SerializeField] private float flyTime = 1.5f;
    [SerializeField] private float flySpeed = 2;

    [SerializeField] private GameObject owner;


    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject != owner)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(barrelAOEPF, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Setup(Vector2 dir, GameObject pc)
    {
        GetComponent<Rigidbody2D>().velocity = dir * flySpeed;
        owner = pc;
        Invoke("Explode", flyTime);
    }
}
