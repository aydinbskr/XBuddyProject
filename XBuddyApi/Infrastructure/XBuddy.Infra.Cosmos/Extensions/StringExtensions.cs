using Microsoft.Azure.Cosmos;


namespace XBuddy.Infra.Cosmos.Extensions
{

    internal static class StringExtensions
    {
        internal static PartitionKey ToPartitionKey(this string id)
        {
            return new PartitionKey(id);
        }
    }
}
