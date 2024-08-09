using UnityEngine;
using System.Collections.Generic;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour
    {
        #region �̱���
        private static Inventory instance;
        public static Inventory Instance
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

        // �κ��丮 ����ĭ
        private List<Item> items;
        public List<Item> Items { get { return items; } }

        // �κ��丮�� ���
        public void addToInventory(Item item)
        {
            items.Add(item);
        }
        
        // �κ��丮���� ����
        public void removeFromInventory(Item item) 
        {
            items.Remove(item);
        }
    }
}