using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _moveDirection;

    private void Start()
    {
        _moveDirection = Vector3.forward;
        StartCoroutine(DestroyOnDelay());
    }
    private void Update()
    {
        transform.Translate(_moveDirection * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
        if(other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.AddExplosionForce(100, transform.position + new Vector3(0, -1, 1), 100);
    }

    private IEnumerator DestroyOnDelay()
    { 
        while(true)
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
            yield return null;
        }
    }
}
