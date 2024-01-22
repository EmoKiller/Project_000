using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class SlashCollider : MonoBehaviour
{
    [SerializeField] BoxCollider BoxCollider;
    protected UnityAction<CharacterBrain> OnAttack;
    public void Initialized()
    {
        BoxCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnAttack?.Invoke(other.GetComponent<CharacterBrain>());
    }
    public void AddActionAttack(UnityAction<CharacterBrain> OnAttack)
    {
        this.OnAttack = OnAttack;
    }
    public void SetActiveSlash(bool set)
    {
        gameObject.SetActive(set);
    }
    public void SetBoxSize(Vector3 vector)
    {
        BoxCollider.size = vector;
    }
}
