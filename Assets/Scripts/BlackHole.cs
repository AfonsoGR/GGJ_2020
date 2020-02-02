using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BlackHole : MonoBehaviour
{
    [SerializeField] private float _GRAVITY_PULL = default;
    private float m_GravityRadius = default;
    private void Awake()
    {
        m_GravityRadius = GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Attract objects towards an area when they come within the bounds of a collider.
    /// This function is on the physics timer so it won't necessarily run every frame.
    /// </summary>
    /// <param name="other">Any object within reach of gravity's collider</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        print(other.tag);

        // if (other.attachedRigidbody)
        // {
            float gravityIntensity = Vector2.Distance(
                transform.position, other.transform.position) / m_GravityRadius;
            
            other.attachedRigidbody.AddForce(
                (transform.position - other.transform.position)
                * gravityIntensity 
                * other.attachedRigidbody.mass 
                * _GRAVITY_PULL 
                * Time.smoothDeltaTime);
            
            Debug.DrawRay(
                other.transform.position,
                transform.position - other.transform.position);
        //}
    }
}
