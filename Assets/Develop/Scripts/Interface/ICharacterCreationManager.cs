namespace CreatureGrove
{
    public enum CharacterType
    {
        Friendly,  // ¡÷πŒ
        Enemy      // ∏ÛΩ∫≈Õ
    }

    public interface ICharacterCreationManager
    {
        void CreatCharacter(CharacterType type);
    }
}