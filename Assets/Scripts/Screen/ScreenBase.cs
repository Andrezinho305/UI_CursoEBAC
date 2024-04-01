using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;
using TMPro;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        MyInfoPanel,
        Win,
        Lose,
        Missions,
        Shop

    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typer> listOfPhrases;


        public Image uiBackground;
        //public TextMeshProUGUI uiText;
        public bool startHidden = false;

        [Header("Animations")]
        public float delayBetweenObjects = .5f;
        public float animationDuration = 1f;


        private void Start()
        {
            if(startHidden)
            {
                HideObjects();
                uiBackground.enabled = false;
                //uiText.enabled = false;
            }
        }



        [Button] //ou [NaughtyAttributes.BUtton] caso nao declare a Lib no topo
        //cria um botão no UI da unity que permite executar o código, ao inves de necessitar criar um update com macro do teclado para teste
        public virtual void Show()
        {
            Debug.Log("Show");
            ShowObjects();


        }

        [Button]
        public virtual void Hide()
        {
            Debug.Log("Hide");
            HideObjects();


        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false)); //desliga todos os objetos na lista
            uiBackground.enabled = false;
            //uiText.enabled = false;
        }


        private void ShowObjects()
        {
            for(int o = 0; o < listOfObjects.Count; o++)
            {
                var obj = listOfObjects[o];

                obj.gameObject.SetActive(true); //liga todos os objetos
                obj.DOScale(0, animationDuration).From().SetDelay(o*delayBetweenObjects); //faz com que cresçam do 0 até a escala atual (o from faz ser assim, sem é o contrario) com a duração definida
            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);
            uiBackground.enabled = true;
            //uiText.enabled = true;
        }


        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }

        private void StartType()
        {
            for (int o = 0; o < listOfPhrases.Count; o++)
            {
                listOfPhrases[o].StartType();
            }
        }


    }
}
