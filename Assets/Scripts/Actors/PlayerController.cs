using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    [SerializeField]
    private Projectile downerPill;
    void Update()
    {
        if (GameManager.Instance.isGameActive)
        {

            Move();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Launch();
            }
        }
    }

    public override void Launch()
    {
        Instantiate(downerPill, transform.position + Vector3.forward * 2, transform.rotation);
    }

    public override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -4, 4);
        transform.position = clampedPos;
    }
}
