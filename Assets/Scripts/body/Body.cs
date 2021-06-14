using UnityEngine;

namespace body
{
    public class Body : MonoBehaviour
    {
        [SerializeField] private MiningResources miningResources;
        [SerializeField] private WinRulePanel winRulePanel;

        public void Reset()
        {
            miningResources.Reset();
            winRulePanel.Reset();
        }
    }
}