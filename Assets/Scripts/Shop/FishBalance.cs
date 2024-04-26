using Constants;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class FishBalance : MonoBehaviour, IPlayerBalance
    {
        [SerializeField] private TextMeshProUGUI countText;
        private int count;

        private void Start()
        {
            count = PlayerPrefs.GetInt(PlayerPrefsConsts.FishBalance);
            SetText();
        }

        public void IncBalance(int inc)
        {
            count += inc;
            SetText();
        }

        public void DecrBalance(int decr)
        {
            count -= decr;
            SetText();
        }

        private void SetText()
        {
            countText.text = count.ToString();
        }
    }
}