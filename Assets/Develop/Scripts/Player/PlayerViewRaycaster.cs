using UnityEngine;

namespace CreatureGrove
{
    // "�÷��̾ ���� �������� ���̸� ���" ��ȣ�ۿ�(�浹ó��)�� ���ϴ� ��ũ��Ʈ
    public class PlayerViewRaycaster : MonoBehaviour
    {
        private float maxDistance = 2f;
        public LayerMask layerMask;

        private bool hasPressed = false;
        public void ToggleButtonState()
        {
            hasPressed = !hasPressed;
            Debug.Log("��ư ����: " + hasPressed);
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