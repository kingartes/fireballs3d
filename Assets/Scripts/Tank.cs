using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Bullet[] _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _recoilDistance;


    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(GetRandomBullet(), _shootPoint.position, Quaternion.identity);
                transform.DOMoveZ(transform.position.z - _recoilDistance, _shootDelay/2, false).SetLoops(2, LoopType.Yoyo);
                yield return new WaitForSeconds(_shootDelay);
            }
            yield return null;
        }
    }

    private Bullet GetRandomBullet()
    {
        return _bulletPrefab[Random.Range(0, _bulletPrefab.Length)];
    }
}
