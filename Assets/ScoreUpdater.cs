using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private Text textField;

    private int _score;

    private void Start()
    {
        textField.text = _score.ToString();
    }

    public void AddScore(int newScore)
    {
        _score += newScore;
        textField.text = _score.ToString();
    }
}
