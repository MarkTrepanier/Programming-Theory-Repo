using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    [SerializeField]
    private Projectile pill;
    private GameObject player;
    [SerializeField]
    private float fireRate = 3f;
    private float countDown;

    private void Start()
    {
        countDown = fireRate;
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Move();
        Launch();
    }

    public override void Launch()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0)
        {
            Instantiate(pill,
                transform.position + transform.forward * 2, 
                transform.localRotation);
            countDown = fireRate;
        }
    }

    public override void Move()
    {
        Vector3 playerPos = player.transform.position.x > transform.position.x? Vector3.left:Vector3.right;
        transform.Translate( playerPos * Time.deltaTime * speed);
    }
}
