using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;


namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBase;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreen;


        private void Start()
        {
            HideAll();
            ShowByType(startScreen);            
        }

        private void Scale(Transform t, float size = 1.2f)
        {
            t.localScale = Vector3.one * size;

        }


        public void ShowByType(ScreenType type)
        {
            if (_currentScreen != null) _currentScreen.Hide();

            var nextScreen = screenBase.Find(i => i.screenType == type); //procura todas as variaveis i dentro da variavel type em screenBase (a lista)

            nextScreen.Show();
            _currentScreen = nextScreen;
        }

        public void HideAll()
        {
            screenBase.ForEach(i => i.Hide()); //esconde todos os itens da lista, rodando a função Hide() dentro deles
        }

    }
}
