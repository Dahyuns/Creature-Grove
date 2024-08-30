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
                Debug.Log("������ �Ұ� : �ִ� �����Դϴ�.");
            }
        }

        // ��ȣ�ۿ��ϸ� �ش� �ǹ��� ��� ������..?
        public void Work()
        {

        }
    }
}