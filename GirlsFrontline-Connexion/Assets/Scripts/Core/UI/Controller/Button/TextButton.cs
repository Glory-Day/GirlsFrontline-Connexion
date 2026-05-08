using GloryDay.Debug;
using TMPro;

namespace Core.UI.Controller.Button
{
    public abstract class TextButton : ButtonBase
    {
        #region COMPONENT FIELD

        private TMP_Text _text;

        #endregion

        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            _text = GetComponentInChildren<TMP_Text>();
        }

        #region PROPERTIES API

        public string Text { get => _text.text; set => _text.text = value; }

        #endregion
    }
}
