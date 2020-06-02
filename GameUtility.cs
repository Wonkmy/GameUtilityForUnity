using System;
using UnityEngine;

public class GameUtility : MonoBehaviour
{
    public static float roundToDecimalPlace(float num, int numDecimals)
    {
        float num2 = Mathf.Pow(10f, numDecimals);
        return Mathf.Round(num * num2) / num2;
    }

    public static float distance(Vector3 va, Vector3 vb)
    {
        float num = vb.x - va.x;
        float num2 = vb.y - va.y;
        return Mathf.Sqrt(num * num + num2 * num2);
    }

    public static Vector2 randomPointWithinDonut(Vector2 center, float minRadius, float maxRadius)
    {
        float num = UnityEngine.Random.Range(minRadius, maxRadius);
        float f = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
        float x = center.x + Mathf.Cos(f) * num;
        float y = center.y + Mathf.Sin(f) * num;
        return new Vector2(x, y);
    }

    public static Vector2 randomPointWithinCone(Vector2 center, float minRadius, float maxRadius, float startAngle, float angleRange)
    {
        float num = UnityEngine.Random.Range(minRadius, maxRadius);
        float num2 = UnityEngine.Random.Range(0f, angleRange);
        num2 -= angleRange / 2f;
        float x = center.x + Mathf.Cos((float)Math.PI / 180f * (startAngle + num2)) * num;
        float y = center.y + Mathf.Sin((float)Math.PI / 180f * (startAngle + num2)) * num;
        return new Vector2(x, y);
    }

    public static Vector2 randomPointWithinEllipse(Vector2 center, float maxRadiusX, float maxRadiusY)
    {
        float num = UnityEngine.Random.Range(0f, maxRadiusX);
        float num2 = UnityEngine.Random.Range(0f, maxRadiusY);
        float f = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
        float x = center.x + Mathf.Cos(f) * num;
        float y = center.y + Mathf.Sin(f) * num2;
        return new Vector2(x, y);
    }

    public static float clamp(float value, float min, float max)
    {
        if (value < min)
        {
            return min;
        }
        if (value > max)
        {
            return max;
        }
        return value;
    }

    public static Vector2 clampVector2(float dx, float dy, float max)
    {
        float value = distance(new Vector2(0f, 0f), new Vector2(dx, dy));
        float num = norm(value, 0f, max);
        if (num > 1f)
        {
            dx /= num;
            dy /= num;
        }
        return new Vector2(dx, dy);
    }

    public static float norm(float value, float min, float max)
    {
        if (value == min)
        {
            value = ((!(min < max)) ? (min - 1f) : (min + 1f));
        }
        return (value - min) / (max - min);
    }

    public static float rads(Vector2 va, Vector2 vb)
    {
        return Mathf.Atan2(vb.y - va.y, vb.x - va.x);
    }

    public static float degrees(Vector2 va, Vector2 vb)
    {
        return radsToDegrees(rads(va, vb));
    }

    public static float degreesToRads(float degrees)
    {
        return degrees / 180f * (float)Math.PI;
    }

    public static float radsToDegrees(float radians)
    {
        return radians * 180f / (float)Math.PI;
    }

    public static float circumference(float radius)
    {
        return 2f * radius * (float)Math.PI;
    }

    public static int randomPosOrNeg()
    {
        float f = UnityEngine.Random.Range(0f, 10f) * 0.1f;
        int num = Mathf.RoundToInt(f);
        num += num;
        return num - 1;
    }

    public static int randomDistribution(int min, int max, int iterations)
    {
        int num = 0;
        for (int i = 0; i < iterations; i++)
        {
            num += UnityEngine.Random.Range(min, max + 1);
        }
        return num / iterations;
    }

    public static float varyPitch()
    {
        int num = UnityEngine.Random.Range(-10, 10);
        float num2 = (float)num * 0.01f;
        return 1f + num2;
    }

    public static bool circleIntersect(Vector2 va, float ra, Vector2 vb, float rb)
    {
        float num = distance(va, vb);
        float num2 = ra + rb;
        if (num > num2)
        {
            return false;
        }
        return true;
    }

    public static Vector2 easeTo(Vector2 pos, Vector2 target, float ease)
    {
        float num = target.x - pos.x;
        float num2 = target.y - pos.y;
        if (Mathf.Abs(num) < ease * 0.1f && Mathf.Abs(num2) < ease * 0.1f)
        {
            pos.x = target.x;
            pos.y = target.y;
        }
        else
        {
            pos.x += num * ease;
            pos.y += num2 * ease;
        }
        return pos;
    }

    public static float easeFloatTo(float cur, float target, float ease)
    {
        float num = target - cur;
        cur = ((!((double)Mathf.Abs(num) < 0.1)) ? (cur + num * ease) : target);
        return cur;
    }

    public static Vector2 vectorFromAngle(float angle, float dist)
    {
        float x = Mathf.Cos(degreesToRads(angle)) * dist;
        float y = Mathf.Sin(degreesToRads(angle)) * dist;
        return new Vector2(x, y);
    }
}
