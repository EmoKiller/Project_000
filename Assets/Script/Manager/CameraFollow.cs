using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    [Header("Shaker")]
    [SerializeField] private Vector3 _positonStrength;
    [SerializeField] private float timeDurationPositonStrength;
    [SerializeField] private Vector3 _rotationStrength;
    [SerializeField] private float timeDurationRotationStrength;

    [Header("Component System")]
    [SerializeField] Camera _camera;
    [SerializeField] private Transform target;
    [SerializeField] private float smooth;
    [SerializeField] private Vector3 offset;
    private Vector3 vecref = Vector3.zero;
    public float MouseX;
    public float MouseY;
    float mouseX
    {
        get { return MouseX += Input.GetAxis("Mouse X"); }
    } 
    float mouseY 
    {
        get { return MouseY -= Input.GetAxis("Mouse Y"); }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref vecref, smooth);
        transform.eulerAngles = new Vector3(Mathf.Clamp(mouseY,-89,89), mouseX, 0);
    }
    public void Init()
    {
        TargetPlayer();
    }
    private void ShakeCamera()
    {
        _camera.transform.DOComplete();
        _camera.transform.DOShakePosition(timeDurationPositonStrength, _positonStrength);
        _camera.transform.DOShakeRotation(timeDurationRotationStrength, _rotationStrength);
    }
    //private void OnBossDeadth()
    //{
    //    CameraFocus();
    //    DOTween.To(() => Time.timeScale, x => Time.timeScale = 1, 0.1f, 0.4f).SetEase(Ease.InQuad).SetUpdate(true).OnComplete(() => { Time.timeScale = 1; });
    //    this.DelayCall(2, () => { CameraDefault(); });
    //}
    
    private void CameraChangeTarget(Transform target)
    {
        this.target = target;
    }
    private void TargetPlayer()
    {
        //target = (Transform)EventDispatcher.Call(Player.Script.Player, Events.PlayerDirection);
    }
    private void ChangeColorBackGround(Color32 color)
    {
        _camera.backgroundColor = color;
    }
    private void SetSmooth(float value)
    {
        smooth = value;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position +new Vector3(transform.forward.x,0, transform.forward.z).normalized);

    }
}
