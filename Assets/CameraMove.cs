using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
     float sensitivityX = 0.0001f;
     float sensitivityY = 0.0001f;
	 Vector2 m_screenPos = new Vector2();
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		DeskopInput();

			//float rotationX = Input.GetAxis("Vertical") * sensitivityX;
			//float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
			//transform.Translate(new Vector3(0,rotationY,0)*Time.deltaTime,Space.World);
	}
	void DeskopInput()
	{
		//�����ƹ����䪺���ʶZ��
		//float mx = Input.GetAxis("Mouse X");
		float my = Input.GetAxis("Mouse Y");
		float speed = 30f;

		if ( my != 0 )
		{
			//�ƹ�����
			if (Input.GetMouseButton(0))
			{
				//������v����m
				Camera.main.transform.Translate(new Vector3(0, -my * Time.deltaTime * speed, 0));
			}
			if (Camera.main.transform.position.y > 9)
				Camera.main.transform.position = new Vector3(0, 9, -6);
			if (Camera.main.transform.position.y < 1)
				Camera.main.transform.position = new Vector3(0, 1, -6);
		}
	}
	void MobileInput()
	{
		
		if (Input.touchCount <= 0)
			return;

		//1�Ӥ��Ĳ�I�ù�
		if (Input.touchCount == 1)
		{

			//�}�lĲ�I
			if (Input.touches[0].phase == TouchPhase.Began)
			{

				//����Ĳ�I��m
				m_screenPos = Input.touches[0].position;

				//�������
			}
			else if (Input.touches[0].phase == TouchPhase.Moved)
			{

				//������v��
				Camera.main.transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime, -Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
			}


			//������}�ù�
			if (Input.touches[0].phase == TouchPhase.Ended && Input.touches[0].phase == TouchPhase.Canceled)
			{

				Vector2 pos = Input.touches[0].position;

				//�����������
				if (Mathf.Abs(m_screenPos.x - pos.x) > Mathf.Abs(m_screenPos.y - pos.y))
				{
					if (m_screenPos.x > pos.x)
					{
						//����V���ư�
					}
					else
					{
						//����V�k�ư�
					}
				}
				else
				{
					if (m_screenPos.y > pos.y)
					{
						//����V�U�ư�
					}
					else
					{
						//����V�W�ư�
					}
				}
			}

			//��v���Y��A�p�G1�Ӥ���H�WĲ�I�ù�
		}
		else if (Input.touchCount > 1)
		{

			//�O����Ӥ����m
			Vector2 finger1 = new Vector2();
			Vector2 finger2 = new Vector2();

			//�O����Ӥ�����ʶZ��
			Vector2 move1 = new Vector2();
			Vector2 move2 = new Vector2();

			//�O�_�O�p��2�IĲ�I
			for (int i = 0; i < 2; i++)
			{

				UnityEngine.Touch touch = UnityEngine.Input.touches[i];

				if (touch.phase == TouchPhase.Ended)
					break;

				if (touch.phase == TouchPhase.Moved)
				{
					//�C�������m
					float move = 0;

					//Ĳ�I�@�I
					if (i == 0)
					{
						finger1 = touch.position;
						move1 = touch.deltaPosition;
						//�t�@�I
					}
					else
					{
						finger2 = touch.position;
						move2 = touch.deltaPosition;

						//���̤jX
						if (finger1.x > finger2.x)
						{
							move = move1.x;
						}
						else
						{
							move = move2.x;
						}

						//���̤jY�A�ûP���X��X�֥[
						if (finger1.y > finger2.y)
						{
							move += move1.y;
						}
						else
						{
							move += move2.y;
						}

						//�����Z���V���AZ��m�[���V�h�A�ۤϤ�
						Camera.main.transform.Translate(0, 0, move * Time.deltaTime);
					}
				}
			}//end for
		}//end else if 
	}//end void

}
