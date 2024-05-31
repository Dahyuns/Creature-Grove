using UnityEngine;

namespace CreatureGrove
{
    public enum WeaponType 
    { Gun, Bow } // Sword, Wand...

    public class Weapon : MonoBehaviour
    {
        // 공격력
        protected float atkPower;

        // 공격속도
        protected float atkSpeed;

        // 치명타율 - 치명타가 터지면, 추가 적용되는 비율
        protected float criticalRate;

        // 치명타 확률
        protected float critHitProb;

        // 치명타율 적용된 공격력 반환
        public float effectiveAtkPower()
        {
            // 1~10반환하는 랜덤함수
            if (Random.Range(1,11) < (critHitProb / 10))
            {
                // 공격력 + 공격력의 n퍼센트
                return atkPower + (atkPower * criticalRate);
            }
            else
            {
                return atkPower;
            }
        }

        // 참조
        private GameObject bullet;
        private GameObject bEffect;

        private void Awake()
        {
            //플레이어의 무기 타입에 따라 총알(모델) 설정
            switch (GetComponent<Player>().WeaponType)
            {
                case WeaponType.Gun:
                    bullet = GameObject.Find("Gun_Bullet");
                    bEffect = GameObject.Find("");
                    break;

                case WeaponType.Bow:
                    bullet = GameObject.Find("Bow_Bullet");
                    bEffect = GameObject.Find("");
                    break;
                
                default:
                    Debug.Log("WeaponType이 없음");
                    break;
            }
        }

        RaycastHit hit;
        private float MaxDistance = 15f;

        // 발사체 발사
        public void fireProjectile() 
        {

            GameObject blt = Instantiate(bullet);

            Debug.Log("발사");

            blt?.transform.Translate(Vector3.forward);
            Destroy(bullet,2f);

            // 활 : (약한)포물선, 총 : 일직선
            //if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            //{
            //    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            //}
        }
                

        #region 레벨업함수
        public void LevelUp()
        {
            atkPower = atkPower + (atkPower * 0.2f);
        }

        public void LevelUp(int level)
        {
            atkPower = atkPower + (level * 5f);
        }

        public void LevelUp(int level, float reductionRate) //레벨업당 감소비율
        {
            atkPower = atkPower + (level * (5f - level * reductionRate));
        }
        #endregion
    }
}