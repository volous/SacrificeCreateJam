using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Countdown : MonoBehaviour
{
    private Label text;
    [SerializeField] private float timer = 4;
    [SerializeField] private bool beingDestroyed;
    
    private void Start()
    {
        text = GetComponent<UIDocument>().rootVisualElement.Q<Label>("Countdown");
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        text.text = ""+(int)timer;
        if (timer<1)
        {
            text.text = "GO";
            if (!beingDestroyed)
            {
                beingDestroyed = true;
                
                Invoke("Remove",1);
            }
        }
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
