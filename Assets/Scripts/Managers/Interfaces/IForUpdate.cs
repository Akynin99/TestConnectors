namespace TestConnectors.Managers
{
    // на случай если нужно вызывать Update в не-MonoBehaviour классе/интерфейсе
    public interface IForUpdate
    {
        void Update();
    }
}