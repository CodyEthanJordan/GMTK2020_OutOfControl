using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utility
{
    public class Popup : MonoBehaviour
    {
        public Text PopupText;

        public void Die()
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
