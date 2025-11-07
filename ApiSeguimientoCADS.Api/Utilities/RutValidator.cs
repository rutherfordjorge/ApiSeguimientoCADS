// <copyright file="RutValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSeguimientoCADS.Api.Utilities
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Validador de RUT chileno.
    /// </summary>
    public static class RutValidator
    {
        /// <summary>
        /// Obtiene solo el número del RUT sin dígito verificador, puntos ni guiones.
        /// </summary>
        /// <param name="rut">RUT en cualquier formato.</param>
        /// <returns>Solo el número del RUT.</returns>
        public static string ObtenerNumeroRut(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut))
            {
                return string.Empty;
            }

            string rutLimpio = rut.Replace(".", string.Empty, StringComparison.Ordinal)
                                  .Replace("-", string.Empty, StringComparison.Ordinal)
                                  .Replace(" ", string.Empty, StringComparison.Ordinal)
                                  .Trim()
                                  .ToUpper(CultureInfo.InvariantCulture);

            if (string.IsNullOrEmpty(rutLimpio))
            {
                return string.Empty;
            }

            if (rutLimpio.Length > 1)
            {
                char ultimoCaracter = rutLimpio[rutLimpio.Length - 1];

                if (!char.IsDigit(ultimoCaracter) || rutLimpio.Length > 8)
                {
                    rutLimpio = rutLimpio.Substring(0, rutLimpio.Length - 1);
                }
            }

            return new string(rutLimpio.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Valida un RUT chileno. Si viene sin DV y es numéricamente válido, también se considera válido.
        /// </summary>
        /// <param name="rut">RUT a validar (puede contener puntos y guión).</param>
        /// <returns>true si el RUT es válido; false en caso contrario.</returns>
        public static bool Validar(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut))
            {
                return false;
            }

            // Limpiar el RUT
            rut = rut.Replace(".", string.Empty, StringComparison.Ordinal)
                     .Replace("-", string.Empty, StringComparison.Ordinal)
                     .Trim()
                     .ToUpper(CultureInfo.InvariantCulture);

            if (rut.Length < 1)
            {
                return false;
            }

            // Caso 1: RUT sin DV (todo numérico)
            if (rut.All(char.IsDigit))
            {
                // Largo 7-8 sin DV es válido
                if (rut.Length >= 7 && rut.Length <= 8)
                {
                    return true;
                }

                // Largo 9 => con DV incluido como último dígito → validarlo
                if (rut.Length == 9)
                {
                    string rutNumero = rut.Substring(0, 8); // primeros 8 dígitos
                    char dv = rut[8]; // último dígito como DV

                    if (!int.TryParse(rutNumero, out int numero))
                    {
                        return false;
                    }

                    return CalcularDigitoVerificador(numero) == dv;
                }

                return false;
            }

            // Caso 2: RUT con DV
            if (rut.Length >= 2)
            {
                string rutNumero = rut.Substring(0, rut.Length - 1);
                char digitoVerificador = rut[rut.Length - 1];

                if (!int.TryParse(rutNumero, out int numero))
                {
                    return false;
                }

                char dvEsperado = CalcularDigitoVerificador(numero);
                return digitoVerificador == dvEsperado;
            }

            return false;
        }

        /// <summary>
        /// Calcula el dígito verificador de un RUT.
        /// </summary>
        private static char CalcularDigitoVerificador(int rut)
        {
            if (rut <= 0 || rut > 99999999)
            {
                throw new ArgumentOutOfRangeException(nameof(rut), "El RUT debe estar entre 1 y 99.999.999.");
            }

            int suma = 0;
            int multiplicador = 2;
            int valor = rut;

            while (valor > 0)
            {
                suma += (valor % 10) * multiplicador;
                valor /= 10;
                multiplicador = multiplicador == 7 ? 2 : multiplicador + 1;
            }

            int resto = suma % 11;
            int dv = 11 - resto;

            return dv switch
            {
                11 => '0',
                10 => 'K',
                _ => dv.ToString(CultureInfo.InvariantCulture)[0],
            };
        }
    }
}