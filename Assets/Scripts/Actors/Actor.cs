using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    public float speed { get { return m_speed; } set { m_speed = value; } }

    [SerializeField]
    private float m_health;
    public float health { get { return m_health; } set { m_health = value; } }

    [SerializeField]
    private float m_launchRate;
    public float launchRate { get { return m_launchRate; } set { m_launchRate = value; } }

    public abstract void Launch();
    public abstract void Move();

    public void TakeEffect(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }
}
