using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.WindowsManagerSystem
{
    /// <summary>
    /// Implementation of an interface for animations of 
    /// closing/opening windows using unity animations
    /// </summary>
    [RequireComponent(typeof(Animation))]
    public class AnimationWindow : MonoBehaviour, IWindowAnimation
    {
        [SerializeField]
        private AnimationClip _openAnimation;
        [SerializeField]
        private AnimationClip _closeAnimation;

        private Animation _anim;

        private void Awake()
        {
            _anim = GetComponent<Animation>();

            if (_openAnimation != null && !_openAnimation.legacy)
                _openAnimation.legacy = true;
            if (_closeAnimation != null && !_closeAnimation.legacy)
                _closeAnimation.legacy = true;

            bool containsOpened = false;
            bool containsClosed = false;
            foreach (AnimationState state in _anim)
            {
                if (state.clip.name == _openAnimation.name)
                    containsOpened = true;
                if (state.clip.name == _closeAnimation.name)
                    containsClosed = true;
            }

            if (!containsOpened)
                _anim.AddClip(_openAnimation, _openAnimation.name);
            if (!containsClosed)
                _anim.AddClip(_closeAnimation, _closeAnimation.name);
        }

        private void OnEnable()
        {
            Open();
        }

        public void Open()
        {
            _anim.Play(_openAnimation.name);
        }

        public void Close(Action action)
        {
            _anim.Play(_closeAnimation.name);
            StartCoroutine(CloseWindowWithDelay(action));
        }

        private IEnumerator CloseWindowWithDelay(Action action)
        {
            yield return new WaitForSecondsRealtime(_closeAnimation.length);
            action?.Invoke();
        }
    }
}