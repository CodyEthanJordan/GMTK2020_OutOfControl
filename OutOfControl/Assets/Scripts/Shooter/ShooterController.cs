using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class ShooterController : MonoBehaviour
    {
        public float Speed = 10;
        public float Jump = 10;
        public GameObject BulletPrefab;

        [SerializeField]
        private Transform groundCheck;

        private Rigidbody2D rb;

        private Vector2 move = Vector2.zero;
        private bool jump = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            HandleInput();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(move.x * Speed, rb.velocity.y);
            if(jump)
            {
                if(Grounded)
                {
                    rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                }

                jump = false;
            }
        }

        public bool Grounded
        {
            get
            {
                var hit = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
                if(hit is null || hit.Length == 0)
                {
                    return false;
                }

                return true;
            }
        }

        private void HandleInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            move = new Vector2(x, 0).normalized;

            if(Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }
}
