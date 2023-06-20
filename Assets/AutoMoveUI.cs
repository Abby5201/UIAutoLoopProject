using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AutoMoveUI : MonoBehaviour
{
    private Image[] m_img;

//队列存放的位置

    private Vector3 imgMoveStaet;

//队列

    private Queue m_queue;

//程序第一次执行是true，其他时间是false

    private bool isStartImplement = true;

//图片从展示移动到屏幕外的位置

    private Vector3 imgMoveEnd;

//存放分辨率做自适应

    private int resolutionAdaptation;

// Start is called before the first frame update
    void Start()
    {
        //初始化
        imgMoveEnd = new Vector3();
        imgMoveStaet = new Vector3();
        m_queue = new Queue();
        m_img = GetComponentsInChildren<Image>(); //获取所有子类
        resolutionAdaptation = Screen.width; //Screen.width获取窗口分辨率

        //分辨率自适应
        AdaptiveResolvingPower(resolutionAdaptation);
        //每2秒调用PlayImg方法出队列
        InvokeRepeating("MoveImg", 0, 2);
    }

/*
 * 方法作用：把图片从队列中移出后移动到屏幕上做展示，之后将图片移除屏幕，
 *           移除的同时，下一张图片会自动移动到屏幕上做展示，以此类推。
 */
    private void MoveImg()
    {
        //检查是否第一次执行，做初始化
        if (isStartImplement)
        {
            //将所有图片添加到队列
            AddImgList();
            //修改状态
            isStartImplement = false;
        }
        else
        {
            //将图片移出队列，并移动到指定位置
            Image a = (Image)m_queue.Dequeue();
            a.transform.DOMove(transform.position, 1);
            a.transform.DOMove(imgMoveEnd, 1).SetDelay(2); //暂停2秒执行退出展示
            //将退出的图片添加到队列里形成循环。
            AddImg(a);
        }
    }

/*
 * 方法作用：将所有图片放到队列的同时将所有图片移动到预先设置好的位置上
 */
    private void AddImgList()
    {

        for (int i = 0; i < m_img.Length; i++)
        {
            //检测改数组是否在队列里
            if (m_queue.Contains(m_img[i]) == false)
            {
                //m_img.transform.position = imgMoveStaet;
                m_img[i].transform.position = imgMoveStaet;
                //将图片添加到队列里
                m_queue.Enqueue(m_img[i]);
            }
            else
            {
                return;
            }
        }
    }

/*
 * 方法作用：将图片放到队列的同时将图片直接放到开始位置
 */
    private void AddImg(Image m_img)
    {
        if (m_queue.Contains(m_img) == false)
        {
            m_img.transform.position = imgMoveStaet;
            //将图片添加到队列里
            m_queue.Enqueue(m_img);
        }
        else
        {
            return;
        }
    }

/*
 * 方法作用：做屏幕分辨率自适应，根据不同分辨率调整开始位和结束位
 */
    private void AdaptiveResolvingPower(int resolutionAdaptation)
    {
        switch (resolutionAdaptation)
        {
            //可以不那么多分辨率，看需求吧
            case 960:
                Debug.Log("960");
                imgMoveEnd = transform.position + Vector3.right * -1000;
                imgMoveStaet = transform.position + Vector3.right * 1000;
                break;
            case 1280:
                Debug.Log("1280");
                imgMoveEnd = transform.position + Vector3.right * -1400;
                imgMoveStaet = transform.position + Vector3.right * 1400;
                break;
            case 1366:
                Debug.Log("1366");
                imgMoveEnd = transform.position + Vector3.right * -1410;
                imgMoveStaet = transform.position + Vector3.right * 1410;
                break;
            case 1920:
                Debug.Log("1920");
                imgMoveEnd = transform.position + Vector3.right * -2000;
                imgMoveStaet = transform.position + Vector3.right * 2000;
                break;
            case 2560:
                Debug.Log("2560");
                imgMoveEnd = transform.position + Vector3.right * -2700;
                imgMoveStaet = transform.position + Vector3.right * 2700;
                break;
            case 1024:
                Debug.Log("1024");
                imgMoveEnd = transform.position + Vector3.right * -1064;
                imgMoveStaet = transform.position + Vector3.right * 1064;
                break;

            case 640:
                Debug.Log("640");
                imgMoveEnd = transform.position + Vector3.right * -680;
                imgMoveStaet = transform.position + Vector3.right * 680;
                break;
            case 800:
                Debug.Log("800");
                imgMoveEnd = transform.position + Vector3.right * -860;
                imgMoveStaet = transform.position + Vector3.right * 860;
                break;
            case 1400:
                Debug.Log("1400");
                imgMoveEnd = transform.position + Vector3.right * -1450;
                imgMoveStaet = transform.position + Vector3.right * 1450;
                break;
            case 1600:
                Debug.Log("1600");
                imgMoveEnd = transform.position + Vector3.right * -1670;
                imgMoveStaet = transform.position + Vector3.right * 1670;
                break;
            case 2048:
                Debug.Log("2048");
                imgMoveEnd = transform.position + Vector3.right * -2248;
                imgMoveStaet = transform.position + Vector3.right * 2248;
                break;
            case 1440:
                Debug.Log("1440");
                imgMoveEnd = transform.position + Vector3.right * -1500;
                imgMoveStaet = transform.position + Vector3.right * 1500;
                break;
            case 1680:
                Debug.Log("1680");
                imgMoveEnd = transform.position + Vector3.right * -1720;
                imgMoveStaet = transform.position + Vector3.right * 1720;
                break;
        }
    }
}
