//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RayShooter : MonoBehaviour
//{
//    //������ ������
//    private Camera _camera;
//    private void Start()
//    {
//        //�������� ������ � ������
//        _camera = GetComponent<Camera>();


//    }

//    private void Update()
//    {
//        //���������, ����� �������� �� "�������"
//        if (Input.GetMouseButtonDown(0))
//        {
//            //���������� ����� ������
//            Vector3 screen�enter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

//            //������� ��� �� ������ ������ ������������ ������
//            Ray ray = _camera.ScreenPointToRay(screen�enter);
//            RaycastHit hit;//���������� ��������� � ��� ����������

//            //���� ������ � ����� �� ������
//            if (Physics.Raycast(ray, out hit))//������� ��� ray ��������� ������������ ��������� � hit
//            {
//                //������������� ��������� � ����
//                GameObject hitObject = hit.transform.gameObject;//�������� ������, � ������� ������
//                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();//�������� �������� ����� �������

//                //��������, ��������� � ������
//                if (target != null)
//                {
//                    target.ReactToHit();
//                }
//                else
//                {
//                    //��������� �����������
//                    StartCoroutine(SphereInicatorCoroutine(hit.point));
//                    //������ ���������� �����, ����� ���������� ���������� ����
//                    Debug.DrawLine(this.transform.position, hit.point, Color.green, 6);
//                }
//            }
//        }
//    }

//    private void OnGUI()
//    {
//        //���������� ����������� ���������� � ������ ������
//        int size = 12;
//        float posX = _camera.pixelWidth / 2 - size / 4;
//        float posY = _camera.pixelHeight / 2 - size / 2;
//        GUI.Label(new Rect(posX, posY, size, size), "*");
//    }

//    //�����������, ������� ������� ����� � ����� ���������
//    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
//    {
//        //������� ������� ������ �����
//        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        sphere.transform.position = pos;//��������� ������� �����

//        //yield - �������� ����� ��� �����������, ������� ��������� ��, ��� ���� ������������
//        yield return new WaitForSeconds(6);//����� ��������
//        //����� �������� �������� � ��� ����� �����������
//        Destroy(sphere);//������ �����
//    }
//}