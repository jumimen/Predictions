namespace Predictions.Frontend.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<object>> DeleteAsync<T>(string url);

        Task<HttpResponseWrapper<T>> GetAsync<T>(string url);

        Task<HttpResponseWrapper<Object>> PostAsync<T>(string url, T model);

        Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model);

        Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model);

        Task<HttpResponseWrapper<TActionResponse>> PutAsync<T, TActionResponse>(string url, T model);
    }
}