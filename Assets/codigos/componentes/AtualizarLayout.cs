using UnityEngine.UI;

namespace NhomNhom
{
    public class AtualizarLayout
    {
        public static void atualizar(HorizontalOrVerticalLayoutGroup layoutGroup)
        {
            layoutGroup.CalculateLayoutInputHorizontal();
            layoutGroup.CalculateLayoutInputVertical();
            layoutGroup.SetLayoutHorizontal();
            layoutGroup.SetLayoutVertical();
        }
    }
}

