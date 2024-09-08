using UnityEngine;

namespace CreatureGrove
{
    // "플레이어가 보는 방향으로 레이를 쏘아" 상호작용(충돌처리)을 위하는 스크립트
    public class PlayerViewRaycaster : MonoBehaviour
    {
        private float maxDistance = 2f;
        public LayerMask layerMask;

        private bool hasPressed = false;
        public void ToggleButtonState()
        {
            hasPressed = !hasPressed;
            Debug.Log("버튼 상태: " + hasPressed);
        }

        private void Update()
        {
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;

            RaycastHit hit;

            if (Physics.Raycast(origin, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.Collide))
            {
                Debug.DrawRay(origin, direction * hit.distance, Color.red); 
                hit.collider.SendMessage("Interact", SendMessageOptions.RequireReceiver);
            }
            else
            {
                Debug.DrawRay(origin, direction * maxDistance, Color.green);
            }
        }
    }
}