using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqlLite.Services
{
    /// <summary>
    /// Precisamos criar nosso próprio serviço de Navegação
    /// </summary>
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
    }
}
