// <copyright file="Helper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class Helper
    {
        // HttpClient estático compartido para evitar socket exhaustion
        private static readonly HttpClient _sharedHttpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(10),
        };

        /// <summary>
        /// UrlExistsAsync
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>true o false</returns>
        public static async Task<bool> UrlExistsAsync(Uri url)
        {
            try
            {
                HttpResponseMessage response = await _sharedHttpClient.GetAsync(url).ConfigureAwait(false);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
            catch (TaskCanceledException)
            {
                // Timeout
                return false;
            }
            catch (OperationCanceledException)
            {
                // Cancelación
                return false;
            }
        }

        /// <summary>
        /// NormalizarRuta
        /// </summary>
        /// <param name="ruta">ruta</param>
        /// <returns>url</returns>
        public static string NormalizarRuta(string? ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
            {
                return "-";
            }

            return ruta.Replace("/", "|", StringComparison.Ordinal);
        }
    }
}