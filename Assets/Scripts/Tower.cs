using UnityEngine;

public class Tower : MonoBehaviour
{
    int life = 100;
    private static Vector3 position;
    public static Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    private void Start()
    {
        Position = transform.position;
    }

    private void Update()
    {
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}
