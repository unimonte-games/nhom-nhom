using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    namespace NhomNhom {

    public class Transformador : MonoBehaviour
    {
        public bool transformar;
        public Transform transformParaTransformar;
        public Space relatividade;
        public float duracaoTranslacao, duracaoRotacao, duracaoEscalonamento;
        public float velTranslacao, velRotacao, velEscalonamento;
        public Vector3 translacao, rotacao, escalonamento;
        public AnimationCurve curvaTranslacao, curvaRotacao, curvaEscalonamento;

        float t_Translacao, t_Rotacao, t_Escalonamento;

        // Update is called once per frame
        void Update()
        {
            if (!transformar || transformParaTransformar == null)
                return;

            float dt = Time.deltaTime;
            float dtVelTr  = dt * velTranslacao;
            float dtVelRot = dt * velRotacao;
            float dtVelEs  = dt * velEscalonamento;

            t_Translacao += dt;
            if (t_Translacao > duracaoTranslacao)
                t_Translacao = 0f;

            t_Rotacao += dt;
            if (t_Rotacao > duracaoRotacao)
                t_Rotacao = 0f;

            t_Escalonamento += dt;
            if (t_Escalonamento > duracaoEscalonamento)
                t_Escalonamento = 0f;


            float e_curvaTranslacao = curvaTranslacao.Evaluate(t_Translacao);
            float e_curvaRotacao = curvaRotacao.Evaluate(t_Rotacao);
            float e_curvaEscalonamento = curvaEscalonamento.Evaluate(t_Escalonamento);

            transformParaTransformar.Translate(translacao * e_curvaTranslacao * dtVelTr, relatividade);
            transformParaTransformar.Rotate(rotacao * e_curvaRotacao * dtVelRot, relatividade);
            transformParaTransformar.localScale += escalonamento * e_curvaEscalonamento * dtVelEs;
        }
    }
}
