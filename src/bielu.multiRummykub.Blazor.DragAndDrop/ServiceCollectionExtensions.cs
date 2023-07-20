using Microsoft.Extensions.DependencyInjection;

namespace bielu.multiRummykub.Blazor.DragAndDrop
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorDragDrop(this IServiceCollection services)
        {
            return services.AddScoped(typeof(DragDropService<>));
        }
    }
}
