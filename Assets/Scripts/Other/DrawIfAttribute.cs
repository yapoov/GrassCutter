using System;
using System.Collections.Generic;
using UnityEngine;

public enum ComparisonType { Equals, NotEqual, GreaterThan, SmallerThan, SmallerOrEqual, GreaterOrEqual, Or }
public enum DisablingType { ReadOnly, DontDraw }

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class DrawIfAttribute : PropertyAttribute {
    public string name;
    public Type type;
    public object value;
    public ComparisonType comparisonType;
    public DisablingType disablingType;
    public object[] values;
    public DrawIfAttribute(string name, Type type, object value,
        ComparisonType comparisonType = ComparisonType.Equals, DisablingType disablingType = DisablingType.DontDraw) {
        this.name = name;
        this.type = type;
        this.value = value;
        this.comparisonType = comparisonType;
        this.disablingType = disablingType;
    }
    public DrawIfAttribute(string name, Type type, params object[] values) {
        this.name = name;
        this.type = type;
        this.comparisonType = ComparisonType.Or;
        this.disablingType = DisablingType.DontDraw;
        this.values = values;
    }
}