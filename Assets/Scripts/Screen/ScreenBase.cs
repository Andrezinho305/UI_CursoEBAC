using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

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

        public bool startHidden = false;

        [Header("Animations")]
        public float delayBetweenObjects = .5f;
        public float animationDuration = 1f;


        private void Start()
        {
            if(startHidden)
            {
                HideObjects();
            }
        }



        [Button] //ou [NaughtyAttributes.BUtton] caso nao declare a Lib no topo
        //cria um bot�o no UI da unity que permite executar o c�digo, ao inves de necessitar criar um update com macro do teclado para teste
        protected virtual void Show()
        {
            Debug.Log("Show");
            ShowObjects();


        }

        [Button]
        protected virtual void Hide()
        {
            Debug.Log("Hide");
            HideObjects();


        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false)); //desliga todos os objetos na lista
        }


        private void ShowObjects()
        {
            for(int o = 0; o < listOfObjects.Count; o++)
            {
                var obj = listOfObjects[o];

                obj.gameObject.SetActive(true); //liga todos os objetos
                obj.DOScale(0, animationDuration).From().SetDelay(o*delayBetweenObjects); //faz com que cres�am do 0 at� a escala atual (o from faz ser assim, sem � o contrario) com a dura��o definida
            }


        }


        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }


    }
}
