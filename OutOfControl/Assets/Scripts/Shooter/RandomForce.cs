using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class RandomForce : MonoBehaviour
    {
        public float Power = 3;
        public float ForceTimer = 4;

        private float timer = 1;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = UnityEngine.Random.Range(ForceTimer / 2, 2 * ForceTimer);
                var randomForce = UnityEngine.Random.insideUnitCircle * Power;
                rb.AddForce(randomForce, ForceMode2D.Impulse);
            }
        }
    }
}
