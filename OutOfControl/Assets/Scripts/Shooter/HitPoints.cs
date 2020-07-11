using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class HitPoints : MonoBehaviour
    {
        public int MaxHP = 1;
        public int HP = 1;

        private void Start()
        {
            HP = MaxHP;
        }

        public void TakeDamage(int amount)
        {
            HP -= amount;
            if(HP <= 0)
            {
                var power = GetComponent<Powerup>();
                if(power)
                {
                    power.Die();
                }
                Destroy(this.gameObject);
            }
        }
    }
}
