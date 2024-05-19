using UnityEngine;

namespace CreatureGrove
{
    public enum WeaponType 
    { Gun, Bow } //Sword, Wand

    public class Weapon : MonoBehaviour
    {
        // ���ݷ�
        protected float atkPower;

        // ���ݼӵ�
        protected float atkSpeed;

        // ġ��Ÿ�� - ġ��Ÿ�� ������, �߰� ����Ǵ� ����
        protected float criticalRate;

        // ġ��Ÿ Ȯ��
        protected float critHitProb;

        // ġ��Ÿ�� ����� ���ݷ� ��ȯ
        public float effectiveAtkPower()
        {
            // 1~10��ȯ�ϴ� �����Լ�
            if (Random.Range(1,11) < (critHitProb / 10))
            {
                // ���ݷ� + ���ݷ��� n�ۼ�Ʈ
                return atkPower + (atkPower * criticalRate);
            }
            else
            {
                return atkPower;
            }
        }

        // �߻�ü �߻�
        public virtual void fireProjectile() { }

        #region �������Լ�
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
        #endregion
    }
}