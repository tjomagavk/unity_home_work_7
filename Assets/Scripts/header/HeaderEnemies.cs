using System.Collections.Generic;
using Prefabs;
using UnityEngine;
using UnityEngine.UI;

namespace header
{
    public class HeaderEnemies : MonoBehaviour
    {
        [SerializeField] private HeaderResource enemy;
        [SerializeField] private GridLayoutGroup bar;
        [SerializeField] private Sprite barPointImage;

        private readonly List<GameObject> _points = new List<GameObject>();

        public void Reset()
        {
            CreatePoints();
            ClearBar();
            enemy.SetCount(1);
        }

        private void Start()
        {
            Reset();
        }

        private void CreatePoints()
        {
            if (_points.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    GameObject point = new GameObject();
                    point.name = $"BarPoint_{i}";
                    Image image = point.AddComponent<Image>();
                    image.sprite = barPointImage;
                    image.GetComponent<RectTransform>().SetParent(bar.transform);
                    point.SetActive(false);
                    _points.Add(point);
                }
            }
        }

        public void SetEnemy(int value)
        {
            enemy.SetCount(value);
        }

        public void ActivateBarPoints(int countPoints)
        {
            CreatePoints();
            if (countPoints > 10)
            {
                countPoints = 10;
            }

            for (int i = 0; i < countPoints; i++)
            {
                _points[i].SetActive(true);
            }
        }

        public void ClearBar()
        {
            foreach (GameObject point in _points)
            {
                point.SetActive(false);
            }
        }
    }
}