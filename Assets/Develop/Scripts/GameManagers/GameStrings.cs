using System;
using UnityEngine;

namespace CreatureGrove
{
    public static class GameStrings
    {
        public const string FirePoint = "FirePoint";
        public const string Inventory = "Inventory";
        public const string WeaponTag = "Weapon";
        public const string InteractFun = "Interact";

        // 건물 이름
        public const string BuildingAdministrative = "Administrative";
        public const string BuildingCubbyFood = "Cubby_Food";
        public const string BuildingCubbyRock = "Cubby_Rock";
        public const string BuildingCubbyWood = "Cubby_Wood";
        public const string BuildingFarm = "Farm";
        public const string BuildingGuardhouse = "Guardhouse";
        public const string BuildingHouse = "House";
        public const string BuildingMarketPlace = "MarketPlace";
        public const string BuildingPentHouse = "PentHouse";
        public const string BuildingShed = "Shed_Workshop";



    }
    
    public static class Utils
    {
        public static GameObject GetRootParent(Transform child)
        {
            // Null üũ
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child), "Child transform cannot be null");
            }

            Transform cParent = child;
            while (cParent.parent != null)
            {
                cParent = cParent.parent;
            }
            return cParent.gameObject;
        }
    }
}