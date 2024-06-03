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
        protected GameObject bullet;
        protected GameObject bEffect;

        protected Transform firePoint;


        protected virtual void Start()
        {
            firePoint = GameObject.Find("FirePoint").transform;
        }

        protected RaycastHit hit;
        //private float MaxDistance = 15f;

        // 발사체 발사
        public void fireProjectile() 
        {
            GameObject blt = Instantiate(bullet);

            if (blt != null)
            {
                Debug.Log("발사");

                // 플레이어의 앞쪽으로 쭉 이동
                // 플레이어 dir, firePoint 위치
                blt.GetComponent<Bullet>().SetDir(transform.forward.normalized);
            }
            else
            {
                Debug.Log("총알없음");
            }


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