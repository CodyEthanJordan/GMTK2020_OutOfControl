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

        private void Start()
        {
            if(runner is null)
            {
                runner = GameObject.Find("Train").GetComponent<RunnerGuy>();
            }
        }

        private void OnDestroy()
        {
            runner.Jump(JumpStrength);   
        }
    }
}
