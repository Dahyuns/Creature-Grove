using UnityEngine;

namespace CreatureGrove
{
    public enum WeaponType
    { Gun, Bow } // Sword, Wand...

    public class Weapon : MonoBehaviour
    {
        // 무기 타입
        public static WeaponType weaponType { get; set; }

        // 추가 : 공격력 적용

        // 공격력
        public virtual float AtkPower { get; }

        // 공격속도
        public virtual float AtkSpeed { get; }

        // 치명타율 - 치명타가 터지면, 추가 적용되는 비율
        public virtual float CriticalRate { get; }

        // 치명타 확률
        public virtual float CritHitProb { get; }

        // 치명타율 적용된 공격력 반환
        protected float effectiveAtkPower()
        {
            // 1~10반환하는 랜덤함수
            if (Random.Range(1, 11) < (CritHitProb / 10))
            {
                // 공격력 + 공격력의 n퍼센트
                return AtkPower + (AtkPower * CriticalRate/100);
            }
            else
            {
                return AtkPower;
            }
        }

        private GameObject tmpObject;

        // 참조 , null 넣지말기, null 체크하기
        protected virtual GameObject Bullet() { return tmpObject; }
        protected virtual GameObject BulletEffect() { return tmpObject; }
        protected virtual Transform FirePoint() { return tmpObject.transform; }
        protected GameObject parent {  get { return Utils.GetRootParent(transform); } }


        // 발사체 발사
        public void fireProjectile()
        {
            Bullet blt = Instantiate(Bullet(), this.transform, false).GetComponent<Bullet>();
            blt.ConfigureAndShoot(FirePoint(), parent, effectiveAtkPower());

            if (blt != null)
            {
                Debug.Log("발사");
            }
            else
            {
                Debug.Log("총알없음");
            }
        }

        /* 레벨업함수
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
        */
    }
}