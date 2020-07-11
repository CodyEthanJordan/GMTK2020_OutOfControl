using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class AnimateText : MonoBehaviour
    {
        public int Steps = 10;

        private TextMeshProUGUI text;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            //ShowText("You've met with a terrible fate haven't you");
        }

        public void ShowText(string message)
        {
            StartCoroutine(FadeIn(message));
        }

        IEnumerator FadeIn(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    string alphaTag = "<alpha=#" + Mathf.RoundToInt(255 * j / ((float)Steps) + 1).ToString("X2") + ">";
                    text.text = message.Substring(0, i) + "<voffset=" + (1.0 - j/((float)Steps)) + "em>"
                        + alphaTag + message[i] + "</voffset>";
                    yield return new WaitForSeconds(0.01f);
                }
            }

            text.text = message;
        }

    }
}
