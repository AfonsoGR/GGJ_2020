using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _rotationSpeed = 1.0f;

    void Update()
    {
        CaptureRotation();
        ConstantMoveRight();
    }

    private void CaptureRotation()
    {
        Vector2 _inputs = new Vector2
            (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        float axis = _inputs.x + _inputs.y; 

        transform.Rotate(0.0f, 0.0f, axis * _rotationSpeed * Time.deltaTime);
    }

    private void ConstantMoveRight()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
    }
}
