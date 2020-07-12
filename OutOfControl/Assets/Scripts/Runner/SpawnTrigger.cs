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
    public class SpawnTrigger : MonoBehaviour
    {
        public PowerupType Type;

        [SerializeField]
        private Spawner spawner;

        private void Start()
        {
            if(spawner == null)
            {
                spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Runner"))
            {
                spawner.Spawn(Type);
            }
        }

        private void OnDrawGizmos()
        {
            var prevColor = Gizmos.color;
            var col = GetComponent<BoxCollider2D>();
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(this.transform.position,
                new Vector3(col.size.x, col.size.y, 1));
            Gizmos.color = prevColor;
        }
    }
}
