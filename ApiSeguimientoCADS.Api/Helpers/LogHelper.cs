// <copyright file="LogHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Helpers
{
    /// <summary>
    /// Clase para enmascarar valores del log
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Metodo para enmascarar el rut en el log
        /// </summary>
        /// <param name="rut">Excepción.</param>
        /// <returns>True si tiene inner exception.</returns>
        public static string MaskRut(string rut)
        {
            if (string.IsNullOrEmpty(rut) || rut.Length < 4)
            {
                return "****";
            }

            return string.Concat("****", rut.AsSpan(rut.Length - 4));
        }

        /// <summary>
        /// Metodo para enmascarar el correo en el log
        /// </summary>
        /// <param name="email">Excepción.</param>
        /// <returns>Retorna ****</returns>
        public static string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "****";
            }

            var parts = email.Split('@');
            return string.Concat(parts[0].AsSpan(0, 2), "***@", parts[1]);
        }
    }
}