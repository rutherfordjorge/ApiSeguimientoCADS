namespace ApiSeguimientoCADS.Api.Models.Settings
{
    public interface IExternalApiSettings
    {
        string Full { get; }

        string AuthToken { get; }

        string Cookie { get; }
    }
}
