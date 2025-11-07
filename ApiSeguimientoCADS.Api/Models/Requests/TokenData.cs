// <copyright file="TokenData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApiSeguimientoCADS.Api.Models.Requests
{
    public record TokenData
    {
        /// <summary>
        /// EsTitular
        /// </summary>
        public int EsTitular { get; set; }

        /// <summary>
        /// Rol
        /// </summary>
        public int Rol { get; set; }

        /// <summary>
        /// Orige
        /// </summary>
        public int Origen { get; set; }

        /// <summary>
        /// SessionId
        /// </summary>
        public string SessionId { get; set; } = null!;

        /// <summary>
        /// RutTitular
        /// </summary>
        public string RutTitular { get; set; } = null!;

        /// <summary>
        /// Solicitante
        /// </summary>
        public string Solicitante { get; set; } = null!;

        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; } = null!;

        /// <summary>
        /// Apellidos
        /// </summary>
        public string Apellidos { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// tokenOrigen
        /// </summary>
        public string TokenOrigen { get; set; } = null!;
    }
}