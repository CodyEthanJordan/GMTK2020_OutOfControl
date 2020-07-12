using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class RandomColorAndRoatation : MonoBehaviour
    {
        private SpriteRenderer sr;

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            sr.color = UnityEngine.Random.ColorHSV();
            this.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
            this.transform.localScale = Vector3.one * UnityEngine.Random.Range(0.5f, 1);
        }
    }
}
