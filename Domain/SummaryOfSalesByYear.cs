﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain;

[Keyless]
public partial class SummaryOfSalesByYear
{
    [Column(TypeName = "datetime")]
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    [Column(TypeName = "money")]
    public decimal? Subtotal { get; set; }
}
