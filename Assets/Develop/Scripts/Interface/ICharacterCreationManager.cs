namespace CreatureGrove
{
    public enum CharacterType
    {
        Friendly,  // �ֹ�
        Enemy      // ����
    }

    public interface ICharacterCreationManager
    {
        public void CreatCharacter(CharacterType type);
    }
}