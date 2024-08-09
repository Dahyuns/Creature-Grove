using UnityEngine;

namespace CreatureGrove
{
    public enum CharacterType
    {
        Townsfolk,  // �ֹ�(����ƮX����)
        Enemy      // ����
    }

    // �ʵ�
    public class Wilderness : MonoBehaviour, ICharacterCreationManager
    {
        #region �̱���
        private static Wilderness instance;
        public static Wilderness Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            DestroyImmediate(gameObject);
        }
        #endregion

        // [ICharacterCreationManager]
        public void CreatCharacter(CharacterType type)
        {

        }
    }
}