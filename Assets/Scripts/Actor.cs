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
    private float m_launchSpeed;
    public float launchSpeed { get { return m_launchSpeed; } set { m_launchSpeed = value; } }

    public abstract void Launch();
    public abstract void Move();
}
