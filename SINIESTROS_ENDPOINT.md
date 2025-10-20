# Endpoints de Siniestros - Documentación

## Descripción
API para consultar información de siniestros:
1. **por-asegurado**: Obtiene lista de siniestros de un asegurado por su RUT
2. **datos-detalle**: Obtiene datos detallados de un siniestro específico

---

## 1. Siniestros por Asegurado

### URL
```
POST /api/v1/siniestros/por-asegurado
```

## Request

### Headers
- `Content-Type: application/json`

### Body
```json
{
  "rutAsegurado": 26462809
}
```

### Ejemplo usando cURL
```bash
curl -X POST http://localhost:5000/api/v1/siniestros/por-asegurado \
  -H "Content-Type: application/json" \
  -d '{
    "rutAsegurado": 26462809
  }'
```

## Response

### Respuesta Exitosa (200 OK)
```json
{
  "success": true,
  "message": "Lista de siniestros por asegurado Bci!",
  "data": [
    {
      "rutCorredor": "76213750-K",
      "numeroSiniestro": 7221880,
      "fechaSiniestro": "2022-7-29",
      "fechaDenuncia": "2022-7-29",
      "codigoEstado": "A",
      "estado": "Aceptado",
      "codigoEtapa": "04",
      "etapa": "Liquidado Total",
      "ramo": "VP",
      "numeroPoliza": "W-P-00010871789",
      "numeroItem": "0000001",
      "tipoDano": "Propios"
    }
  ],
  "errorCode": null,
  "timestamp": "2025-01-15T10:30:00.000Z"
}
```

### Respuesta de Error (400 Bad Request)
```json
{
  "success": false,
  "message": "Error al consultar siniestros",
  "data": null,
  "errorCode": "VALIDATION_ERROR",
  "timestamp": "2025-01-15T10:30:00.000Z"
}
```

### Respuesta de Error Interno (500 Internal Server Error)
```json
{
  "success": false,
  "message": "Error interno del servidor",
  "data": null,
  "errorCode": "INTERNAL_SERVER_ERROR",
  "timestamp": "2025-01-15T10:30:00.000Z"
}
```

## Modelo de Datos

### SiniestrosRequest
| Campo | Tipo | Requerido | Descripción |
|-------|------|-----------|-------------|
| rutAsegurado | int | Sí | RUT del asegurado sin puntos ni guión |

### DefaultResponse<T>
| Campo | Tipo | Descripción |
|-------|------|-------------|
| success | boolean | Indica si la operación fue exitosa |
| message | string | Mensaje descriptivo de la respuesta |
| data | T | Datos de la respuesta (lista de siniestros) |
| errorCode | string? | Código de error (null si fue exitoso) |
| timestamp | string? | Timestamp ISO 8601 de la respuesta |

### SiniestroDto
| Campo | Tipo | Descripción |
|-------|------|-------------|
| rutCorredor | string | RUT del corredor |
| numeroSiniestro | int | Número de siniestro |
| fechaSiniestro | string | Fecha del siniestro |
| fechaDenuncia | string | Fecha de denuncia |
| codigoEstado | string | Código del estado |
| estado | string | Descripción del estado |
| codigoEtapa | string | Código de la etapa |
| etapa | string | Descripción de la etapa |
| ramo | string | Ramo del seguro |
| numeroPoliza | string | Número de póliza |
| numeroItem | string | Número de ítem |
| tipoDano | string | Tipo de daño |

## Configuración

El endpoint consume un servicio externo de BCI. La configuración se encuentra en `appsettings.Development.json`:

```json
{
  "SiniestrosApi": {
    "BaseUrl": "http://busservicioonline.qa.bciseguros.cl:52773",
    "Endpoint": "/apioperaciones/service/generales/getsiniestrosporasegurado",
    "AuthToken": "Basic dWdwd3NuMDE6U2luaWVzdHJvc0wyMDIxKg==",
    "Cookie": "ADC_CONN_539B3595F4E=...; ADC_REQ_2E94AF76E7=..."
  }
}
```

## Códigos de Error

| Código | Descripción |
|--------|-------------|
| NULL_REQUEST | La solicitud es nula |
| VALIDATION_ERROR | Errores de validación en el request |
| NO_DATA | No se recibieron datos del servicio externo |
| INTERNAL_ERROR | Error interno al consumir el servicio externo |
| INTERNAL_SERVER_ERROR | Error interno del servidor |

## Integración con Angular

El frontend Angular puede consumir este endpoint de la siguiente manera:

