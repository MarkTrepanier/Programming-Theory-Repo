using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
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
        Vector3 playerPos = new Vector3(player.transform.position.x, 0, 0);
        Vector3 currentPos = new Vector3(transform.position.x, 0, 0);
        transform.Translate( (playerPos - currentPos).normalized * Time.deltaTime * speed);
    }
}
