using Assets.Scripts.Runner;
using Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class Powerup : MonoBehaviour
    {
        public PowerupType Type;
        public float Strength = 10;

        public GameObject PopupPrefab;
        public GameObject SplatPrefab;

        [SerializeField]
        private RunnerGuy runner;
        [SerializeField]
        private Spawner spawner;

        private void Start()
        {
            if(runner == null)
            {
                runner = GameObject.Find("Runner").GetComponent<RunnerGuy>();
            }
            if(spawner == null)
            {
                spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            }
        }

        public void Die()
        {
            var popup = Instantiate(PopupPrefab, this.transform.position, Quaternion.identity);
            popup.GetComponent<Popup>().PopupText.text = Type.ToString();
            runner.ActivatePowerup(this.Type, this);
            spawner.HasDied(this);
            Instantiate(SplatPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        public enum PowerupType
        {
            Jump,
            Antigrav,
            Dash,
        }
    }
}
