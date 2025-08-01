﻿using Volo.Abp.Application.Dtos;

namespace AbpDemo.Products
{
    public class CreateUpdateProductDto : AuditedEntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; }
        public string? ImageUrl { get; set; }


        public long CategoryId { get; set; }
    }
}
