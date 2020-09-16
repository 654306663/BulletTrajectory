using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Track2 : MonoBehaviour
{
    private Transform target;
    public float speed = 30;    //飞行速度
    public float startAngle = 30;   //初始角度
    public float radian = 1;    //弧度

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, startAngle, 0);
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
        transform.forward = Vector3.Slerp(transform.forward, target.position - transform.position, radian / Vector3.Distance(transform.position, target.position));
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
