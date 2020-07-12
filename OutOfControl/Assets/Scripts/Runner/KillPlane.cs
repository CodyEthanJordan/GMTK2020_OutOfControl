using Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runner
{
    public class KillPlane : MonoBehaviour
    {
        [SerializeField]
        private GameplayManager gm;

        private void Start()
        {
            if(gm == null)
            {
                gm = GameObject.Find("GameplayManager").GetComponent<GameplayManager>();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Runner"))
            {
                gm.RestartLevel();
            }
        }
    }
}
