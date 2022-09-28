using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Au
{
    public class I18n : MonoBehaviour
    {
        private static Log log = Log.GetLogger<I18n>();

        [Tooltip("Language ID")]
        public int languageId;

        private void Start()
        {
            SetText(GetText());
        }

        private string GetText()
        {
            if (App.i18n == null)
            {
                return languageId.ToString();
            }
            return App.i18n?.Invoke(languageId);
        }

        private void SetText(string value)
        {
            var uiText = GetComponent<TMP_Text>();
            if (uiText != null)
            {
                uiText.text = value;
                return;
            }

            log.Error($"Cannot find TMPro_Text on the game object {gameObject.name}");
        }
    }
}
