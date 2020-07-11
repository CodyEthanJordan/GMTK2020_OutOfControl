using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class DamageOnHit : MonoBehaviour
    {
        public int Damage = 1;
        public bool CanHitPlayer = false;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var hp = collision.gameObject.GetComponent<HitPoints>();
            if (hp != null)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    if (CanHitPlayer)
                    {
                        hp.TakeDamage(Damage);
                    }
                }
                else
                {
                    hp.TakeDamage(Damage);
                }
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                if (CanHitPlayer)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
