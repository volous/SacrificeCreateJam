using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAOE : MonoBehaviour
{
    public Transform middleOfAOE;
    [SerializeField] private float speed = 5;
    [SerializeField] private float time = .5f;

    private void Start()
    {
        Destroy(gameObject, time);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerController.Immobilize();

                Vector3 dir = (-middleOfAOE.position + playerController.transform.position).normalized;

                playerController.GetComponent<Rigidbody2D>().velocity = dir * speed;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerController.Mobilize();
                playerController.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
    }

}
