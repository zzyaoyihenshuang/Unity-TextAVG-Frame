using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Duo1J
{
    [RequireComponent(typeof(AVGController))]
    public class AVGFrame : MonoBehaviour, Duo1JAVG
    {
        private AVGController controller;

        private Duo1JLoader loader;
        private Duo1JAnimation anim;
        private Duo1JAround around;
        private Duo1JAction action;
        private Duo1JInput input;

        private List<AVGModel> modelList;

        public bool autoStart = true;

        public string imageUrlPrefix = "Image";
        public string audioUrlPrefix = "Audio";

        public TextAsset textAsset;

        [Header("UI Component")]
        public Canvas canvas;
        public Text text;
        public Text nameText;
        public Image characterImage;
        public Image backgroundImage;
        public AudioSource characterVoice;
        public AudioSource backgroundMusic;
        [Header("Choose Button")]
        public GameObject buttonPanel;
        public Button[] buttons;

        //实现接口后挂在在此脚本同一物体后自动注入，否则使用默认
        public Duo1JAnimation Anim { set { anim = value; controller.Anim = anim; } }
        public Duo1JAround Around { set { around = value; controller.Around = around; } }
        public Duo1JAction Action { set { action = value; controller.Action = action; } }
        public Duo1JLoader Loader { set { loader = value; controller.Loader = loader; } }
        public Duo1JInput Input0 { set { input = value; controller.Input0 = input; } }

        private bool isReady = false;
        private Coroutine startCoro = null;

        private void Awake()
        {
            ComponentsInit();
        }

        private void Start()
        {
            if (loader.Analysis(out modelList, textAsset))
            {
                controller.ModelList = modelList;
                isReady = true;
                if (autoStart)
                {
                    Begin();
                }
            }
            else
            {
                Debug.LogError("TextAsset analysis failed!");
            }
        }

        private IEnumerator BeginCoro()
        {
            while (!isReady)
            {
                yield return null;
            }
            yield return null;
            controller.Begin();
        }

        private void ComponentsInit()
        {
            controller = GetComponent<AVGController>();
            if (controller == null)
            {
                controller = gameObject.AddComponent<AVGController>();
            }
            controller.SetPrefix(imageUrlPrefix, audioUrlPrefix);
            controller.InitUIComponent(canvas, nameText, text, characterImage, backgroundImage,
                characterVoice, backgroundMusic);
            controller.SetChooseButton(buttonPanel, buttons);

            Loader = (Duo1JLoader)ComponentCheck<Duo1JLoader>(loader, typeof(AVGLoader));

            Anim = (Duo1JAnimation)ComponentCheck<Duo1JAnimation>(anim, typeof(AVGAnimationDefault));

            Action = (Duo1JAction)ComponentCheck<Duo1JAction>(action, typeof(AVGActionDefault));

            Around = (Duo1JAround)ComponentCheck<Duo1JAround>(around, typeof(AVGAroundDefault));

            Input0 = (Duo1JInput)ComponentCheck<Duo1JInput>(input, null, true);
        }

        private object ComponentCheck<T>(T obj, Type defaultImpl = null, bool defaultNull = false)
        {
            object o = obj;
            if ((o = GetComponent<T>()) == null)
            {
                if (defaultNull)
                {
                    return default(T);
                }
                if (defaultImpl == null)
                {
                    Debug.Log("ComponentCheck Error ~ The implement of T is null at ComponentCheck<T>() at AVGFrame.cs");
                    return default(T);
                }
                o = gameObject.AddComponent(defaultImpl);
            }
            return o;
        }

        //Controller
        public void Begin()
        {
            if (startCoro == null)
            {
                if (!isReady)
                {
                    StartCoroutine(BeginCoro());
                    return;
                }
                controller.Begin();
            }
        }

        public void AVGStop() { controller.Stop(); }

        public void AVGContinue() { controller.Continue(); }

        public List<TextModel> GetPreviousText(int length) { return controller.GetPreviousText(length); }

        public void Restart() { controller.Begin(); }
    }
}