using UnityEngine;

namespace CreatureGrove
{
    public class NatureInteractable : MonoBehaviour
    {
        /* 상호작용
        상호작용에는 최대 거리가 있어서 일정 범위 안에 들어가야만 동작하게 한다. (레이 길이)
        상호작용 할 수 있는 대상과 할 수 없는 대상을 구별할 수 있어야 한다. (레이어)
        상호작용이 가능한 상황이 되면 화면에 안내 텍스트를 띄운다. (미구현)
        상호작용 키를 누르면 상호작용을 동작시킨다.(Interact 함수)
        */
        // 리스폰 : 사라졌다가 다시 시간지나면 (몇초 or 아침) - 돌은 리스폰 안되겡

        public virtual void Interact()
        {
            Debug.Log("NatureInteractable - Interact 실행");
        }
    }
}