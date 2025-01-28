namespace PcPartsStore.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, Object key) : base($"{name} ({key}) not found")
        {
        }
    }
}
