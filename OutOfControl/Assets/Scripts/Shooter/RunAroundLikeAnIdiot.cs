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
        public float JumpTimer = 3;
        public int Direction = 1;

        private float timer = 0;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(Speed * Direction, rb.velocity.y);

            timer -= Time.fixedDeltaTime;
            if(timer <= 0)
            {
                rb.AddForce(Vector2.up * JumpPower);
                timer = UnityEngine.Random.Range(JumpTimer / 2, 2 * JumpTimer);
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
