using UnityEngine;

namespace CreatureGrove
{
    public enum CharacterType
    {
        Townsfolk,  // 주민(퀘스트X상태)
        Enemy      // 몬스터
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