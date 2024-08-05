using UnityEngine;

namespace CreatureGrove
{
    public enum WeaponType
    { Gun, Bow } // Sword, Wand...

    public class Weapon : MonoBehaviour
    {
        // ���� Ÿ��
        public static WeaponType weaponType { get; set; }

        // �߰� : ���ݷ� ����

        // ���ݷ�
        public virtual float AtkPower { get; }

        // ���ݼӵ�
        public virtual float AtkSpeed { get; }

        // ġ��Ÿ�� - ġ��Ÿ�� ������, �߰� ����Ǵ� ����
        public virtual float CriticalRate { get; }

        // ġ��Ÿ Ȯ��
        public virtual float CritHitProb { get; }

        // ġ��Ÿ�� ����� ���ݷ� ��ȯ
        protected float effectiveAtkPower()
        {
            // 1~10��ȯ�ϴ� �����Լ�
            if (Random.Range(1, 11) < (CritHitProb / 10))
            {
                // ���ݷ� + ���ݷ��� n�ۼ�Ʈ
                return AtkPower + (AtkPower * CriticalRate/100);
            }
            else
            {
                return AtkPower;
            }
        }

        private GameObject tmpObject;

        // ���� , null ��������, null üũ�ϱ�
        protected virtual GameObject Bullet() { return tmpObject; }
        protected virtual GameObject BulletEffect() { return tmpObject; }
        protected virtual Transform FirePoint() { return tmpObject.transform; }
        protected GameObject parent {  get { return Utils.GetRootParent(transform); } }


        // �߻�ü �߻�
        public void fireProjectile()
        {
            Bullet blt = Instantiate(Bullet(), this.transform, false).GetComponent<Bullet>();
            blt.ConfigureAndShoot(FirePoint(), parent, effectiveAtkPower());

            if (blt != null)
            {
                Debug.Log("�߻�");
            }
            else
            {
                Debug.Log("�Ѿ˾���");
            }
        }

        /* �������Լ�
        public void LevelUp()
        {
            atkPower = atkPower + (atkPower * 0.2f);
        }

        public void LevelUp(int level)
        {
            atkPower = atkPower + (level * 5f);
        }

        public void LevelUp(int level, float reductionRate) //�������� ���Һ���
        {
            atkPower = atkPower + (level * (5f - level * reductionRate));
        }
        */
    }
}