```typescript
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface DefaultResponse<T> {
  success: boolean;
  message: string;
  data: T;
  errorCode?: string;
  timestamp?: string;
}

export interface SiniestroDto {
  rutCorredor: string;
  numeroSiniestro: number;
  fechaSiniestro: string;
  fechaDenuncia: string;
  codigoEstado: string;
  estado: string;
  codigoEtapa: string;
  etapa: string;
  ramo: string;
  numeroPoliza: string;
  numeroItem: string;
  tipoDano: string;
}

// Servicio
@Injectable({ providedIn: 'root' })
export class SiniestrosService {
  private apiUrl = 'http://localhost:5000/api/v1/siniestros';

  constructor(private http: HttpClient) {}

  obtenerSiniestrosPorAsegurado(rutAsegurado: number): Observable<DefaultResponse<SiniestroDto[]>> {
    return this.http.post<DefaultResponse<SiniestroDto[]>>(
      `${this.apiUrl}/por-asegurado`,
      { rutAsegurado }
    );
  }
}

// Componente
export class SiniestrosComponent {
  constructor(private siniestrosService: SiniestrosService) {}

  buscarSiniestros(rut: number) {
    this.siniestrosService.obtenerSiniestrosPorAsegurado(rut)
      .subscribe({
        next: (response) => {
          if (response.success) {
            console.log('Siniestros:', response.data);
          } else {
            console.error('Error:', response.message);
          }
        },
        error: (error) => {
          console.error('Error al consultar siniestros:', error);
        }
      });
  }
}
```

## Archivos Creados

1. **Models/Requests/SiniestrosRequest.cs** - DTO para el request
2. **Models/Responses/SiniestrosExternalResponse.cs** - DTO para la respuesta del servicio externo
3. **Models/Responses/DefaultResponse.cs** - DTO genérico para respuestas del API
4. **Models/Settings/SiniestrosApiSettings.cs** - Configuración del servicio externo
5. **Services/Interfaces/ISiniestrosService.cs** - Interfaz del servicio
6. **Services/SiniestrosService.cs** - Implementación del servicio
7. **Controllers/SiniestrosController.cs** - Controlador del endpoint

## Notas
- El endpoint está configurado con `[AllowAnonymous]` (sin autenticación)
- Todos los logs se registran automáticamente con correlation ID
- El servicio maneja automáticamente errores y excepciones
- La respuesta siempre incluye timestamp en formato ISO 8601

---

## 2. Datos Detallados de Siniestro

### URL
```
POST /api/v1/siniestros/datos-detalle
```

## Request

### Headers
- `Content-Type: application/json`

### Body
```json
{
  "numeroSiniestro": 10226686,
  "numeroRiesgo": 6,
  "numeroItem": 1,
  "codigoSucursal": "W",
  "codigoTipoDocumento": "P",
  "numeroDocumento": 12081063,
  "patente": ""
}
```

### Ejemplo usando cURL
```bash
curl -X POST http://localhost:5000/api/v1/siniestros/datos-detalle \
  -H "Content-Type: application/json" \
  -d '{
    "numeroSiniestro": 10226686,
    "numeroRiesgo": 6,
    "numeroItem": 1,
    "codigoSucursal": "W",
    "codigoTipoDocumento": "P",
    "numeroDocumento": 12081063,
    "patente": ""
  }'
```

## Response

### Respuesta Exitosa (200 OK)
```json
{
  "success": true,
  "message": "Data encontrada",
  "data": [
    {
      "numeroSiniestro": 6917436,
      "patente": "BHPL48",
      "codigoVehiculo": "  ",
      "tipoVehiculo": null,
      "codigoMarca": "JEE",
      "descripcionMarca": "JEEP",
      "codigoModelo": "01",
      "descripcionModelo": "CHEROKEE",
      "codigoVersion": "  ",
      "descripcionVersion": "CHEROKEE LIBERTY LIMITED 3.7 AT",
      "anioFabricacion": 2008,
      "fechaSiniestro": "20210123",
      "fechaAviso": "20210123",
      "fechaIngresoSistema": "20210123",
      "estadoSiniestro": "A ",
      "rutLiquidador": 18149378,
      "dvLiquidador": "K",
      "nombreLiquidador": "LUIS RAMIREZ GONZALEZ",
      "emailLiquidador": "liquidador@bciseguros.com",
      "valorDeducible": 0.00,
      "codigoGrado": "04",
      "descripcionGrado": "LEVES",
      "nombreDenunciante": "JUAN  PABLO VIAL BRICENO",
      "emailDenunciante": "juanpablo.vial@yahoo.com",
      "nombreAsegurado": "JUAN  PABLO VIAL BRICENO",
      "emailAsegurado": "juanpablo.vial@yahoo.com",
      "nombreConductor": "JUAN  PABLO VIAL BRICENO",
      "emailConductor": "juanpablo.vial@yahoo.com",
      "descripcionEtapa": "LIQUIDADO",
      "perdidaEstimada": 12.00,
      "nombreTaller": "AUTOACTION CORP SA",
      "direccionTaller": "AV VITACURA 7408",
      "fechaEntrega": "2021-02-04"
    }
  ],
  "errorCode": null,
  "timestamp": "2025-01-15T10:30:00.000Z"
}
```

