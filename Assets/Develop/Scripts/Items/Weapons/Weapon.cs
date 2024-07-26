using UnityEngine;

namespace CreatureGrove
{
    public enum WeaponType 
    { Gun, Bow } // Sword, Wand...

    public class Weapon : MonoBehaviour
    {
        // ���� Ÿ��
        //public virtual WeaponType weaponType { get; }
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
        public float effectiveAtkPower()
        {
            // 1~10��ȯ�ϴ� �����Լ�
            if (Random.Range(1,11) < (CritHitProb / 10))
            {
                // ���ݷ� + ���ݷ��� n�ۼ�Ʈ
                return AtkPower + (AtkPower * CriticalRate);
            }
            else
            {
                return AtkPower;
            }
        }

        // ����
        protected GameObject bullet;
        protected GameObject bEffect;

        protected Transform firePoint;


        protected virtual void Start()
        {
            firePoint = GameObject.Find("FirePoint").transform;
        }

        protected RaycastHit hit;
        //private float MaxDistance = 15f;

        // �߻�ü �߻�
        public virtual void fireProjectile() 
        {
            GameObject blt = Instantiate(bullet);

            if (blt != null)
            {
                Debug.Log("�߻�");

                // �÷��̾��� �������� �� �̵�
                // �÷��̾� dir, firePoint ��ġ
                blt.GetComponent<Bullet>().SetDir(transform.forward.normalized);
            }
            else
            {
                Debug.Log("�Ѿ˾���");
            }


            // Ȱ : (����)������, �� : ������
            //if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            //{
            //    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            //}
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