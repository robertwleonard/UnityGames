using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AiFollow : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = .05f;

    public Transform target;
    private bool m_FacingRight = true;
    private Rigidbody2D m_Rigidbody2D;


    private void Awake ()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if ( (target.position.x - transform.position.x) > 0 && !m_FacingRight)
            Flip();
        else if ( (target.position.x - transform.position.x) < 0 && m_FacingRight)
            Flip();

        if (Vector3.Distance (transform.position, target.position) > 1f
        &&  Vector3.Distance (transform.position, target.position) < 15f )
        {
            float m_DecideDirection = 1f; //Default to right

            if ( (target.position.x - transform.position.x) < 0 )
                m_DecideDirection = -1;

            m_Rigidbody2D.velocity = new Vector2(m_DecideDirection*m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}