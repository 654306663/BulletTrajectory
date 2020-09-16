using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Track1 : MonoBehaviour
{
    private Transform target;
    public float speed = 30;    //飞行速度
    public float rotationAngle = 30;    //旋转角度

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        Track();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Track()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, angle, 0);
        transform.rotation = transform.rotation * Quaternion.Euler(0, rotationAngle, 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
