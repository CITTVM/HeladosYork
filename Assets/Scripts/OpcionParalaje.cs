﻿using UnityEngine;
using System.Collections;

public class OpcionParalaje : MonoBehaviour {

    public bool moveParallax;

    [SerializeField]
    [HideInInspector]
    private Vector3 storedPosition;

    public void SavePosition()
    {
        storedPosition = transform.position;
    }

    public void RestorePosition()
    {
        transform.position = storedPosition;
    }
}