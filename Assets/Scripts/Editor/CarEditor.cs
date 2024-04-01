using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; //necessario para uso de funções de edição

[CustomEditor(typeof(car))] //permite ser um editor do scrip "car"
public class CarEditor : Editor //nota-se o uso de Editor ao inves de monobehaivour
    //permite editar a visualização da unity em si
{
    public override void OnInspectorGUI() //edita a interface do scrip em um objeto
    {
        //base.OnInspectorGUI();

        car myTarget = (car)target; //recebe o objeto do carro/script que o editor tem e define como alvo da edição

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField("Car Model", myTarget.carPrefab, typeof(GameObject), true);


        myTarget.speed = EditorGUILayout.IntField("Velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Marcha", myTarget.gear);
        //para a variavel speed do car -> cria um item editavel de Int, com o nome x, permitindo a edição da variavel

        EditorGUILayout.LabelField("Velocidade Total", myTarget.TotalSpeed.ToString());
        //cria uma area na interface que aparece em texto o valor calculado da variavel como uma string/texto
        //atualiza automaticamente

        EditorGUILayout.HelpBox("Calcule a velocidade total do carro!", MessageType.Info);
        //cria uma box de texto no editor, podendo ser como mensagem de ajuda ou erro

        if(myTarget.TotalSpeed>=200)
        {
            EditorGUILayout.HelpBox("Acima do limite", MessageType.Warning); //warning eh amarelo, nao critico
        }

        if (myTarget.TotalSpeed >= 400)
        {
            EditorGUILayout.HelpBox("Acima do limite", MessageType.Error); //erro é em vermelho, critico
        }


     
        if(GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }
    }
}
