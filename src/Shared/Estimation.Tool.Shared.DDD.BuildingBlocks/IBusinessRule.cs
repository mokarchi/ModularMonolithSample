namespace Estimation.Tool.Shared.DDD.BuildingBlocks;
public interface IBusinessRule
{
    string Message { get; }
    bool IsBroken();
}
