public interface IInitializable {
    void Init(object[] initArgs);
    System.Type[] InitArgumentTypes();
}
