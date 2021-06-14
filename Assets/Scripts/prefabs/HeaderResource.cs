using UnityEngine;
using UnityEngine.UI;

namespace prefabs
{
    public class HeaderResource : MonoBehaviour
    {
        [SerializeField] private Text count;
        private int _count;

        // Start is called before the first frame update
        void Start()
        {
            Visualize();
        }

        public int GetCount()
        {
            return _count;
        }

        public void SetCount(int value)
        {
            _count = value;
            Visualize();
        }

        private void Visualize()
        {
            count.text = _count.ToString();
        }
    }
}