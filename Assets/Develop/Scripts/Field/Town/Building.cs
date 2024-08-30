using UnityEngine;

namespace CreatureGrove
{
    public class Building : MonoBehaviour
    {
        public int Level { get; private set; }
        private int MaxLevel = 1;
        public void SetLevel(int input)
        {
            Level = input;
        }

        public string Name { get; private set; }

        public void SetName(string input)
        {
            Name = input;
        }

        public void LevelUp()
        {
            if(Level != MaxLevel)
            {
                Level += 1;
            }
            else
            {
                Debug.Log("레벨업 불가 : 최대 레벨입니다.");
            }
        }

        // 상호작용하면 해당 건물의 기능 켜지고..?
        public void Work()
        {

        }
    }
}