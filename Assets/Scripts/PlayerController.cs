using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    void Update()
    {
        Move();
    }

    public override void Launch()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
    }
}
