using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

public class HandManager : MonoBehaviour
{
    [SerializeField] private int _maxHandsize;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private SplineContainer _splineContainer;
    [SerializeField] private Transform _spawnPoint;
    private List<GameObject> _handcards = new();
    private bool _canDraw = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_handcards.Count < _maxHandsize && _canDraw)
        {
            StartCoroutine(DrawCardDelay());
        }
    }

    private IEnumerator DrawCardDelay()
    {
        _canDraw = false;
        DrawCard();
        yield return new WaitForSeconds(5);
        _canDraw = true;
    }

    private void DrawCard()
    {
        if (_handcards.Count >= _maxHandsize) return;
        GameObject g = Instantiate(_cardPrefab, _spawnPoint.position, _spawnPoint.rotation);
        _handcards.Add(g);
        UpdateCardPosition();
    }

    private void UpdateCardPosition()
    {
        if (_handcards.Count == 0) return;
        float cardSpacing = 1f / _maxHandsize;
        float _firstCardPosition = 0.5f - (_handcards.Count -1) * cardSpacing /2 ;
        Spline spline = _splineContainer.Spline;
        for (int i = 0; i < _handcards.Count; i++)
        {
            float p = _firstCardPosition + i * cardSpacing;
            Vector3 splinePostion = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up,Vector3.Cross(up, forward).normalized);
            _handcards[i].transform.DOMove(splinePostion, 0.5f);
            _handcards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }

    }
}
