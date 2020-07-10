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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var hp = collision.gameObject.GetComponent<HitPoints>();
            if(hp != null)
            {
                hp.TakeDamage(Damage);
            }

            Destroy(this.gameObject);
        }
    }
}
