using UnityEngine;
using UnityEngine.UI;

namespace Prefabs
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Button addButton;
        [SerializeField] private Text price;
        [SerializeField] private Image unitImage;
        private int _price;

        public Button GetAddButton()
        {
            return addButton;
        }

        public int GetPrice()
        {
            return _price;
        }

        public void SetPrice(int value)
        {
            _price = value;
            price.text = _price.ToString();
        }

        public void SetFillAmount(float value)
        {
            unitImage.fillAmount = value;
        }
    }
}