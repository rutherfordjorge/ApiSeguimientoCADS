namespace ApiSeguimientoCADS.Api.Models.Responses
{
    using System.Collections.Generic;

    public interface IExternalServiceResponse<out TItem>
    {
        string Status { get; }

        string Comentario { get; }

        IReadOnlyList<TItem>? Data { get; }
    }
}
