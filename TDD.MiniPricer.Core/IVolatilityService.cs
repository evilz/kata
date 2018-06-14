namespace TDD.MiniPricer.Core
{
    public interface IVolatilityService
    {
        VolatilityVariation NextVariation();
    }
}