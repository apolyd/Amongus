﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        Debug.Log("akoumpw");
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
        Debug.Log("den akoumpw");
    }
}