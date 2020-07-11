using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class EndLevel : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Runner"))
            {
                GameplayManager.instance.NextLevel();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 10, 1));
        }
    }
}
