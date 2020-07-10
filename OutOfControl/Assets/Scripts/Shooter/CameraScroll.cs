using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class CameraScroll : MonoBehaviour
    {
        public float Speed = 5;

        private void Update()
        {
            this.transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
        }
    }
}
