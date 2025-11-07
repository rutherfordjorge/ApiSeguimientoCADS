// <copyright file="FakeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Controllers
{
    using ApiSeguimientoCADS.Api.Handlers.Interfaces;
    using ApiSeguimientoCADS.Api.Models.Common;
    using ApiSeguimientoCADS.Api.Models.DTOs.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Enums;
    using ApiSeguimientoCADS.Api.Models.Requests.Cads;
    using ApiSeguimientoCADS.Api.Models.Requests.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Responses.Siniestros;
    using ApiSeguimientoCADS.Api.Models.Settings.ExternalApis;
    using ApiSeguimientoCADS.Api.Security.Logger;
    using ApiSeguimientoCADS.Api.Utilities;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Swashbuckle.AspNetCore.Annotations;
    using System;
    using System.Globalization;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Controlador de prueba para la versión 0 de la API.
    /// </summary>
    [ApiController]
    [ApiVersion("0.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FakeController : ControllerBase
    {
        private readonly IAppLogger<FakeController> _logger;
        private readonly IUsersHandler _handler;
        private readonly EPSiniestroPorAseguradoSettings _settings;
        private readonly string _getsiniestrosporasegurado =
        @"[
            {
                ""RutCorredor"": ""78951950-1"",
                ""NumeroSiniestro"": ""10513666"",
                ""FechaSiniestro"": ""2025-4-8"",
                ""FechaDenuncia"": ""2025-10-24"",
                ""CodigoEstado"": ""A"",
                ""Estado"": ""Aceptado"",
                ""CodigoEtapa"": ""02"",
                ""Etapa"": ""En Proceso Liquidación"",
                ""Ramo"": ""VP"",
                ""NumeroPoliza"": ""B-P-00007127462"",
                ""NumeroItem"": ""0000001"",
                ""TipoDano"": ""Propios""
            },
            {
                ""RutCorredor"": ""78951950-1"",
                ""NumeroSiniestro"": ""10513666"",
                ""FechaSiniestro"": ""2025-4-8"",
                ""FechaDenuncia"": ""2025-10-24"",
                ""CodigoEstado"": ""A"",
                ""Estado"": ""Aceptado"",
                ""CodigoEtapa"": ""02"",
                ""Etapa"": ""En Proceso Liquidación"",
                ""Ramo"": ""VP"",
                ""NumeroPoliza"": ""B-P-00007127462"",
                ""NumeroItem"": ""0000001"",
                ""TipoDano"": ""Propios""
            },
            {
                ""RutCorredor"": ""78951950-1"",
                ""NumeroSiniestro"": ""10513667"",
                ""FechaSiniestro"": ""2024-10-9"",
                ""FechaDenuncia"": ""2025-10-24"",
                ""CodigoEstado"": ""A"",
                ""Estado"": ""Aceptado"",
                ""CodigoEtapa"": ""02"",
                ""Etapa"": ""En Proceso Liquidación"",
                ""Ramo"": ""VP"",
                ""NumeroPoliza"": ""B-P-00007127462"",
                ""NumeroItem"": ""0000001"",
                ""TipoDano"": ""Propios""
            },
            {
                ""RutCorredor"": ""78951950-1"",
                ""NumeroSiniestro"": ""10513667"",
                ""FechaSiniestro"": ""2024-10-9"",
                ""FechaDenuncia"": ""2025-10-24"",
                ""CodigoEstado"": ""A"",
                ""Estado"": ""Aceptado"",
                ""CodigoEtapa"": ""02"",
                ""Etapa"": ""En Proceso Liquidación"",
                ""Ramo"": ""VP"",
                ""NumeroPoliza"": ""B-P-00007127462"",
                ""NumeroItem"": ""0000001"",
                ""TipoDano"": ""Propios""
            }
        ]";

        private readonly string _siniestroDataJson =
        @"[
            {
                ""CODIGOEMPRESA"": ""01"",
                ""NOMBREEMPRESA"": ""BCI SEGUROS"",
                ""NUMEROSINIESTRO"": ""10513666"",
                ""CODIGOSUCURSAL"": ""B"",
                ""CODIGOTIPODOCUMENTO"": ""P"",
                ""NUMERODOCUMENTO"": ""7127462"",
                ""NUMEROITEM"": ""1"",
                ""NUMERORIESGO"": ""6"",
                ""CODIGORAMO"": ""VP"",
                ""RUTLIQUIDADOR"": ""12124066"",
                ""NOMBRELIQUIDADOR"": ""FRED ALTAMIRANO VASQUEZ"",
                ""ZONALIQUIDADOR"": """",
                ""RUTTALLER"": ""76244270"",
                ""LOCALTALLER"": ""1"",
                ""NOMBRETALLER"": ""AUTOMOTRIZ DEPE"",
                ""DIRECCIONTALLER"": ""RAMON FREIRE 123"",
                ""FECENTRADATALLER"": ""null"",
                ""FEFECSALIDATALLER"": ""null"",
                ""DIASENTALLER"": """",
                ""FECHAACTESTADOEQEMS"": ""28/10/25"",
                ""ESTADO_SINIESTRO"": ""A - ACEPTADO"",
                ""ETAPA_SINIESTRO"": ""02 - LIQUIDACION"",
                ""RUTASEGURADO"": ""17863159"",
                ""FECHAINGRESOTALLER"": """",
                ""PATENTE"": ""JTKK18"",
                ""JEFEZONAL"": """",
                ""CLASIFICACIONTALLER"": ""R"",
                ""FECHADENUNCIO"": ""2025-10-24"",
                ""CODIGOETAPARIESGO"": ""02"",
                ""DESCRIPCIONETAPARIESGO"": ""EN LIQUIDACION"",
                ""TIPOLIQUIDADOR"": ""D"",
                ""GLOSATIPOLIQUIDADOR"": ""DIRECTO"",
                ""CODIGOCOBERTURA"": ""QA"",
                ""DESCRIPCIONCOBERTURA"": ""DAÑOS MATERIALES""
            },
            {
                ""CODIGOEMPRESA"": ""01"",
                ""NOMBREEMPRESA"": ""BCI SEGUROS"",
                ""NUMEROSINIESTRO"": ""10513667"",
                ""CODIGOSUCURSAL"": ""B"",
                ""CODIGOTIPODOCUMENTO"": ""P"",
                ""NUMERODOCUMENTO"": ""7127462"",
                ""NUMEROITEM"": ""1"",
                ""NUMERORIESGO"": ""6"",
                ""CODIGORAMO"": ""VP"",
                ""RUTLIQUIDADOR"": ""12124066"",
                ""NOMBRELIQUIDADOR"": ""FRED ALTAMIRANO VASQUEZ"",
                ""ZONALIQUIDADOR"": """",
                ""RUTTALLER"": ""76244270"",
                ""LOCALTALLER"": ""1"",
                ""NOMBRETALLER"": ""AUTOMOTRIZ DEPE"",
                ""DIRECCIONTALLER"": ""RAMON FREIRE 123"",
                ""FECENTRADATALLER"": ""null"",
                ""FEFECSALIDATALLER"": ""null"",
                ""DIASENTALLER"": """",
                ""FECHAACTESTADOEQEMS"": ""28/10/25"",
                ""ESTADO_SINIESTRO"": ""A - ACEPTADO"",
                ""ETAPA_SINIESTRO"": ""02 - LIQUIDACION"",
                ""RUTASEGURADO"": ""17863159"",
                ""FECHAINGRESOTALLER"": """",
                ""PATENTE"": ""JTKK18"",
                ""JEFEZONAL"": """",
                ""CLASIFICACIONTALLER"": ""R"",
                ""FECHADENUNCIO"": ""2025-10-24"",
                ""CODIGOETAPARIESGO"": ""02"",
                ""DESCRIPCIONETAPARIESGO"": ""EN LIQUIDACION"",
                ""TIPOLIQUIDADOR"": ""D"",
                ""GLOSATIPOLIQUIDADOR"": ""DIRECTO"",
                ""CODIGOCOBERTURA"": ""QA"",
                ""DESCRIPCIONCOBERTURA"": ""DAÑOS MATERIALES""
            }
        ]";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FakeController"/>.
        /// </summary>
        /// <param name="logger">Logger de la aplicación.</param>
        /// <param name="handler">handler de la aplicación.</param>
        /// <param name="settings">settings de la aplicación.</param>
        public FakeController(IAppLogger<FakeController> logger, IUsersHandler handler, IOptions<EPSiniestroPorAseguradoSettings> settings)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
            this._settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <summary>
        /// Endpoint de prueba para validación de acceso (retorna datos mock).
        /// </summary>
        /// <param name="rutTitular">Rut</param>
        /// <param name="passTitular">Pass</param>
        /// <returns>Datos de prueba.</returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginDirecto(string rutTitular, string passTitular)
        {
            // Log de inicio con datos enmascarados
            var logInput = new
            {
                rutTitular,
            };

            this._logger.Info($"{this.GetType().Name} - [POST] /LoginDirecto - Request recibido");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);
            try
            {
                if (rutTitular == null)
                {
                    this._logger.LogError($"{this.GetType().Name} - rutTitular es nulo");
                    return this.BadRequest(new { Message = "rutTitular no puede ser nulo." });
                }

                if (passTitular == null)
                {
                    this._logger.LogError($"{this.GetType().Name} - passTitular es nulo");
                    return this.BadRequest(new { Message = "passTitular no puede ser nulo." });
                }

                this._logger.Debug($"{this.GetType().Name} - Request validado, delegando al handler");
                string urlFrontend = await this.LoginFake(rutTitular.Trim(), passTitular.Trim()).ConfigureAwait(false);
                this._logger.Info($"{this.GetType().Name} - URL generada exitosamente. Redirigiendo al frontend");
                await Task.CompletedTask.ConfigureAwait(false);
                return this.Content(urlFrontend, "text/plain");
            }
            catch (ArgumentException ex)
            {
                this._logger.LogError(ex);
                return this.BadRequest(new { Message = ex.Message, });
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex);
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message, });
            }
            finally
            {
                if (stopwatch != null && processId != Guid.Empty)
                {
                    this._logger.EndProcess(processId, stopwatch);
                }
            }
        }

        /// <summary>
        /// Endpoint de prueba para validación de acceso (retorna datos mock).
        /// </summary>
        /// <param name="request">Datos de la solicitud externa.</param>
        /// <returns>Datos de prueba.</returns>
        [HttpPost("[action]")]
        [SwaggerIgnore]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Validate([FromForm] ValidateAccessRequest request)
        {
            // Log de inicio con datos enmascarados
            var logInput = new
            {
                RutTitular = request?.RutTitular != null ? request.RutTitular : "null",
                Origen = request?.Origen.ToString() ?? "null",
                Rol = request?.Rol.ToString() ?? "null",
            };

            this._logger.Info($"{this.GetType().Name} - [POST] /Validate - Request recibido");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);
            try
            {
                if (request == null)
                {
                    this._logger.LogError($"{this.GetType().Name} - Request es nulo");
                    return this.BadRequest(new { Message = "La solicitud no puede ser nula." });
                }

                this._logger.Debug($"{this.GetType().Name} - Request validado, delegando al handler");
                var urlFrontend = this._siniestroDataJson;

                this._logger.Info($"{this.GetType().Name} - URL generada exitosamente. Redirigiendo al frontend");
                await Task.CompletedTask.ConfigureAwait(false);
                return this.Redirect(urlFrontend);
            }
            catch (ArgumentException ex)
            {
                this._logger.LogError(ex);
                return this.BadRequest(new { Message = ex.Message, });
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex);
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message, });
            }
            finally
            {
                if (stopwatch != null && processId != Guid.Empty)
                {
                    this._logger.EndProcess(processId, stopwatch);
                }
            }
        }

        /// <summary>
        /// Endpoint para obtener el detalle de siniestros por asegurado
        /// </summary>
        /// <param name="rut">RUT del asegurado.</param>
        /// <returns>Detalle de siniestros del asegurado.</returns>
        [HttpGet("siniestros/{rut}/detalle")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SiniestrosResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetSiniestrosPorAsegurado([FromRoute] string rut)
        {
            // Log de inicio con datos enmascarados
            var logInput = new
            {
                RutAsegurado = !string.IsNullOrWhiteSpace(rut) ? rut : "null",
            };

            this._logger.Info($"{this.GetType().FullName} - [GET] /siniestros/{{rut}}/detalle - Request recibido");
            var (processId, stopwatch) = this._logger.StartProcess(logInput);
            try
            {
                if (string.IsNullOrWhiteSpace(rut))
                {
                    this._logger.LogError($"{this.GetType().FullName} - Request es nulo");
                    return this.BadRequest(new FrontResponse<object>
                    {
                        Success = false,
                        Message = "El RUT del asegurado es obligatorio.",
                        Data = null,
                        ErrorCode = "VALIDATION_ERROR",
                        Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                    });
                }

                bool esValido = RutValidator.Validar(rut);

                if (!esValido)
                {
                    this._logger.LogError($"{this.GetType().FullName} - RUT inválido recibido: {rut}");
                    return this.BadRequest(new FrontResponse<object>
                    {
                        Success = false,
                        Message = "El RUT proporcionado no es válido.",
                        Data = null,
                        ErrorCode = "INVALID_RUT",
                        Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                    });
                }

                string rutLimpio = RutValidator.ObtenerNumeroRut(rut);
                this._logger.Debug($"{this.GetType().FullName} - Request validado, delegando al handler");

                // Parsear datos JSON de siniestros
                var getsiniestrosporaseguradoArray = JsonSerializer.Deserialize<JsonElement>(this._getsiniestrosporasegurado);
                var siniestrosList = this.ParseSiniestrosFromJson(getsiniestrosporaseguradoArray);

                SiniestrosResponse lstSiniestrosResponse = new() { Data = siniestrosList };

                // Procesar siniestros VP
                var lstSiniestrosDataResponse = this.ProcessVPSiniestros(lstSiniestrosResponse.Data);

                // Crear DTOs con detalles
                var siniestrosArray = JsonSerializer.Deserialize<JsonElement>(this._siniestroDataJson);
                var siniestrosDataDTO = this.CreateSiniestrosDTO(lstSiniestrosDataResponse, siniestrosArray);

                var response = new FrontResponse<SiniestrosDataDto>
                {
                    Success = true,
                    Message = $"{rut}: Siniestros obtenidos exitosamente",
                    Data = siniestrosDataDTO,
                    Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                };
                await Task.CompletedTask.ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (ArgumentException ex)
            {
                this._logger.LogError(ex);
                return this.BadRequest(new FrontResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null,
                    ErrorCode = "VALIDATION_ERROR",
                    Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                });
            }
            catch (JsonException ex)
            {
                this._logger.LogError(ex);
                return this.BadRequest(new FrontResponse<object>
                {
                    Success = false,
                    Message = "Error al procesar datos JSON: estructura inválida o incompleta.",
                    Data = null,
                    ErrorCode = "JSON_ERROR",
                    Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                });
            }
            catch (InvalidOperationException ex)
            {
                this._logger.LogError(ex);
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new FrontResponse<object>
                    {
                        Success = false,
                        Message = "Ha ocurrido un error inesperado",
                        Data = null,
                        ErrorCode = "INTERNAL_ERROR",
                        Timestamp = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                    });
            }
            finally
            {
                if (stopwatch != null && processId != Guid.Empty)
                {
                    this._logger.EndProcess(processId, stopwatch);
                }
            }
        }

        /// <summary>
        /// Endpoint de prueba para validación de acceso (retorna datos mock).
        /// </summary>
        /// <param name="rut">Datos de la solicitud externa.</param>
        /// <param name="pass">Pass de la solicitud externa.</param>
        /// <returns>Datos de prueba.</returns>
        [HttpPost("[action]")]
        [SwaggerIgnore]
        [ProducesResponseType(typeof(SiniestrosResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<string> LoginFake(string rut, string pass)
        {
            try
            {
                using var httpClient = new HttpClient();

                // Headers
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add(this._settings.TokenCABName, this._settings.TokenCABValue);
                httpClient.DefaultRequestHeaders.Add(this._settings.CookieName, this._settings.CookieValue);

                // Body
                var jsonBody = $@"{{
                    ""rut"": ""{rut}"",
                    ""password"": ""{pass}"",
                    ""codigoAplicacionOrigen"": ""BCICLI"",
                    ""tipoEntorno"": ""APP30""
                }}";

                using var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(new Uri(this._settings.ValidarAccesoMultipleUrl), content).ConfigureAwait(false);
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Validar código HTTP
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException($"Error HTTP {(int)response.StatusCode}: {responseBody}");
                }

                // Parsear JSON y extraer SessionId del primer objeto
                using var doc = JsonDocument.Parse(responseBody);
                string? sessionId = null;

                if (doc.RootElement.ValueKind == JsonValueKind.Object
                    && doc.RootElement.TryGetProperty("SessionId", out var sessionProp))
                {
                    sessionId = sessionProp.GetString();
                }

                string? token = null;
                if (doc.RootElement.TryGetProperty("ListadoTokens", out var tokensArray) &&
                    tokensArray.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in tokensArray.EnumerateArray())
                    {
                        if (item.TryGetProperty("CodigoAplicacion", out var codigo) &&
                            string.Equals(codigo.GetString(), "CTACCESO", StringComparison.Ordinal) &&
                            item.TryGetProperty("Token", out var tokenProp))
                        {
                            token = tokenProp.GetString();
                            break;
                        }
                    }
                }

                ValidateAccessRequest request = new()
                {
                    RutTitular = rut,
                    RutSolicitante = rut,
                    Rol = ERol.Titular,
                    RutCorredor = rut,
                    Token = token,
                    Expiration = DateTime.UtcNow.AddHours(1),
                    Origen = EOrigen.Web,
                    RutaOrigen = "clientes.qa.bciseguros.cl",
                    SessionId = sessionId,
                };

                string urlFinal = await this._handler.GenerarUrlFrontend(request).ConfigureAwait(false);
                urlFinal = urlFinal.Replace(".desa.", ".qa.", StringComparison.OrdinalIgnoreCase);
                return urlFinal;
            }
            catch (HttpRequestException httpEx)
            {
                this._logger.LogError(httpEx);
                return $"Error HTTP al consumir el servicio: {httpEx.Message}";
            }
            catch (TaskCanceledException tex)
            {
                this._logger.LogError(tex);
                return $"Error: tiempo de espera agotado al llamar al servicio. Detalle: {tex.Message}";
            }
            catch (JsonException jsonEx)
            {
                this._logger.LogError(jsonEx);
                throw new InvalidOperationException($"Error al parsear respuesta JSON: {jsonEx.Message}", jsonEx);
            }
        }

        /// <summary>
        /// Obtiene de forma segura el valor de una propiedad de un JsonElement.
        /// </summary>
        /// <param name="element">Elemento JSON.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <param name="defaultValue">Valor por defecto si no existe.</param>
        /// <returns>Valor de la propiedad o valor por defecto.</returns>
        private static string GetPropertySafe(JsonElement element, string propertyName, string defaultValue = "")
        {
            return element.TryGetProperty(propertyName, out var prop) ? prop.GetString() ?? defaultValue : defaultValue;
        }

        /// <summary>
        /// Parsea los datos JSON de siniestros a una lista de SiniestrosDataResponse.
        /// </summary>
        /// <param name="jsonArray">Array JSON deserializado.</param>
        /// <returns>Lista de siniestros parseados.</returns>
        private List<SiniestrosDataResponse> ParseSiniestrosFromJson(JsonElement jsonArray)
        {
            var siniestrosList = new List<SiniestrosDataResponse>();

            foreach (var siniestroData in jsonArray.EnumerateArray())
            {
                var siniestroResponse = this.TryParseSiniestro(siniestroData);
                if (siniestroResponse != null)
                {
                    siniestrosList.Add(siniestroResponse);
                }
            }

            return siniestrosList;
        }

        /// <summary>
        /// Intenta parsear un elemento JSON a SiniestrosDataResponse.
        /// </summary>
        /// <param name="siniestroData">Elemento JSON con datos del siniestro.</param>
        /// <returns>SiniestrosDataResponse o null si no se puede parsear.</returns>
        private SiniestrosDataResponse? TryParseSiniestro(JsonElement siniestroData)
        {
            var numeroSiniestro = GetPropertySafe(siniestroData, "NumeroSiniestro");

            if (!int.TryParse(numeroSiniestro, CultureInfo.InvariantCulture, out int numSiniestro))
            {
                this._logger.Debug($"No se pudo parsear NumeroSiniestro: {numeroSiniestro}. Se omitirá este registro.");
                return null;
            }

            return new SiniestrosDataResponse
            {
                RutCorredor = GetPropertySafe(siniestroData, "RutCorredor"),
                NumeroSiniestro = numSiniestro,
                FechaSiniestro = GetPropertySafe(siniestroData, "FechaSiniestro"),
                FechaDenuncia = GetPropertySafe(siniestroData, "FechaDenuncia"),
                CodigoEstado = GetPropertySafe(siniestroData, "CodigoEstado"),
                Estado = GetPropertySafe(siniestroData, "Estado"),
                CodigoEtapa = GetPropertySafe(siniestroData, "CodigoEtapa"),
                Etapa = GetPropertySafe(siniestroData, "Etapa"),
                Ramo = GetPropertySafe(siniestroData, "Ramo"),
                NumeroPoliza = GetPropertySafe(siniestroData, "NumeroPoliza"),
                NumeroItem = GetPropertySafe(siniestroData, "NumeroItem"),
                TipoDano = GetPropertySafe(siniestroData, "TipoDano"),
            };
        }

        /// <summary>
        /// Filtra y procesa siniestros VP para crear requests de detalle.
        /// </summary>
        /// <param name="siniestros">Lista de siniestros.</param>
        /// <returns>Lista de requests únicos con datos originales.</returns>
        private List<(SiniestrosDetRequest Request, SiniestrosDataResponse OriginalData)> ProcessVPSiniestros(
            IReadOnlyCollection<SiniestrosDataResponse> siniestros)
        {
            var result = new List<(SiniestrosDetRequest Request, SiniestrosDataResponse OriginalData)>();

            foreach (var s in siniestros.Where(p => string.Equals(p.Ramo, "VP", StringComparison.Ordinal) && p.NumeroSiniestro.HasValue && !string.IsNullOrWhiteSpace(p.NumeroPoliza)))
            {
                var numeroPolizaStr = new string(s.NumeroPoliza!.Where(char.IsDigit).ToArray());

                if (!int.TryParse(numeroPolizaStr, CultureInfo.InvariantCulture, out int numeroDocto))
                {
                    this._logger.Debug($"No se pudo parsear NumeroPoliza: {s.NumeroPoliza}. Se omitirá este registro.");
                    continue;
                }

                var detRequest = new SiniestrosDetRequest
                {
                    INsinie = s.NumeroSiniestro!.Value,
                    INdocto = numeroDocto,
                };

                result.Add((detRequest, s));
            }

            return result.DistinctBy(x => new { x.Request.INsinie, x.Request.INdocto }).ToList();
        }

        /// <summary>
        /// Crea DTOs de siniestros a partir de los datos procesados.
        /// </summary>
        /// <param name="lstSiniestrosDataResponse">Lista de requests con datos originales.</param>
        /// <param name="siniestrosArray">Array JSON con detalles de siniestros.</param>
        /// <returns>DTO de datos de siniestros.</returns>
        private SiniestrosDataDto CreateSiniestrosDTO(
            List<(SiniestrosDetRequest Request, SiniestrosDataResponse OriginalData)> lstSiniestrosDataResponse,
            JsonElement siniestrosArray)
        {
            var siniestrosDataDTO = new SiniestrosDataDto();
            siniestrosDataDTO.TiposSiniestros.Add(new TipoSiniestroDto { Nombre = "Vehículo", Visible = true });

            foreach (var item in lstSiniestrosDataResponse)
            {
                var siniestroDto = this.CreateSiniestroDto(item, siniestrosArray);
                if (siniestroDto != null)
                {
                    siniestrosDataDTO.Siniestros.Add(siniestroDto);
                }
            }

            return siniestrosDataDTO;
        }

        /// <summary>
        /// Crea un SiniestroDto a partir de un item de siniestro y su detalle.
        /// </summary>
        /// <param name="item">Item con request y datos originales.</param>
        /// <param name="siniestrosArray">Array JSON con detalles.</param>
        /// <returns>SiniestroDto o null si no se encuentra detalle.</returns>
        private SiniestroDto? CreateSiniestroDto(
            (SiniestrosDetRequest Request, SiniestrosDataResponse OriginalData) item,
            JsonElement siniestrosArray)
        {
            var numeroSiniestroStr = item.OriginalData.NumeroSiniestro?.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
            var siniestroDataNullable = siniestrosArray.EnumerateArray()
                .FirstOrDefault(s => string.Equals(GetPropertySafe(s, "NUMEROSINIESTRO"), numeroSiniestroStr, StringComparison.Ordinal));

            if (siniestroDataNullable.ValueKind == JsonValueKind.Undefined)
            {
                this._logger.Debug($"No se encontró detalle para el siniestro número {numeroSiniestroStr}. Se omitirá este registro.");
                return null;
            }

            var patente = GetPropertySafe(siniestroDataNullable, "PATENTE");

            return new SiniestroDto
            {
                NumSiniestro = numeroSiniestroStr,
                TipoSinistros = "auto", // Hardcoded para tipo auto
                GlosaSiniestro = $"Patente: {patente}",
                FechaDenuncio = item.OriginalData.FechaDenuncia ?? string.Empty,
                EstadoSinistro = item.OriginalData.Estado ?? string.Empty,
                EstadoDenuncio = item.OriginalData.CodigoEstado ?? string.Empty,
                AccionesPendientes = false,
            };
        }
    }
}