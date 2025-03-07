using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace MuseDashInputLine
{
    public class Main : MelonMod
    {
        private MelonPreferences_Category _category;
        private MelonPreferences_Entry<Color32> _color;
        private MelonPreferences_Entry<int> _width;
        private MelonPreferences_Entry<int> _lineOffset;
        
        public override void OnInitializeMelon()
        {
            _category = MelonPreferences.CreateCategory("MuseDashInputLine");
            _color = _category.CreateEntry("Color", new Color32(255, 0, 0, 255));
            _width = _category.CreateEntry("Width", 5);
            _lineOffset = _category.CreateEntry("Offset", 0);
            MelonPreferences.Save();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName != "GameMain")
            {
                return;
            }

            GameObject canvas = GameObject.Find("UI_2D");
            if (canvas == null)
            {
                return;
            }

            GameObject indicatorLine = new GameObject("Indicator");
            indicatorLine.transform.SetParent(canvas.transform, false);

            RectTransform rectTransform = indicatorLine.AddComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(_width.Value, 1500f); 
            rectTransform.anchoredPosition = new Vector2(-557f + _lineOffset.Value, 0f); 

            Image image = indicatorLine.AddComponent<Image>();
            image.color = _color.Value; 

            indicatorLine.SetActive(true);
        }
    }
}
