using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class GeneralUtil
{

#if UNITY_EDITOR //cria uma região que só funciona no editor


    [UnityEditor.MenuItem("EBAC/Test")] //usar desse jeito nao necessita declarar a lib no topo do code com o "using"
    //cria uma barra de ferramentas no topo da tela da unity
    //esse tipo de código da erro se for compilado normalmente, precisa estar em um código/pasta especializada de Editor -> ver code CarEditor
    public static void Teste()
    {
        Debug.Log("teste");
    }

    [UnityEditor.MenuItem("EBAC/Test2 %g")] //%g faz com que crie uma hotkey para acessar essa função na unity -> no caso vira CTRL+G
    //ppt Módulo27_aula 5_menus em barras de ferramenta mostra outros comandos
    public static void Teste2()
    {
        Debug.Log("teste2");
    }




#endif


    public static void Scale(this Transform t, float size = 1.2f) //this, quando é função static permite a função ser usada em outros scripts
    {
        t.localScale = Vector3.one * size;
    }



    // o T referencia qualquer tipo de item/script na lista -> ex: public static Screens.ScreenBase GetRandom<Screens.ScreenBase>
    // torna mais flexivel o código, pode ser acessado por qq lugar
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];

    }

    //randomiza a lista exceto um item declarado quando a função é puxada
    public static T GetRandomButNotSame<T>(this List<T> list, T unique)
    {
        if (list.Count == 1) return unique;

        int randomIndex = Random.Range(0, list.Count);
        
        return list[randomIndex];

    }




}
