using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
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
    private void Awake()
    {
        //EventDispatcher.Addlistener<Color32>(Script.CameraFollow, Events.CameraChangeColorBackGround, ChangeColorBackGround);
        //EventDispatcher.Addlistener<Transform>(Script.CameraFollow, Events.CameraChangeTarget, CameraChangeTarget);
        //EventDispatcher.Addlistener(Script.CameraFollow, Events.CameraTargetPlayer, TargetPlayer);
        //EventDispatcher.Addlistener(Script.CameraFollow, Events.CameraDefault, CameraDefault);
        //EventDispatcher.Addlistener(Script.CameraFollow, Events.CameraFocus, CameraFocus);
        //EventDispatcher.Addlistener(Script.CameraFollow, Events.OnAttackHitEnemy, VibrateCamera);
        //ObseverConstants.OnBossDeath.AddListener(OnBossDeadth);
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
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref vecref, smooth);
    }
    private void OnBossDeadth()
    {
        CameraFocus();
        DOTween.To(() => Time.timeScale, x => Time.timeScale = 1, 0.1f, 0.4f).SetEase(Ease.InQuad).SetUpdate(true).OnComplete(() => { Time.timeScale = 1; });
        this.DelayCall(2, () => { CameraDefault(); });
    }
    private void CameraDefault()
    {
        offset = new Vector3(0, 22, -28);
        transform.eulerAngles = new Vector3(38, 0, 0);
        SetSmooth(0.4f);
    }
    private void CameraFocus()
    {
        SetSmooth(0.6f);
        offset = new Vector3(0, 6, -8.5f);
        transform.eulerAngles = new Vector3(30, 0, 0);
    }
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
}
