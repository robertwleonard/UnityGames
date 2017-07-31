using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class LaserController : MonoBehaviour
    {
        public float speed;
        public GameObject m_EnemyDeathEffects;
        public GameObject m_ImpactEffect;

        private Platformer2DUserControl m_Player;
        private Rigidbody2D m_GetRigidbody;

    	// Use this for initialization
    	void Start ()
        {
            m_GetRigidbody = GetComponent<Rigidbody2D>();
            m_Player = FindObjectOfType<Platformer2DUserControl>();

            if ( m_Player.transform.localScale.x < 0 )
                speed = -speed;
    	}
    	
    	// Update is called once per frame
    	void Update () {
            m_GetRigidbody.velocity = new Vector2(speed, m_GetRigidbody.velocity.y);
    	}

        void OnTriggerEnter2D(Collider2D other)
        {
            if ( other.tag == "Enemy" )
            {
                Instantiate(m_EnemyDeathEffects, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
                return;
            }

            if ( other.tag == "Player" || other.tag == "Collectable" || other.tag == "Laser" )
            {
                return;
            }

            Instantiate(m_ImpactEffect, other.transform.position, other.transform.rotation);
            Destroy(gameObject);

        }
    }
}