
using UnityEngine;
using System.Collections;
public class Move : MonoBehaviour
{
// 手柄位置
SteamVR_TrackedObject tracked;
// Camera
public Transform mCamera;
//头盔
public Transform mCameraHead;
// 速度
public float speed;
void Awake()
{
//获取手柄控制
    tracked = GetComponent<SteamVR_TrackedObject>();
}
// Use this for initialization
void Start()
{
transform.localEulerAngles = new Vector3(0, mCameraHead.localEulerAngles.y, 0);
transform.localPosition = new Vector3(mCameraHead.localPosition.x, 0, mCameraHead.localPosition.z);
}
// Update is called once per frame
void Update()
{
var deviceright = SteamVR_Controller.Input((int)tracked.index);

        Vector3 direFor = mCameraHead.forward;
        direFor.y = 0;
        direFor.Normalize();
        Vector3 direRight = mCameraHead.right;
        direRight.y = 0;
        direRight.Normalize();
//按下圆盘键
if (deviceright.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
{
Vector2 ve = deviceright.GetAxis();
            
            
float angle = VectorAngle(new Vector2(1, 0), ve);
//下
if (angle > 45 && angle < 135)
{
mCamera.Translate(-direFor * Time.deltaTime * speed);
}
//上
else if (angle < -45 && angle > -135)
{
//Debug.Log("上");
mCamera.Translate(direFor * Time.deltaTime * speed);
}
//左
else if ((angle < 180 && angle > 135) || (angle < -135 && angle > -180))
{
//Debug.Log("左");
mCamera.Translate(-direRight * Time.deltaTime * speed);
}
//右
else if ((angle > 0 && angle < 45) || (angle > -45 && angle < 0))
{
//Debug.Log("右");
mCamera.Translate(direRight * Time.deltaTime * speed);
}
}
}
// 根据在圆盘才按下的位置，返回一个角度值
float VectorAngle(Vector2 from, Vector2 to)
{
float angle;
Vector3 cross = Vector3.Cross(from, to);
angle = Vector2.Angle(from, to);
return cross.z > 0 ? -angle : angle;
}
}


