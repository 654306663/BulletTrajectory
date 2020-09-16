using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bulletPrefab;
    [Range(0.05f, 0.5f)] [SerializeField] private float createBulletInterval = 0.1f;
    [Range(5, 50f)] [SerializeField] private float bulletSpeed = 30;

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
                float _bulletAngle = Random.Range(-60f, +60f);
                Bullet_Track1 bullet = CreateBullet(bulletSpeed, _bulletAngle);
                bullet.transform.position = player.transform.position;
                bullet.SetTarget(target);
            }
        }
        if (Input.GetMouseButton(1))
        {
            createBulletTimer += Time.deltaTime;
            if (createBulletTimer >= createBulletInterval)
            {
                createBulletTimer = 0;
                int count = 10;
                float _bulletAngle = Random.Range(-60f, +60f);
                for (int i = 0; i < count; i++)
                {
                    Bullet_Track1 bullet = CreateBullet(bulletSpeed, _bulletAngle + i - count / 2);
                    bullet.transform.position = player.transform.position;
                    bullet.SetTarget(target);
                }
            }
        }
    }

    private Bullet_Track1 CreateBullet(float _bulletSpeed, float _bulletAngle)
    {
        GameObject o = GameObject.Instantiate(bulletPrefab);
        Bullet_Track1 bullet = o.AddComponent<Bullet_Track1>();
        bullet.speed = _bulletSpeed;
        bullet.rotationAngle = _bulletAngle;
        return bullet;
    }
}
