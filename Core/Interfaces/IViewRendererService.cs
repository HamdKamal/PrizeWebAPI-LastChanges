namespace Core.Interfaces
{
    public interface IViewRendererService
    {
        Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model);
    }
}
