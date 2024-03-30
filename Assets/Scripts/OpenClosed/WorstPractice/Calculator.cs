using UnityEngine;

namespace OpenClosed.WorstPractice
{
    public class Calculator
    {
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.width * rectangle.height;
        }

        public float GetCircleArea(Circle circle)
        {
            return circle.radius * circle.radius * Mathf.PI;
        }

        public float GetPentagonArea(Pentagon pentagon)
        {
            // 오각형 넓이 구하는 코드
            return 0;
        }
    }
}