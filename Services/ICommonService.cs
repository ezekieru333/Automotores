namespace Automotores.Services
{
    public interface ICommonService<Type, TypeInsert, TypeUpdate>
    {
        Task<IEnumerable<Type>> Get();
        Task<Type> GetById(int id);
        Task<Type> Add(TypeInsert insertDto);
        Task<Type> Update(int id, TypeUpdate updateDto);
        Task<Type> Delete(int id);
    }
}
