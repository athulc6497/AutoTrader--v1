using System;
namespace AutoTrader.Models.General;

[AttributeUsage(AttributeTargets.Property)]
public class NonDbMemberAttribute : Attribute;