using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField] private BaseState _initialState;
    [NonSerialized] public Dictionary<string, object> Variables;

    private Dictionary<Type, Component> _cachedComponents;
    private BaseState _currentState;
    private void Awake()
    {
        Variables = new Dictionary<string, object>();
        _cachedComponents = new Dictionary<Type, Component>();

        _initialState.OnStateEnter(this);
        _currentState = _initialState;
    }

    private void Update()
    {
        _currentState.Execute(this);
    }

    public void ChangeState(BaseState newState)
    {
        Debug.Log($"{_currentState}->{newState}");
        _currentState.OnStateExit(this);
        newState.OnStateEnter(this);
        _currentState = newState;
    }

    public new T GetComponent<T>() where T : Component
    {
        if (_cachedComponents.ContainsKey(typeof(T)))
            return _cachedComponents[typeof(T)] as T;

        if (TryGetComponent<T>(out var component))
            _cachedComponents.Add(typeof(T), component);
        return component;
    }

}
