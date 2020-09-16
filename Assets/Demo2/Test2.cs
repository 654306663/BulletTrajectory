using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bulletPrefab;
    [Range(0.05f, 0.5f)] [SerializeField] private float createBulletInterval = 0.1f;
    [Range(5, 50f)] [SerializeField] private float bulletSpeed = 30;
    [Range(0.4f, 5f)] [SerializeField] private float radian = 1;

    private float createBulletTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            createBulletTimer += Time.deltaTime;
            if (createBulletTimer >= createBulletInterval)
            {
                createBulletTimer = 0;
                float startAngle = Random.Range(0, 360);
                Bullet_Track2 bullet = CreateBullet(bulletSpeed, startAngle, radian);
                bullet.transform.position = player.transform.position;
                bullet.SetTarget(target);
            }
        }
    }

    private Bullet_Track2 CreateBullet(float _bulletSpeed, float _startAngle, float _radian)
    {
        GameObject o = GameObject.Instantiate(bulletPrefab);
        Bullet_Track2 bullet = o.AddComponent<Bullet_Track2>();
        bullet.speed = _bulletSpeed;
        bullet.startAngle = _startAngle;
        bullet.radian = _radian;
        return bullet;
    }
}
