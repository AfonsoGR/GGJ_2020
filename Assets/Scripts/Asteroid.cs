using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = default;
    private int _dmg = default;
    private Rigidbody2D _rb = default;

    public int Dmg => _dmg;

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "SmallAsteroid")
        {
            _dmg = 10;
        }

        if (tag == "BigAsteroid")
        {
            _dmg = 30;
        }

        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        _rb.AddForce(new Vector2(_moveSpeed, _moveSpeed));
    }

    // TODO: MOVEMENT
}
