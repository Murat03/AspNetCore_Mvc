﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
	public record ProductDto
	{
		public int ProductId { get; init; }
		[Required(ErrorMessage = "ProductName is required!")]
		public String? ProductName { get; init; } = String.Empty;
		[Required(ErrorMessage = "Price is required!")]
		public decimal Price { get; init; }
		public String? Summary { get; init; } = String.Empty;
		public String? ImageUrl { get; set; }
		public int? CategoryId { get; set; }
	}
}
