using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyPart : MonoBehaviour
{
    private Snake _snake;

    private void Awake() 
    {
        _snake = GetComponentInParent<Snake>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
