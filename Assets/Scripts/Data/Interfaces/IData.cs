namespace RollerBall.Data
{
    public interface IData<T>
    {
        void Save(T data, string path);
        T Load(string path);
    }

}
