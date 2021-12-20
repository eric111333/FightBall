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
		//紀錄滑鼠左鍵的移動距離
		//float mx = Input.GetAxis("Mouse X");
		float my = Input.GetAxis("Mouse Y");
		float speed = 30f;

		if ( my != 0 )
		{
			//滑鼠左鍵
			if (Input.GetMouseButton(0))
			{
				//移動攝影機位置
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

		//1個手指觸碰螢幕
		if (Input.touchCount == 1)
		{

			//開始觸碰
			if (Input.touches[0].phase == TouchPhase.Began)
			{

				//紀錄觸碰位置
				m_screenPos = Input.touches[0].position;

				//手指移動
			}
			else if (Input.touches[0].phase == TouchPhase.Moved)
			{

				//移動攝影機
				Camera.main.transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime, -Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
			}


			//手指離開螢幕
			if (Input.touches[0].phase == TouchPhase.Ended && Input.touches[0].phase == TouchPhase.Canceled)
			{

				Vector2 pos = Input.touches[0].position;

				//手指水平移動
				if (Mathf.Abs(m_screenPos.x - pos.x) > Mathf.Abs(m_screenPos.y - pos.y))
				{
					if (m_screenPos.x > pos.x)
					{
						//手指向左滑動
					}
					else
					{
						//手指向右滑動
					}
				}
				else
				{
					if (m_screenPos.y > pos.y)
					{
						//手指向下滑動
					}
					else
					{
						//手指向上滑動
					}
				}
			}

			//攝影機縮放，如果1個手指以上觸碰螢幕
		}
		else if (Input.touchCount > 1)
		{

			//記錄兩個手指位置
			Vector2 finger1 = new Vector2();
			Vector2 finger2 = new Vector2();

			//記錄兩個手指移動距離
			Vector2 move1 = new Vector2();
			Vector2 move2 = new Vector2();

			//是否是小於2點觸碰
			for (int i = 0; i < 2; i++)
			{

				UnityEngine.Touch touch = UnityEngine.Input.touches[i];

				if (touch.phase == TouchPhase.Ended)
					break;

				if (touch.phase == TouchPhase.Moved)
				{
					//每次都重置
					float move = 0;

					//觸碰一點
					if (i == 0)
					{
						finger1 = touch.position;
						move1 = touch.deltaPosition;
						//另一點
					}
					else
					{
						finger2 = touch.position;
						move2 = touch.deltaPosition;

						//取最大X
						if (finger1.x > finger2.x)
						{
							move = move1.x;
						}
						else
						{
							move = move2.x;
						}

						//取最大Y，並與取出的X累加
						if (finger1.y > finger2.y)
						{
							move += move1.y;
						}
						else
						{
							move += move2.y;
						}

						//當兩指距離越遠，Z位置加的越多，相反之
						Camera.main.transform.Translate(0, 0, move * Time.deltaTime);
					}
				}
			}//end for
		}//end else if 
	}//end void

}
