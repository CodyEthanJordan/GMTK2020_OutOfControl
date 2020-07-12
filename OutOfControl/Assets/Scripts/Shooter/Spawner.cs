using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Shooter.Powerup;

namespace Assets.Scripts.Shooter
{
    public class Spawner : MonoBehaviour
    {
        public List<Transform> SpawnPoint = new List<Transform>();
        public Powerup[] Powerups;

        private void Start()
        {
            foreach (Transform child in this.transform)
            {
                SpawnPoint.Add(child);
            }
        }

        public void HasDied(Powerup dead)
        {
            Spawn(Powerups.First(p => p.Type == dead.Type).gameObject);
        }

        public void Spawn(PowerupType type)
        {
            Spawn(Powerups.First(p => p.Type == type).gameObject);
        }

        public void Spawn(GameObject prefab)
        {
            var pos = SpawnPoint[UnityEngine.Random.Range(0, SpawnPoint.Count - 1)].position;
            var go = Instantiate(prefab, pos, Quaternion.identity);
            go.transform.SetParent(this.transform);
            var randomForce = UnityEngine.Random.insideUnitCircle * 3;
            go.GetComponent<Rigidbody2D>().AddForce(randomForce, ForceMode2D.Impulse);
        }

    }
}
