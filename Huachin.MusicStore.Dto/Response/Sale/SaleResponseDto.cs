﻿namespace Huachin.MusicStore.Dto.Response.Sale
{
    public class SaleResponseDto
    {
		public int IdCustomer { get; set; }

		public int IdConcert { get; set; }

		public DateTime SaleDate { get; set; }

		public string OperationNumber { get; set; } = null!;

		public decimal Total { get; set; }

		public short Quantity { get; set; }
	}
}
