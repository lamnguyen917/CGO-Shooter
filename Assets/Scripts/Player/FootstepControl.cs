using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepControl : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private AudioClip[] footstepSfx;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayLeftFootstep();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayRightFootstep();
        }
    }

    public void PlayLeftFootstep()
    {
        var clip = GetFootStepClip();
        AudioSource.PlayClipAtPoint(clip, leftFoot.position);
    }

    public void PlayRightFootstep()
    {
        var clip = GetFootStepClip();
        AudioSource.PlayClipAtPoint(clip, rightFoot.position);
    }

    AudioClip GetFootStepClip()
    {
        var index = Random.Range(0, footstepSfx.Length);
        return footstepSfx[index];
    }
}
