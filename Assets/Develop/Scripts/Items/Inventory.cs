using UnityEngine;
using System.Collections.Generic;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour
    {
        #region 싱글턴
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

        // 인벤토리 저장칸
        private List<Item> items;
        public List<Item> Items { get { return items; } }

        // 인벤토리에 등록
        public void addToInventory(Item item)
        {
            items.Add(item);
        }
        
        // 인벤토리에서 삭제
        public void removeFromInventory(Item item) 
        {
            items.Remove(item);
        }
    }
}