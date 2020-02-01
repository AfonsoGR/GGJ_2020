using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private const float _PARTS_OFFSET = .56f;

    [SerializeField] private byte _snakeLength = 8;

    [SerializeField] private GameObject _snakeBody = null; 
    [SerializeField] private GameObject _snakeTail = null; 

    private List<GameObject> _snakeCollection;

    private Vector3 NextPartPosition
    {
        get
        {
            Vector3 newPartPos = transform.position;
            newPartPos.x -= _PARTS_OFFSET * _snakeCollection.Count;
            return newPartPos;
        }
    }

    private void Awake() 
    {
        _snakeCollection = new List<GameObject>();
        SpawnBodyParts();
    }

    private void SpawnBodyParts()
    {
        _snakeCollection.Add(
        Instantiate(_snakeBody, NextPartPosition, Quaternion.identity, transform));


        if (_snakeCollection.Count < _snakeLength)
            SpawnBodyParts();
        else 
            SpawnTail();
    }
    
    private void SpawnTail()
    {
        Instantiate(_snakeTail, NextPartPosition, Quaternion.identity, transform);
    }
}
