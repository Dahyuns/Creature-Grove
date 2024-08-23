using UnityEngine;

namespace CreatureGrove
{
    public enum CharacterType
    {
        Townsfolk,  // �ֹ�(����ƮX����)
        Enemy      // ����
    }

    // �ʵ� - �߻�
    // ����, ���� ���� �� ����
    public class Wilderness : MonoBehaviour
    {
        #region �̱���
        private static Wilderness instance;
        public static Wilderness Instance
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
            #endregion

            // �̰� ������ ��������
            basePos = GameObject.Find("basePos").transform.position;
        }

        // [�� �ε��, ���ʵ� ����] (����, ������� �����ϱ�)
        [SerializeField] private GameObject grass;
        private GameObject TownZone;
        private GameObject DarkZone;

        // ���ʾƷ� ���� ��ǥ
        private Vector3 basePos;

        // sin�Լ� x��ǥ ���� 
        private float unit = 5f;


        public void SetGrass()
        {
            Instantiate(grass, this.transform);

            //�ʵ� ��� ���� (Ŀ������ ��������, �⺻�� 1)
            //private float cycleMulti = 1;
            // ����, ������ '����'(=z�� ��) * SIN�Լ� (��� ���� * x��) + �����̵���(=z�� ��)
            //float numX = unit * i;
            //float numZ = z / 2 * Mathf.Sin(cycleMulti * numX) + z / 2;
        }

    }
}