## Modelo de Datos

### DatosSiniestroRequest
| Campo | Tipo | Requerido | Descripción |
|-------|------|-----------|-------------|
| numeroSiniestro | int | Sí | Número de siniestro |
| numeroRiesgo | int | Sí | Número de riesgo |
| numeroItem | int | Sí | Número de ítem |
| codigoSucursal | string | Sí | Código de sucursal (1 carácter) |
| codigoTipoDocumento | string | Sí | Código de tipo de documento (1 carácter) |
| numeroDocumento | int | Sí | Número de documento |
| patente | string | No | Patente del vehículo (opcional) |

### DatosSiniestroDetalleDto
Contiene más de 80 campos con información detallada del siniestro, incluyendo:
- Datos del vehículo (marca, modelo, versión, año, patente, chasis, motor, color)
- Fechas (siniestro, aviso, ingreso, entrega, asignación)
- Datos del liquidador (RUT, nombre, teléfono, email)
- Datos del asegurado (nombre, email, teléfonos)
- Datos del denunciante (RUT, nombre, email, teléfonos)
- Datos del conductor (RUT, nombre, email, teléfonos)
- Información del siniestro (descripción accidente, estado, etapa, grado)
- Datos de pérdidas (estimada, total, deducible)
- Información del taller (nombre, dirección)
- Datos de la póliza (sucursal, ramo, documento, ítem)

## Configuración

El endpoint consume un servicio externo de BCI. La configuración se encuentra en `appsettings.Development.json`:

```json
{
  "DatosSiniestroApi": {
    "BaseUrl": "https://busservicio.bciseguros.cl",
    "Endpoint": "/apiwebliquidacionvehiculo/service/bci/getdatossiniestros",
    "AuthToken": "Basic dWdwd3NuMDE6U2luaWVzdHJvc0wyMDIxKg==",
    "Cookie": "ADC_CONN_539B3595F4E=...; ADC_REQ_2E94AF76E7=..."
  }
}
```

## Integración con Angular

```typescript
export interface DatosSiniestroRequest {
  numeroSiniestro: number;
  numeroRiesgo: number;
  numeroItem: number;
  codigoSucursal: string;
  codigoTipoDocumento: string;
  numeroDocumento: number;
  patente?: string;
}

// Servicio
@Injectable({ providedIn: 'root' })
export class SiniestrosService {
  private apiUrl = 'http://localhost:5000/api/v1/siniestros';

  constructor(private http: HttpClient) {}

  obtenerDatosSiniestro(request: DatosSiniestroRequest): Observable<DefaultResponse<any[]>> {
    return this.http.post<DefaultResponse<any[]>>(
      `${this.apiUrl}/datos-detalle`,
      request
    );
  }
}

// Componente
export class DetallesSiniestroComponent {
  constructor(private siniestrosService: SiniestrosService) {}

  buscarDetallesSiniestro() {
    const request: DatosSiniestroRequest = {
      numeroSiniestro: 10226686,
      numeroRiesgo: 6,
      numeroItem: 1,
      codigoSucursal: "W",
      codigoTipoDocumento: "P",
      numeroDocumento: 12081063,
      patente: ""
    };

    this.siniestrosService.obtenerDatosSiniestro(request)
      .subscribe({
        next: (response) => {
          if (response.success) {
            console.log('Detalles del siniestro:', response.data);
          } else {
            console.error('Error:', response.message);
          }
        },
        error: (error) => {
          console.error('Error al consultar detalles:', error);
        }
      });
  }
}
```

## Archivos Adicionales Creados

8. **Models/Requests/DatosSiniestroRequest.cs** - DTO para el request de datos detallados
9. **Models/Responses/DatosSiniestroExternalResponse.cs** - DTO para la respuesta del servicio externo
10. **Models/Settings/DatosSiniestroApiSettings.cs** - Configuración del servicio externo
11. **Services/Interfaces/IDatosSiniestroService.cs** - Interfaz del servicio
12. **Services/DatosSiniestroService.cs** - Implementación del servicio

## Mejoras Implementadas

### Logs Mejorados
Todos los servicios y controladores ahora incluyen:
- `StartProcess/EndProcess` para medir tiempo de ejecución
- Logs detallados en cada paso crítico (Info, Debug, LogError)
- Campos privados con underscore (_field) según .editorconfig
- Correlation ID en todas las operaciones

### Cumplimiento de .editorconfig
- Campos privados con underscore `_fieldName`
- Uso correcto de métodos de log: `Info()`, `Debug()`, `LogError()`
- Indentación y espaciado según estándares del proyecto
