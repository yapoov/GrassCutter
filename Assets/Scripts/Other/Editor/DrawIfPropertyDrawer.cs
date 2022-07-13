using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DrawIfAttribute))]
public class DrawIfPropertyDrawer : PropertyDrawer {
    DrawIfAttribute attr;
    SerializedProperty comparedField;
    private float propertyHeight;

    bool IsNumericType(Type t) {
        return IsInt(t) || IsLong(t) || IsFloat(t) || IsDouble(t);
    }

    bool IsInt(Type t) {
        return t == typeof(sbyte) || t == typeof(byte) || t == typeof(short) || t == typeof(ushort) || t == typeof(int) || t == typeof(uint);
    }

    bool IsLong(Type t) {
        return t == typeof(long) || t == typeof(ulong);
    }

    bool IsFloat(Type t) {
        return t == typeof(float);
    }

    bool IsDouble(Type t) {
        return t == typeof(double) || t == typeof(decimal);
    }

    object GetValue(Type t, SerializedProperty sp) {
        object res = null;
        if (t == typeof(AnimationCurve))
            res = sp.animationCurveValue;
        else if (t == typeof(bool))
            res = sp.boolValue;
        else if (t == typeof(BoundsInt))
            res = sp.boundsIntValue;
        else if (t == typeof(Bounds))
            res = sp.boundsValue;
        else if (t == typeof(Color))
            res = sp.colorValue;
        else if (IsDouble(t))
            res = sp.doubleValue;
        else if (IsFloat(t))
            res = sp.floatValue;
        else if (IsInt(t)
        || t == typeof(char))
            res = sp.intValue;
        else if (IsLong(t))
            res = sp.longValue;
        else if (t == typeof(object))
            res = sp.objectReferenceValue;
        else if (t == typeof(Quaternion))
            res = sp.quaternionValue;
        else if (t == typeof(RectInt))
            res = sp.rectIntValue;
        else if (t == typeof(Rect))
            res = sp.rectValue;
        else if (t == typeof(string))
            res = sp.stringValue;
        else if (t == typeof(Vector2Int))
            res = sp.vector2IntValue;
        else if (t == typeof(Vector2))
            res = sp.vector2Value;
        else if (t == typeof(Vector3Int))
            res = sp.vector3IntValue;
        else if (t == typeof(Vector3))
            res = sp.vector3Value;
        else if (t == typeof(Vector4))
            res = sp.vector4Value;
        return res;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return propertyHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        attr = attribute as DrawIfAttribute;
        object value = GetValue(attr.type, property.serializedObject.FindProperty(attr.name));
        bool active = false;
        if (attr.comparisonType == ComparisonType.Or) {
            for (int i = 0; i < attr.values.Length; i++)
                if (value.Equals(attr.values[i])) {
                    active = true;
                    break;
                }
        } else if (attr.comparisonType == ComparisonType.Equals) {
            if (value.Equals(attr.value))
                active = true;
        } else if (attr.comparisonType == ComparisonType.NotEqual) {
            if (!value.Equals(attr.value))
                active = true;
        } else if (IsNumericType(attr.type)) {
            double a = 0, b = 0;
            if (IsInt(attr.type)) {
                a = (int)value;
                b = (int)attr.value;
            } else if (IsLong(attr.type)) {
                a = (long)value;
                b = (long)attr.value;
            } else if (IsFloat(attr.type)) {
                a = (float)value;
                b = (float)attr.value;
            } else if (IsDouble(attr.type)) {
                a = (double)value;
                b = (double)attr.value;
            }
            switch (attr.comparisonType) {
                case ComparisonType.GreaterThan:
                    if (a > b) active = true;
                    break;
                case ComparisonType.SmallerThan:
                    if (a < b) active = true;
                    break;
                case ComparisonType.SmallerOrEqual:
                    if (a <= b) active = true;
                    break;
                case ComparisonType.GreaterOrEqual:
                    if (a >= b) active = true;
                    break;
            }
        }
        propertyHeight = base.GetPropertyHeight(property, label);
        if (active) {
            EditorGUI.PropertyField(position, property);
        } else {
            if (attr.disablingType == DisablingType.ReadOnly) {
                GUI.enabled = false;
                EditorGUI.PropertyField(position, property);
                GUI.enabled = true;
            } else {
                propertyHeight = 0f;
            }
        }
    }
}