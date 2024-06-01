using UnityEngine;

namespace CreatureGrove
{
    public enum WeaponType 
    { Gun, Bow } // Sword, Wand...

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

        // ����
        protected GameObject bullet;
        protected GameObject bEffect;


        protected virtual void Start()
        {
           //// �÷��̾��� ���� Ÿ�Կ� ���� �Ѿ�(��) ����
           //switch (transform.parent.GetComponent<Player>().WeaponType)
           //{
           //    case WeaponType.Gun:
           //        bullet = GameObject.Find("Gun_Bullet");
           //        bEffect = GameObject.Find("");
           //        break;
           //
           //    case WeaponType.Bow:
           //        bullet = GameObject.Find("Bow_Bullet");
           //        bEffect = GameObject.Find("");
           //        break;
           //}
        }

        protected RaycastHit hit;
        //private float MaxDistance = 15f;

        // �߻�ü �߻�
        public void fireProjectile(Vector3 transform) 
        {

            GameObject blt = Instantiate(bullet, transform, Quaternion.Euler(transform));

            Debug.Log("�߻�");

            blt?.transform.Translate(Vector3.forward);

            // Ȱ : (����)������, �� : ������
            //if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            //{
            //    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            //}
        }
                

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