using UnityEngine;

namespace CreatureGrove
{
    public class NatureInteractable : MonoBehaviour
    {
        /* ��ȣ�ۿ�
        ��ȣ�ۿ뿡�� �ִ� �Ÿ��� �־ ���� ���� �ȿ� ���߸� �����ϰ� �Ѵ�. (���� ����)
        ��ȣ�ۿ� �� �� �ִ� ���� �� �� ���� ����� ������ �� �־�� �Ѵ�. (���̾�)
        ��ȣ�ۿ��� ������ ��Ȳ�� �Ǹ� ȭ�鿡 �ȳ� �ؽ�Ʈ�� ����. (�̱���)
        ��ȣ�ۿ� Ű�� ������ ��ȣ�ۿ��� ���۽�Ų��.(Interact �Լ�)
        */
        // ������ : ������ٰ� �ٽ� �ð������� (���� or ��ħ) - ���� ������ �ȵǰ�

        public virtual void Interact()
        {
            Debug.Log("NatureInteractable - Interact ����");
        }
    }
}