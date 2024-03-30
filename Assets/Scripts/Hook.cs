using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private float flyTime = 1.5f;
    [SerializeField] private float flySpeed = 2;

    [SerializeField] private GameObject owner;

    [SerializeField] private float hookTime = 0.5f;
    private float hookTimer = 0f;

    private Vector3 hitPos;
    private Vector3 endPos;

    PlayerController playerHit;
    bool hasHitPlayer;

    float flyTimer = 0;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
        print(flySpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.gameObject != owner)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerHit = playerController;
                playerController.Immobilize();
                playerController.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                hitPos = playerController.transform.position;
                playerController.GetComponent<Collider2D>().enabled = false;
                hasHitPlayer = true;
                //HookPlayer();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!hasHitPlayer)
        {
            flyTimer += Time.fixedDeltaTime;
            if (flyTimer >= flyTime)
            {
                Destroy(gameObject);
            }
            return;
        }

        hookTimer += Time.fixedDeltaTime;
        float t = hookTimer / hookTime;
        endPos = owner.transform.position + new Vector3(-1, 0, 0);

        transform.position = Vector3.Lerp(hitPos, endPos, t);
        playerHit.transform.position = Vector3.Lerp(hitPos, endPos, t);

        if (t>= 1)
        {
            playerHit.Mobilize();
            playerHit.GetComponent<Collider2D>().enabled = true;
            Destroy(gameObject);
        }
    }

    public void HookPlayer()
    {


        //Destroy(gameObject);
    }



    public void Setup(Vector2 dir, GameObject pc)
    {
        GetComponent<Rigidbody2D>().velocity = dir * flySpeed;
        owner = pc;
    }
}
