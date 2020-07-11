using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class Spawner : MonoBehaviour
    {
        public Transform[] SpawnPoints;
        public GameObject PowerupPrefab;

        public void HasDied(Powerup p)
        {
            Spawn();
        }

        public void Spawn()
        {
            var pos = SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Length - 1)].position;
            var go = Instantiate(PowerupPrefab, pos, Quaternion.identity);
            go.transform.SetParent(this.transform);
        }

    }
}
