﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Domain.Models
{
	public class RecyclableItem
	{
		public int Id { get; set; }

		public string ItemDescription { get; set; }

		public int RecyclableTypeId { get; set; }

		[ForeignKey(nameof(RecyclableTypeId))]
		public RecyclableType RecyclableType { get; set; }

		public double Weight { get; set; }

		public double ComputedRate { get; set; }
	}
}
