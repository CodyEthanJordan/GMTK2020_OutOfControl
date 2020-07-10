using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class RunnerGuy : MonoBehaviour
    {
        public float Speed = 1;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.AddForce(Vector2.right * Speed);
        }

        public void Jump(float strength)
        {
            rb.AddForce(Vector2.up * strength, ForceMode2D.Impulse);
        }


    }
}
