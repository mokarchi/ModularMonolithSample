using System;

namespace Estimation.Tool.Shared.DDD.BuildingBlocks;
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class IgnoreMemberAttribute : Attribute
{ }
