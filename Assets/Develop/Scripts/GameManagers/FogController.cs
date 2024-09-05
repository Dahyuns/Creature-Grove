using UnityEngine;

namespace CreatureGrove
{
    public class FogController : MonoBehaviour
    {
        // Dark In
        private void OnTriggerEnter(Collider other)
        {
            // 색상 설정
            // R: 67f / 255f , G: 59f / 255f , B: 59f / 255f
            RenderSettings.fogColor = new Color(0.2627f, 0.2314f, 0.2314f);

            // 거리 설정
            RenderSettings.fogStartDistance = 5f; ;
            RenderSettings.fogEndDistance = 60f;
        }

        // Dark Out
        private void OnTriggerExit(Collider other)
        {
            // 색상 설정
            // R: 135f / 255f , G: 197f / 255f , B: 193f / 255f
            RenderSettings.fogColor = new Color(0.5294f, 0.7725f, 0.7569f);

            // 거리 설정
            RenderSettings.fogStartDistance = 3f;
            RenderSettings.fogEndDistance = 105f;
        }
    }
}