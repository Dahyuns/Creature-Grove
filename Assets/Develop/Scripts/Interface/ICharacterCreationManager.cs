namespace CreatureGrove
{
    public enum CharacterType
    {
        Friendly,  // �ֹ�
        Enemy      // ����
    }

    public interface ICharacterCreationManager
    {
        void CreatCharacter(CharacterType type);
    }
}