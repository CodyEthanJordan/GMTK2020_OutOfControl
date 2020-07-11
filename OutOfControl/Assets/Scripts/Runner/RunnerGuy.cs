using Assets.Scripts.Shooter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Shooter.Powerup;

namespace Assets.Scripts.Runner
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
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }

        public void Jump(float strength)
        {
            rb.AddForce(Vector2.up * strength, ForceMode2D.Impulse);
        }

        public void ActivatePowerup(PowerupType type, Powerup power)
        {
            switch (type)
            {
                case PowerupType.Jump:
                    Jump(power.Strength * rb.gravityScale);
                    break;
                case PowerupType.Antigrav:
                    rb.gravityScale *= -1;
                    break;
                case PowerupType.Dash:
                    var pos2d = new Vector2(this.transform.position.x, this.transform.position.y);
                    rb.MovePosition(Vector2.right * power.Strength + pos2d);
                    break;
                default:
                    break;
            }
        }


    }
}
