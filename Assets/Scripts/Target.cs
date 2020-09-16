using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10;
    private void Update()
    {
        if (transform.position.x > 10)
            moveSpeed = -Mathf.Abs(moveSpeed);
        if (transform.position.x < -10)
            moveSpeed = Mathf.Abs(moveSpeed);

        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }
}