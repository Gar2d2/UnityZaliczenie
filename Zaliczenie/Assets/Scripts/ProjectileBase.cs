using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : UsingOnUpdateBase
{
    // Start is called before the first frame update
    private ProjectileMovementComponent m_projectileMovementComponent;
    private Rigidbody2D m_rigidbody;
    [SerializeField]
    float m_maxVelocity = 10f;
    GameObject m_owner;
    public void FireAtDirection(Vector2 direction, float velocity, GameObject owner)
    {
        m_owner = owner;
        direction.Normalize();
        m_rigidbody = GetComponent<Rigidbody2D>(); 
        m_projectileMovementComponent = GetComponent<ProjectileMovementComponent>();

        m_projectileMovementComponent.SetupComponent(m_rigidbody, owner, 1f,0.1f);
        m_projectileMovementComponent.FireAtDirection(direction, Mathf.Clamp(velocity, 0f, m_maxVelocity));
    }
}