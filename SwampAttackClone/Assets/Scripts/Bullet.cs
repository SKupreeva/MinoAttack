using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private int _damage;

    [SerializeField] 
    private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if(collision.gameObject.TryGetComponent(out Bound bound))
        {
            Destroy(gameObject);
        }
    }
}
