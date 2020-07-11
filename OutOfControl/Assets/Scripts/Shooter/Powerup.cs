using Assets.Scripts.Runner;
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
        public PowerupType Type;
        public float JumpStrength = 10;


        [SerializeField]
        private RunnerGuy runner;
        [SerializeField]
        private Spawner spawner;

        private void Start()
        {
            if(runner is null)
            {
                runner = GameObject.Find("Runner").GetComponent<RunnerGuy>();
            }
            if(spawner is null)
            {
                spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            }
        }

        private void OnDestroy()
        {
            runner.ActivatePowerup(this.Type, this);
            spawner.HasDied(this);
        }

        public enum PowerupType
        {
            Jump,
            Antigrav
        }
    }
}
