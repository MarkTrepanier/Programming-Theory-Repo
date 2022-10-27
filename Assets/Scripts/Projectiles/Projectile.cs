using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 50f;
    public float speed { get { return m_speed; } set { m_speed = value; } }

    [SerializeField]
    private float m_damage;
    public float damage { get { return m_damage; } set { m_damage = value; } }

    [SerializeField]
    private float m_effectTime =3f;
    public float effectTime { get { return m_effectTime; } set { m_effectTime = value; } }


    public virtual void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);    
    }

    public virtual void DealDamage(Actor actor)
    {
        actor.health -= m_damage;
    }

    public abstract IEnumerator CauseEffect(Actor actor);

    protected virtual void Expire()
    {
        if (Mathf.Abs(transform.position.z) > 6)
            Destroy(gameObject);
    }
}
