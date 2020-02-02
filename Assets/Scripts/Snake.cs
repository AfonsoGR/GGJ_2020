using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private const float _PARTS_OFFSET = .56f;

    [SerializeField] private byte _snakeLength = 8;
    [SerializeField] private float _partSpeed = 1.0f;
    [SerializeField] private Transform _head;

    [SerializeField] private GameObject _snakeBody = null;
    [SerializeField] private GameObject _snakeTail = null; 

    private GameObject _tail;

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

    void Update()
    {
        //UpdatePosition();
        UpdatePartRotation();
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
        _tail = Instantiate
            (_snakeTail, NextPartPosition, Quaternion.identity, transform);
    }

    private void UpdatePartRotation()
    {
        GameObject segment;
        Vector3 tempRot;
        Vector3 positionS;
        Vector3 targetS;
        Vector3 diff;
        for (int i = 0; i < _snakeCollection.Count; i++)
        {
            segment = _snakeCollection[i];
            positionS = _snakeCollection[i].transform.position;
            targetS = i == 0 ? _head.position : _snakeCollection[i - 1].transform.position;

            _snakeCollection[i].transform.rotation = Quaternion.LookRotation(Vector3.forward, (targetS - positionS).normalized);
            
            tempRot = _snakeCollection[i].transform.rotation.eulerAngles;
            tempRot.Set(tempRot.x, tempRot.y, tempRot.z + 90);

            _snakeCollection[i].transform.rotation = Quaternion.Euler(tempRot);
            diff = positionS - targetS;
            diff.Normalize();

            if (i == 0)
                segment.transform.position = targetS;
            else
                segment.transform.position = targetS + _PARTS_OFFSET * diff;
        }

        segment = _tail;
        positionS = _tail.transform.position;
        targetS = _snakeCollection[_snakeCollection.Count - 1].transform.position;

        _tail.transform.rotation = Quaternion.LookRotation(Vector3.forward, (targetS - positionS).normalized);
            
        tempRot = _tail.transform.rotation.eulerAngles;
        tempRot.Set(tempRot.x, tempRot.y, tempRot.z + 90);

        _tail.transform.rotation = Quaternion.Euler(tempRot);
        diff = positionS - targetS;
        diff.Normalize();

        segment.transform.position = targetS + _PARTS_OFFSET * diff;
    }
}
