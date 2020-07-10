using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class RunAroundLikeAnIdiot : MonoBehaviour
    {
        public float Speed = 10;
        public float JumpPower = 10;
        public float JumpTime = 3;
        public float TurnaroundTime = 3;
        public int Direction = 1;

        private float jumpTimer = 0;
        private float turnTimer;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(Speed * Direction, rb.velocity.y);

            jumpTimer -= Time.fixedDeltaTime;
            if(jumpTimer <= 0)
            {
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                jumpTimer = UnityEngine.Random.Range(JumpTime / 2, 2 * JumpTime);
            }

            turnTimer -= Time.fixedDeltaTime;
            if(turnTimer <= 0)
            {
                Direction *= -1;
                turnTimer = TurnaroundTime;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(UnityEngine.Random.Range(0, 1.0f) <= 0.5f)
            {
                Direction *= -1;
            }
        }


    }
}
