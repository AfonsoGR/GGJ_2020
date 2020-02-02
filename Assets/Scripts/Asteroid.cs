using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = default;
    private int _dmg = default;

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
    }

    // TODO: MOVEMENT
}
