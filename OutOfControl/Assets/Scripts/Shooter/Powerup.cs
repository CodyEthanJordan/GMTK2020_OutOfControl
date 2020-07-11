using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class Powerup : MonoBehaviour
    {
        public float JumpStrength = 10;

        [SerializeField]
        private RunnerGuy runner;
        [SerializeField]
        private Spawner spawner;

        private void Start()
        {
            if(runner is null)
            {
                runner = GameObject.Find("Train").GetComponent<RunnerGuy>();
            }
            if(spawner is null)
            {
                spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            }
        }

        private void OnDestroy()
        {
            runner.Jump(JumpStrength);
            spawner.HasDied(this);
        }
    }
}
