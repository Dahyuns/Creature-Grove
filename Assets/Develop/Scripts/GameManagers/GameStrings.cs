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