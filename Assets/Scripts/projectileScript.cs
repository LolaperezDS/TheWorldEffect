using UnityEngine;

public class projectileScript : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    public void SetUp(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }

    void Update()
    {
        transform.position += direction.normalized * speed * TimeCustom.deltaTime;
    }
}
