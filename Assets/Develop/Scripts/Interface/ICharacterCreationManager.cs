namespace CreatureGrove
{
    public enum CharacterType
    {
        Friendly,  // ¡÷πŒ
        Enemy      // ∏ÛΩ∫≈Õ
    }

    public interface ICharacterCreationManager
    {
        public void CreatCharacter(CharacterType type);
    }
}