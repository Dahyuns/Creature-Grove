using UnityEngine;

namespace CreatureGrove
{
    public class FenceManager : MonoBehaviour
    {
        // ������ �߰�?
        // ����
        [SerializeField] private GameObject[] fences;

        private int level = 0;
        private int MaxLevel = 3;

        private void Update()
        {

        }

        public void LevelUp()
        {
            if (level < MaxLevel)
            {
                if (level != 0)
                {
                    fences[level-1].SetActive(false);
                }

                level++;
                fences[level-1].SetActive(true);
            }
        }
    }
}