using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownerPill : Projectile
{

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Actor actor = collision.gameObject.GetComponent<Actor>();
        if (actor != null)
        {
            actor.health -= damage;
            actor.TakeEffect(CauseEffect(actor));
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Expire();
        Move();
    }

    public override IEnumerator CauseEffect(Actor actor)
    {
        actor.speed /= 2;
        yield return new WaitForSeconds(effectTime);
        actor.speed *= 2;
    }
}
