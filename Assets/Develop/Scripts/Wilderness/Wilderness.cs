using UnityEngine;

namespace CreatureGrove
{
    public enum CharacterType
    {
        Townsfolk,  // �ֹ�(����ƮX����)
        Enemy      // ����
    }

    public class Wilderness : MonoBehaviour, ICharacterCreationManager, IFieldItemManager
    {
        // [ICharacterCreationManager]
        public void CreatCharacter(CharacterType type)
        {

        }

        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
        {

        }
    }
}